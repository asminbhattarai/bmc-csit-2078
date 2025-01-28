using Microsoft.AspNetCore.Mvc;
using StudentModelForm.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace StudentModelForm.Controllers
{
    public class StudentController : Controller
    {
        /*
         * Database Setup Instructions:
         * 
         * 1. Open SQL Server Object Explorer in Visual Studio
         *    - View -> SQL Server Object Explorer
         * 
         * 2. Navigate to:
         *    SQL Server -> (localdb)\ProjectModels -> Databases -> master -> Tables
         * 
         * 3. The InitializeDatabase() method below will automatically create the Students table
         *    in the master database when you first run the application
         * 
         * Alternative Manual Table Creation:
         * Right-click on Tables -> New Query
         * Execute this SQL:
         * 
         * CREATE TABLE Students (
         *     Id INT IDENTITY(1,1) PRIMARY KEY,
         *     FirstName NVARCHAR(100) NULL,
         *     LastName NVARCHAR(100) NOT NULL,
         *     Age INT NOT NULL,
         *     Email NVARCHAR(255) NOT NULL,
         *     PhoneNumber NVARCHAR(50) NULL,
         *     EnrollmentDate DATETIME NOT NULL
         * )
         */

        // Connection string for LocalDB master database
        private readonly string _connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Add this method to initialize the database
        private void InitializeDatabase()
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();
            using SqlCommand cmd = new(@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Students' and xtype='U')
                    CREATE TABLE Students (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        FirstName NVARCHAR(100) NULL,
                        LastName NVARCHAR(100) NOT NULL,
                        Age INT NOT NULL,
                        Email NVARCHAR(255) NOT NULL,
                        PhoneNumber NVARCHAR(50) NULL,
                        EnrollmentDate DATETIME NOT NULL
                    )", conn);
            cmd.ExecuteNonQuery();
        }

        // GET: Student
        [Route("")]
        public ActionResult Index()
        {
            InitializeDatabase();
            List<Student> students = [];
            using (SqlConnection conn = new(_connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new("SELECT * FROM Students", conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32("Id"),
                        FirstName = reader.IsDBNull("FirstName") ? null : reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        Age = reader.GetInt32("Age"),
                        Email = reader.GetString("Email"),
                        PhoneNumber = reader.IsDBNull("PhoneNumber") ? null : reader.GetString("PhoneNumber"),
                        EnrollmentDate = reader.GetDateTime("EnrollmentDate")
                    });
                }
            }
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student? student = null;
            using (SqlConnection conn = new(_connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new("SELECT * FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = reader.GetInt32("Id"),
                        FirstName = reader.IsDBNull("FirstName") ? null : reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        Age = reader.GetInt32("Age"),
                        Email = reader.GetString("Email"),
                        PhoneNumber = reader.IsDBNull("PhoneNumber") ? null : reader.GetString("PhoneNumber"),
                        EnrollmentDate = reader.GetDateTime("EnrollmentDate")
                    };
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new(_connectionString))
                {
                    conn.Open();
                    using SqlCommand cmd = new(@"
                        INSERT INTO Students (FirstName, LastName, Age, Email, PhoneNumber, EnrollmentDate)
                        VALUES (@FirstName, @LastName, @Age, @Email, @PhoneNumber, @EnrollmentDate)", conn);
                    cmd.Parameters.AddWithValue("@FirstName", (object?)student.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object?)student.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student? student = null;
            using (SqlConnection conn = new(_connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new("SELECT * FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = reader.GetInt32("Id"),
                        FirstName = reader.IsDBNull("FirstName") ? null : reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        Age = reader.GetInt32("Age"),
                        Email = reader.GetString("Email"),
                        PhoneNumber = reader.IsDBNull("PhoneNumber") ? null : reader.GetString("PhoneNumber"),
                        EnrollmentDate = reader.GetDateTime("EnrollmentDate")
                    };
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new(_connectionString))
                {
                    conn.Open();
                    using SqlCommand cmd = new(@"
                        UPDATE Students 
                        SET FirstName = @FirstName, 
                            LastName = @LastName, 
                            Age = @Age, 
                            Email = @Email, 
                            PhoneNumber = @PhoneNumber, 
                            EnrollmentDate = @EnrollmentDate
                        WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@FirstName", (object?)student.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", (object?)student.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student? student = null;
            using (SqlConnection conn = new(_connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new("SELECT * FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = reader.GetInt32("Id"),
                        FirstName = reader.IsDBNull("FirstName") ? null : reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        Age = reader.GetInt32("Age"),
                        Email = reader.GetString("Email"),
                        PhoneNumber = reader.IsDBNull("PhoneNumber") ? null : reader.GetString("PhoneNumber"),
                        EnrollmentDate = reader.GetDateTime("EnrollmentDate")
                    };
                }
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection conn = new(_connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new("DELETE FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
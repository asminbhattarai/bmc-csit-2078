using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentModelForm.Data;
using StudentModelForm.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace StudentModelForm.Controllers
{
    public class StudentController(StudentDbContext context) : Controller
    {
        private readonly StudentDbContext _context = context;

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

        // GET: Student
        [Route("")]
        public async Task<ActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var student = await _context.Students.FindAsync(id);
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
        public async Task<ActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Students.AnyAsync(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
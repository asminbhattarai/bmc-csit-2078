using Microsoft.AspNetCore.Mvc;
using StudentModelForm.Models;

namespace StudentModelForm.Controllers
{
    public class StudentController : Controller
    {
        // Sample in-memory data store (usually you would use a database)
        private static readonly List<Student> students = new List<Student>
        {
            new Student { Id = 10, FirstName = "Asmin", LastName = "Bhattarai", Age = 25, Email = "asmin@example.com", PhoneNumber = "", EnrollmentDate = DateTime.Now }
        };

        // GET: Student
        [Route("")]
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
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
                student.Id = students.Count + 1; // Simulate auto-increment
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
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
                var existingStudent = students.FirstOrDefault(s => s.Id == id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Age = student.Age;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.EnrollmentDate = student.EnrollmentDate;

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
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
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}

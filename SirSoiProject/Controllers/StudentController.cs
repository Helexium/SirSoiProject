using Microsoft.AspNetCore.Mvc;
using SirSoiProject.Models;

namespace SirSoiProject.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentID = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var studentexisting = students.FirstOrDefault(s => s.StudentID == id);
                if (studentexisting == null)
                {
                    return NotFound();
                }

                studentexisting.FirstName = student.FirstName;
                studentexisting.MiddleName = student.MiddleName;
                studentexisting.LastName = student.LastName;
                studentexisting.YearLevel = student.YearLevel;
                studentexisting.Gender = student.Gender;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName ("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}

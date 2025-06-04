using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirSoiProject.Models;
using System.Threading.Tasks;


namespace SirSoiProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDB _studentDB;


        public StudentController(StudentDB studentDB)
        {
            _studentDB = studentDB;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentDB.Student.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                int id = _studentDB.Student.Count() + 1;
                student.StudentID = id;
                await _studentDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}

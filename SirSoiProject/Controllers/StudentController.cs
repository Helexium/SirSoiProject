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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentDB.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                int id = _studentDB.Students.Count() + 1;
                student.StudentID = id;
                _studentDB.Students.Add(student);
                await _studentDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}

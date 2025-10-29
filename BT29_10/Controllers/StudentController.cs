using BT29_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT29_10.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext db;

        public StudentController(StudentDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = db.Studens.ToList();
            return Json(students);
        }
    }
}

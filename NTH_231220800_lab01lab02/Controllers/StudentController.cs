using Microsoft.AspNetCore.Mvc;
using NTH_231220800_lab01lab02.Models;

namespace NTH_231220800_lab01lab02.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student(){Id=1, Name="Alice", password="alice123", Branch=Branch.IT,Gender=Gender.Male,isRegular=true,
                Address="Ha Noi",Email="alice@gmail.com"},
                new Student(){Id=2, Name="Bob", password="bob123", Branch=Branch.BE,Gender=Gender.Male,isRegular=false,
                Address="Da Nang",Email="bob@g.com"},
                new Student(){Id=3, Name="Cathy", password="cathy123", Branch=Branch.CE,Gender=Gender.Male,isRegular=true,
                Address="HCM",Email="ca@g.com"},
                new Student(){Id=4, Name="David", password="david123", Branch=Branch.EE,Gender=Gender.Female,isRegular=true,
                Address="Hue",Email="da@g.com"},
                new Student(){Id=5, Name="Huy", password="eva123", Branch=Branch.IT,Gender=Gender.Female,isRegular=true,
                Address="VN",Email="huy@gmail.com"},
            };
        }
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet]
        public IActionResult Create()
        {
           ViewBag.Allgenders = Enum.GetValues(typeof(Gender)).Cast< Gender>().ToList();
           ViewBag.AllBranches = Enum.GetValues(typeof(Branch)).Cast< Branch>().ToList();
           return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = listStudents.Max(s => s.Id) + 1;
            listStudents.Add(student);
            return View("Index",listStudents);
        }
    }
}

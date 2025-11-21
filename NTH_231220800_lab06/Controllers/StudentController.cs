using Day_12_lab1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day_12_lab1.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private static List<Student> students;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student { Id = 1, Name = "Nguyen Van A", Email = "a@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Male, IsRegular=true, Address="Ha Noi", DateOfBorth=new DateTime(2003,5,12) },
                    new Student { Id = 2, Name = "Tran Thi B", Email = "b@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=false, Address="Hai Phong", DateOfBorth=new DateTime(2004,1,22) },
                    new Student { Id = 3, Name = "Le Van C", Email = "c@example.com", Password="123", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address="Da Nang", DateOfBorth=new DateTime(2002,11,3) },
                    new Student { Id = 4, Name = "Pham Thi D", Email = "d@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="HCMC", DateOfBorth=new DateTime(2003,4,9) },
                    new Student { Id = 5, Name = "Hoang Van E", Email = "e@example.com", Password="123", Branch = Branch.EE, Gender = Gender.Male, IsRegular=false, Address="Hue", DateOfBorth=new DateTime(2001,2,15) },
                    new Student { Id = 6, Name = "Nguyen Thi F", Email = "f@example.com", Password="123", Branch = Branch.BE, Gender = Gender.Female, IsRegular=true, Address="Can Tho", DateOfBorth=new DateTime(2003,9,30) },
                    new Student { Id = 7, Name = "Bui Van G", Email = "g@example.com", Password="123", Branch = Branch.EE, Gender = Gender.Male, IsRegular=true, Address="Ninh Binh", DateOfBorth=new DateTime(2002,6,17) },
                    new Student { Id = 8, Name = "Vo Thi H", Email = "h@example.com", Password="123", Branch = Branch.IT, Gender = Gender.Female, IsRegular=false, Address="Quang Ninh", DateOfBorth=new DateTime(2004,7,2) },
                    new Student { Id = 9, Name = "Dang Van I", Email = "i@example.com", Password="123", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address="Ha Tinh", DateOfBorth=new DateTime(2003,8,21) },
                    new Student { Id = 10, Name = "Truong Thi J", Email = "j@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="Ben Tre", DateOfBorth=new DateTime(2004,12,10) },
                    new Student { Id = 11, Name = "Nguyen Van K", Email = "k@example.com", Password="123", Branch = Branch.EE, Gender = Gender.Male, IsRegular=false, Address="Ha Noi", DateOfBorth=new DateTime(2002,3,5) },
                    new Student { Id = 12, Name = "Le Thi L", Email = "l@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="Lang Son", DateOfBorth=new DateTime(2003,10,14) },
                    new Student { Id = 13, Name = "Pham Van M", Email = "m@example.com", Password="123", Branch = Branch.BE, Gender = Gender.Male, IsRegular=true, Address="Nam Dinh", DateOfBorth=new DateTime(2001,1,19) },
                    new Student { Id = 14, Name = "Hoang Thi N", Email = "n@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="Thanh Hoa", DateOfBorth=new DateTime(2004,4,4) },
                    new Student { Id = 15, Name = "Do Van O", Email = "o@example.com", Password="123", Branch = Branch.IT, Gender = Gender.Male, IsRegular=false, Address="HCMC", DateOfBorth=new DateTime(2002,9,27) },
                    new Student { Id = 16, Name = "Vu Thi P", Email = "p@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="Ha Giang", DateOfBorth=new DateTime(2003,11,8) },
                    new Student { Id = 17, Name = "Ngo Van Q", Email = "q@example.com", Password="123", Branch = Branch.BE, Gender = Gender.Male, IsRegular=true, Address="Tay Ninh", DateOfBorth=new DateTime(2001,6,6) },
                    new Student { Id = 18, Name = "Trinh Thi R", Email = "r@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=false, Address="Vinh Long", DateOfBorth=new DateTime(2002,12,25) },
                    new Student { Id = 19, Name = "Mai Van S", Email = "s@example.com", Password="123", Branch = Branch.EE, Gender = Gender.Male, IsRegular=true, Address="Khanh Hoa", DateOfBorth=new DateTime(2003,3,12) },
                    new Student { Id = 20, Name = "Ngo Thi T", Email = "t@example.com", Password="123", Branch = Branch.CE, Gender = Gender.Female, IsRegular=true, Address="Phu Tho", DateOfBorth=new DateTime(2004,5,29) },
                };
            }
        }

        [Route("List")]
        public async Task<IActionResult> Index()
        {
            Console.WriteLine(">>> [GET] Đang tải Index. Tổng số SV: " + students.Count);
            return View(students);
        }

        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranch = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = students.Last<Student>().Id + 1;
                students.Add(s);
                return RedirectToAction("Index", students);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranch = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "IT", Value = "1" },
                    new SelectListItem { Text = "BE", Value = "2" },
                    new SelectListItem { Text = "CE", Value = "3" },
                    new SelectListItem { Text = "EE", Value = "4" }
                };

            if (s.ProfileImage != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string uploadPath = Path.Combine(wwwRootPath, "images", "students");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                    Console.WriteLine("${uploadPath}");
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + s.ProfileImage.FileName;
                string filePath = Path.Combine(uploadPath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await s.ProfileImage.CopyToAsync(fileStream);
                }
                s.ProfileImagePath = "/images/students/" + uniqueFileName;
            }
            Console.WriteLine(">>> [POST] Đã thêm. Tổng số SV: " + students.Count);
            return View();
        }
    }
}

using Lab06Validation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06Validation.Controllers
{
    public class StudentController : Controller
    {
        // tạm list lưu memory để test
        private static List<Student> listStudents = new List<Student>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = Enum.GetValues(typeof(Branch)).Cast<Branch>().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                // trả lại view và hiển thị lỗi
                ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                ViewBag.AllBranches = Enum.GetValues(typeof(Branch)).Cast<Branch>().ToList();
                return View(student);
            }

            // nếu hợp lệ, gán Id & lưu tạm
            student.Id = (listStudents.LastOrDefault()?.Id ?? 0) + 1;
            listStudents.Add(student);

            return RedirectToAction("Index");
        }
    }
}

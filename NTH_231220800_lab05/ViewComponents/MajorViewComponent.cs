using Day_12_lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_12_lab1.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        SchoolContext db;
        List<Major> majors;
        public MajorViewComponent(SchoolContext context)
        {
            db = context;
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/_MajorViewComponent.cshtml", majors);
        }
    }
}

using Day_12_lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_12_lab1.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly List<MenuItem> menuItems;

        public RenderViewComponent()
        {
            menuItems = new List<MenuItem>()
            {
                new MenuItem() {Id=1, Name="List Student", Link="/Admin/Student/list" },
                new MenuItem() {Id=2, Name="Add Student", Link="/Admin/Student/add" },
                new MenuItem() {Id=3, Name="List Learners", Link="/Learners/Index" },
                new MenuItem() {Id=4, Name="Add Student", Link="/Learners/Create" },

            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/_leftMenu.cshtml", menuItems);
        }
    }
}

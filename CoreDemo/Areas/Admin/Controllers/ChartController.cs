using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass { CategoryName = "Teknoloji", CategoryCount = 3 });
            list.Add(new CategoryClass { CategoryName = "Yazılım", CategoryCount = 7 });
            list.Add(new CategoryClass { CategoryName = "Yazılım", CategoryCount = 12 });

            return Json(new {Jsonlist=list});
        }
    }
} 

using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters =JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                ID=1,
                Name="Emre"
            },
            new WriterModel
            {
                ID=2,
                Name="Ayşe"
            }
        };
    }
}

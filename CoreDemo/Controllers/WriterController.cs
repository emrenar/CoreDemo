using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }


        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {

            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {

            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();       
            var writerValues = wm.TGetById(writerID);   
            return View(writerValues);
        }

        
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            wm.TUpdate(p);
            return RedirectToAction("Index", "Dashboard");

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterAbout = p.WriterAbout;
            w.WriterStatus = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]

    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

       

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            nm.AddNewsLetter(p);
            return RedirectToAction("Index","Blog");
        }
    }
}

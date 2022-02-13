using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        BlogContext blogContext = new BlogContext();
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var writerName = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.wn = writerName;
            ViewBag.v = userMail;
            return View();
        }
        public IActionResult WriterProfile()
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
            var userMail = User.Identity.Name;
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var writerValues = writerManager.TGetById(writerID);
            ViewBag.Password = writerValues.WriterPasword;
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p, string passwordAgain, IFormFile WriterImageFile)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p);

            if (result.IsValid && p.WriterPasword == passwordAgain)
            {
                if (WriterImageFile != null)
                {
                    p.WriterImage = AddProfileImage.ImageAdd(WriterImageFile);
                }
                p.WriterStatus = true;
                writerManager.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else if (p.WriterPasword != passwordAgain)
            {
                ModelState.AddModelError("WriterPasword", "Girdiğiniz şifreler uyuşmuyor, tekrar deneyiniz.");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(Writer p, string passwordAgain, IFormFile WriterImageFile)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid && p.WriterPasword == passwordAgain)
            {
                if (WriterImageFile != null)
                {
                    p.WriterImage = AddProfileImage.ImageAdd(WriterImageFile);
                }
                p.WriterStatus = true;
                writerManager.TAdd(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else if (p.WriterPasword != passwordAgain)
            {
                ModelState.AddModelError("WriterPasword", "Girdiğiniz şifreler uyuşmuyor, tekrar deneyiniz.");
            }
            return View();
        }
    }
}

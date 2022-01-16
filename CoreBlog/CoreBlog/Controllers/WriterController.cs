using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreBlog.Models;
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
        public IActionResult Index()
        {
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValues = writerManager.TGetById(1);
            ViewBag.Password = writerValues.WriterPasword;
            return View(writerValues);
        }
        [AllowAnonymous]
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
            //Writer writer = new Writer();

            //if (p.WriterImage != null)
            //{
            //    var extension = Path.GetExtension(p.WriterImage.FileName);
            //    var newImageName = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
            //    var stream = new FileStream(location, FileMode.Create);
            //    p.WriterImage.CopyTo(stream);
            //    writer.WriterImage = newImageName;

            //}
            if (result.IsValid && p.WriterPasword == passwordAgain)
            {
                if (WriterImageFile != null)
                {
                    p.WriterImage = AddProfileImage.ImageAdd(WriterImageFile);
                }
                //writer.WriterMail = p.WriterMail;
                //writer.WriterName = p.WriterName;
                //writer.WriterPasword = p.WriterPasword;
                //writer.WriterAbout = p.WriterAbout;
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

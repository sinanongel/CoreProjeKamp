using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreBlog.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Cities cities = new Cities();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Cities = cities.GetCityList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p, string passwordAgain, string city)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid && p.WriterPasword == passwordAgain)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                writerManager.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
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
            ViewBag.Cities = cities.GetCityList();
            return View();
        }
    }
}

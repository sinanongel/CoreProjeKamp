using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer p)
        {
            BlogContext blogContext = new BlogContext();
            var dataValue = blogContext.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPasword == p.WriterPasword);
            if (dataValue != null)
            {
                HttpContext.Session.SetString("username", p.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }
}

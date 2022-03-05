using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = blogContext.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.AdminImage = blogContext.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.Description = blogContext.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.ToplamBlog = blogManager.GetList().Count();
            ViewBag.YeniMesaj = blogContext.Contacts.Count();
            ViewBag.YorumSayisi = blogContext.Comments.Count();
            return View();
        }
    }
}

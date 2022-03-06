using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            string api = "6c33954e472ac5526ce84f3196bf1c36";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}

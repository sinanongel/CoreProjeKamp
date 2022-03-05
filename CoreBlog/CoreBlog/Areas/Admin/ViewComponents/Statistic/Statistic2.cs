using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.SonEklenenBlog = blogContext.Blogs.OrderByDescending(y=>y.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.YorumSayisi = blogContext.Comments.Count();
            return View();
        }
    }
}

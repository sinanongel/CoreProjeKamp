using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname = "Teknoloji", categorycount = 10 });
            list.Add(new CategoryClass { categoryname = "Yazılım", categorycount = 14 });
            list.Add(new CategoryClass { categoryname = "Spor", categorycount = 5 });
            list.Add(new CategoryClass { categoryname = "Tiyatyo", categorycount = 2 });
            list.Add(new CategoryClass { categoryname = "Kitap", categorycount = 8 });
            return Json(new { jsonlist = list });
        }
    }
}

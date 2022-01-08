using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = writerManager.GetWriterByID(1);
            return View(values);
        }
    }
}

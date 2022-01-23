using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            //p = "deneme@gmail.com";
            var values = message2Manager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}

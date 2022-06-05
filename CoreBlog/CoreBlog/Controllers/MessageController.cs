using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        BlogContext blogContext = new BlogContext();
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.TGetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.TAdd(p);
            return RedirectToAction("Inbox");
        }
    }
}

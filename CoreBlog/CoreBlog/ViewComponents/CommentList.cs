using CoreBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Sinan"
                },
                new UserComment
                {
                    ID=2,
                    UserName="Yusuf"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Ebrar"
                }
            };
            return View(commentValues);
        }
    }
}

using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendboxMessageByWriter(int id)
        {
            using (var blogContext = new BlogContext())
            {
                return blogContext.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }

        public List<Message2> GetInboxMessageByWriter(int id)
        {
            using (var blogContext = new BlogContext())
            {
                return blogContext.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}

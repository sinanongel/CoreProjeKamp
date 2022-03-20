using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-5S4H6I7; database=CoreBlogDb; integrated security=true;");
            //optionsBuilder.UseSqlServer("server=DESKTOP-MMIU4VA; database=CoreBlogDb; integrated security=true;");
            optionsBuilder.UseSqlServer("server=songel\\SQLEXPRESS; database=CoreBlogApiDb; integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}

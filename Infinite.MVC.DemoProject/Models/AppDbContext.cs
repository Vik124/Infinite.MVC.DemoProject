using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Infinite.MVC.DemoProject.Models
{
    public class AppDbContext:DbContext

    {
        public AppDbContext() : base("MyCon")
        {

        }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<Breeds> Breeds { get; set; }

    
}
}
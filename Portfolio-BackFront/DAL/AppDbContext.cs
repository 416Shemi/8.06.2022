using Microsoft.EntityFrameworkCore;
using Portfolio_BackFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_BackFront.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Page1> page1s { get; set;}
        public DbSet<Page2> page2s { get; set; }
        public DbSet<Page3> page3s { get; set; }
    }
   
}

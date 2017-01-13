using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
        public string Image { get; set; }
    }

    public class PeopleDataDBContext : DbContext
    {
        public DbSet<People> People { get; set; }
    }

}
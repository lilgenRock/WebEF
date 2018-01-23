using System;
using System.Collections.Generic;
using System.Data.Entity;   // add this for DbContext
using System.Linq;
using System.Web;

namespace WebEF.Models
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base("name=PeopleDbContext")
        {

        }

        public DbSet<Person> people { get; set; }


    }
}
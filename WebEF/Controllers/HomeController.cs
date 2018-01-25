using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEF.Models; // add this to use PeopleDbContext

namespace WebEF.Controllers
{
    public class HomeController : Controller
    {
        PeopleDbContext db = new PeopleDbContext();

        // GET: Home
        public ActionResult Index()
        {
            List<Person> myList = db.people.ToList();
            return View(myList);
        }

        public ActionResult Create()
        {
            Person me = new Person();
            me.Name = "Bob";
            me.Age = 99;
            me.City = "LA";
            db.people.Add(me);  // Adds Bob to DB
            db.SaveChanges();   // saves the changes

            return RedirectToAction("Index");
        }
    }
}
/*
 * 
//// Web.Config

<connectionStrings>
    <add name="ConnectionName" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDbFile.mdf;Initial Catalog=MyDbFile;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>

//// DbContext

public class MyDBcontext : DbContext
    {
        public MyDBcontext () : base("ConnectionName")
	{ }

	//public DbSet<ExClass> ExClasses { get; set; }

    }

//// Package Manager Console

// For when you only have one DbContext
Enable-Migrations -EnableAutomaticMigrations

// For when you have more then one DbContext
Enable-Migrations -ContextTypeName AppName.Models.MyDbContext -MigrationsDirectory Migrations\MyDbContext

// For when you only have one DbContext
Update-Database

// If your changes of Class/Model might remove data from you Database
Update-Database -Force

// For when you have more then one Migrations Configuration
Update-Database -ConfigurationTypeName AppName.Migrations.MyDbContext.Configuration
 * */

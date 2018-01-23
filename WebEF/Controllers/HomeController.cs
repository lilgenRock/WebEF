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
            db.people.Add(me);  // Adds Bob to DB
            db.SaveChanges();   // saves the changes

            return RedirectToAction("Index");
        }
    }
}
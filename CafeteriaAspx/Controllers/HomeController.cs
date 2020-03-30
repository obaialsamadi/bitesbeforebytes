using CafeteriaAspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeteriaAspx.Controllers
{ //calling method to AppDB class to create the tables inside AppDB
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			
				//AppDB c = new AppDB();
				//c.Database.CreateIfNotExists();//creates the database tables if they do not exist

			return View();// this calls back the homepage
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
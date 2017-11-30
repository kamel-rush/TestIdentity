using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;// Identity 
using TestIdentity.Models;


namespace TestIdentity.Controllers
{   [Authorize]
    public class HomeController : Controller
    {   [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.UserId=User.Identity.GetUserId();

            ApplicationDbContext UserORM = new ApplicationDbContext();

            ApplicationUser CurrentUser=UserORM.Users.Find(User.Identity.GetUserId());

            ViewBag.FullName = CurrentUser.FirstName + " " + CurrentUser.LastName;

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
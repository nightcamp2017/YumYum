using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mail;
using YumYum.Models;
namespace YumYum.Controllers
{

    public class HomeController : Controller
    {
        YumYumEntities db = new YumYumEntities();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult CreateUser() {

            return View();

        }
        [HttpPost]
        public ActionResult Register( PersonModel personDetail, int id = 0)
        {

            return View();
        }
        public ActionResult LoginPage()
        {

            return View();
        }

        //This action log user in
        public ActionResult LoginFunction(string username, string password)
        {

            var LoginDetail = db.LogInDetails.Select(x=> ( new Login{ username = x.Username, password = x.Password })).ToList();
            foreach (var x in LoginDetail)
            {
                if (username == x.username)
                {
                    //if password matched
                    if (password == x.password)
                    {
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                    //if password do not match
                    else { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
                }
                //If user is not found
                else { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
            }
            return View();
           
           
        }

        public ActionResult UserDashboard() {
            return View();

        }
    }
}
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

        public ActionResult CreateUser()
        {

            return View();

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new PersonModel());
        }
        [HttpPost]
        public ActionResult Register(PersonModel personDetail, int id = 0)
        {
            //Using Jquery for this Action. Could have used Razor too (which ight be easier)
            //Check this website: http://stackoverflow.com/questions/20333021/asp-net-mvc-how-to-pass-data-from-view-to-controller
            // for more info on how to do with razor.
            var newRegister = new Person
            {
                FirstName = personDetail.FirstName,
                LastName = personDetail.LastName,
                Address1 = personDetail.Address1,
                Address2 = personDetail.Address2,
                PhoneNumber = personDetail.Phone,
                MobileNumber = personDetail.Mobile,
                EmailAddress = personDetail.Email,

               // DateOfBirth = personDetail.DOB.Now

            };
            if (newRegister.PersonId == 0)
            { newRegister.PersonId = 1; }
            db.People.Add(newRegister);
           
                db.SaveChanges();
            
            
      
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoginPage()
        {

            return View();
        }

        //This action log user in
        public ActionResult LoginFunction(string username, string password)
        {

            var LoginDetail = db.LogInDetails.Select(x => (new Login { username = x.Username, password = x.Password })).ToList();
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

        public ActionResult UserDashboard()
        {
            return View();

        }
    }
}
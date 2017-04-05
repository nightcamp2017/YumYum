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
        FoodList addedFoodObj = new FoodList();
        List<FoodList> addedFoodList = new List<FoodList>() ;
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult sf()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult CreateUser() {

        //    return View();

        //}
        //[HttpPost]
        //public ActionResult Register( PersonModel personDetail, int id = 0)
        //{

        //    return View();
        //}
        //public ActionResult LoginPage()
        //{

        //    return View();
        //}

        ////This action log user in
        //public ActionResult LoginFunction(string username, string password)
        //{

        //    var LoginDetail = db.LogInDetails.Select(x=> ( new Login{ username = x.Username, password = x.Password })).ToList();
        //    foreach (var x in LoginDetail)
        //    {
        //        if (username == x.username)
        //        {
        //            //if password matched
        //            if (password == x.password)
        //            {
        //                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //            }
        //            //if password do not match
        //            else { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        //        }
        //        //If user is not found
        //        else { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        //    }
        //    return View();


        //}

        //public ActionResult UserDashboard() {
        //    return View();

        //}
       
        public ActionResult FoodMenu()
        {
            //desplay food category
            var foodCategory = db.FoodTypes.Select(x => new FoodList
            {
                FoodCateId = x.FoodTypeId,
                FoodCate = x.FoodType1
            }).ToList();
             
             return View("FoodMenu",foodCategory);

        }

        public ActionResult GetFoodCate(int cateId)
        {
            // Join FoodType and FoodItem tables using FoodTypeId
            var foodjoin =
                from f in db.FoodTypes
                join it in db.FoodItems on f.FoodTypeId equals it.FoodTypeId
                select new
                {
                    cate = it.FoodTypeId,
                    id = it.FoodItemId,
                    name = it.FoodName,
                    detail = it.FoodDetail,
                    FoodType = f.FoodType1
                };
            //Search food list in each category
            var eachCateTemp = foodjoin.Where(x => x.cate == cateId).ToList();
           
            var eachCate = eachCateTemp.Select(x => new FoodList
            {
                FoodCateId = x.cate,
                FoodId = x.id,
                FoodName = x.name,
                FoodDetail =x.detail
            }).ToList();

            return View(eachCate);
        }
        public ActionResult AddOrder(int itemId, int meatId)
        {
            //Take customers' selection of food and meat type
            var selectedMeat = db.MeatTypes.Find(meatId);
            var selectedFood = db.FoodItems.Find(itemId);

            addedFoodObj.FoodCateId = selectedFood.FoodTypeId;
            addedFoodObj.FoodId = selectedFood.FoodItemId;
            addedFoodObj.FoodName = selectedFood.FoodName;
            addedFoodObj.MeatId = selectedMeat.MeatId;
            addedFoodObj.MeatOpt= selectedMeat.MeatType1.Trim();

            //set Pricing depending on category and meat type
            if (meatId == 1 || meatId == 2 || meatId == 3 || meatId == 5 && addedFoodObj.FoodCateId ==1 || addedFoodObj.FoodCateId ==3 || addedFoodObj.FoodCateId == 4)
            {
                addedFoodObj.PriceId = 1;
            }
            else
            {
                addedFoodObj.PriceId = 2;

                if (meatId == 1 || meatId == 2 || meatId == 3 || meatId == 5 && addedFoodObj.FoodCateId == 2 || addedFoodObj.FoodCateId == 5)
                {
                    addedFoodObj.PriceId = 3;
                }
                else
                {
                    addedFoodObj.PriceId = 4;
                }
            }
            //addedFoodList.Add(addedFoodObj);

            return Json(addedFoodObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveOrder(FoodList model)
        {
            //save order and update database
            var saveOrder = new OrderDetail();
            saveOrder.FoodItemId = model.FoodId;
            saveOrder.MeatTypeId = model.MeatId;
            saveOrder.SpicinessLevelId = model.HotId;
            saveOrder.Quantity = model.Quantity;
            saveOrder.PriceId = model.PriceId;
            var addedOrderDetail = db.OrderDetails.Add(saveOrder);
            db.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
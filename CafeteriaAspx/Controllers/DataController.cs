using CafeteriaAspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeteriaAspx.Controllers
{
    public class DataController : Controller
    {
        public IList<MenuItem> foodItems;
        // GET: Data
        //Signature for menu items so we can retrieve them, called GetMenuList
        [HttpGet]
        public ActionResult GetMenuList()
        {
            foodItems = new List<MenuItem>();
            using(var db = new AppDB())
            {//iterate through menu items add to fooditems list

                foreach(var f in db.MenuItems)
                {
                    foodItems.Add(f);
                }
            }
            return Json(foodItems, JsonRequestBehavior.AllowGet);
        }
        //signature for user Id who's viewing the menu
        [HttpGet]
        public string GetUserId()
        {
            
                int uid = -1; //intiatlize int var to -1
                if (Session["UserId"] != null)// if userid = null, if theyre signed in it wont be null
                    uid = Convert.ToInt32(Session["UserId"].ToString());
                return uid.ToString();//returns -1 of we are logged out, 1 if we are logged in
            

        }
        //signature for when user places an order: react app sends those orders in JSON format and talk to server
        //through this endpoint
        [HttpPost]
        public ActionResult PlaceOrder(IList<MenuItem> items, int id)
        {
            bool dbSuccess = false;
            try
            {
                using (var db = new AppDB())
                {
                    Order o = new Order();
                    o.UserId = id;
                    o.OrderDate = DateTime.Now;
                    //now add this order ^ to the orders table
                    db.Orders.Add(o);
                    db.SaveChanges();
                    //need order ID from database and save it
                    int orderId = o.Id;
                    decimal grandTotal = 0;
                    //now loop through food items and add to order details table
                    foreach (var f in items)
                    {   //initialize order detail object with these parameters
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = orderId,
                            FoodItemId = f.Id,
                            Quantity = f.Quantity,
                            TotalPrice = f.Price * f.Quantity,
                        };
                        db.OrderDetails.Add(orderDetail);
                        //keep track of amount to pay
                        grandTotal += orderDetail.TotalPrice;
                    }
                    o.TotalPaid = grandTotal;
                    o.Status = 1;
                    o.OrderDate = DateTime.Now;
                    db.SaveChanges();
                    dbSuccess = true;
                }
            } catch(Exception ex)
            { 
                dbSuccess = false;
            }
            if (dbSuccess)
                return Json("success:true", JsonRequestBehavior.AllowGet);
            else return Json("success:false", JsonRequestBehavior.AllowGet);
        }

    }
}
using midterm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace midterm2.Controllers
{
    public class UserController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, Customer c)
        {
            var name = collection["cus_name"];
            var password = collection["password"];
            var confirmpassword = collection["confirmpassword"];
            var address = collection["address"];
            var phone = collection["phone"];

            if (string.IsNullOrEmpty(confirmpassword))
            {
                ViewData["enterpassword"] = "Must enter password to confirm!";

            }
            else
            {
                if (!password.Equals(confirmpassword))
                {
                    ViewData["samepassword"] = "Password and confirmation password must be the same";
                }
                else
                {
                    c.cus_name = name;
                    c.password = password;
                    c.phone = phone;
                    c.address = address;

                    db.Customers.InsertOnSubmit(c);
                    db.SubmitChanges();

                    return RedirectToAction("Index", "Movies");
                }
            }

            return this.Register();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var phone = collection["phone"];
            var password = collection["password"];
            Customer c = db.Customers.SingleOrDefault(n => n.phone == phone && n.password == password);
            if (c != null)
            {
                ViewBag.Thongbao = "congratulations on successful login";
                Session["User"] = c;
                return RedirectToAction("Index", "ShowTime");
            }
            else
            {
                ViewBag.Thongbao = "Username or password is incorrect";
            }

            return this.Login();
        }















    }
}
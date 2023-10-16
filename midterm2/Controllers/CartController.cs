using midterm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midterm2.Controllers
{
    public class CartController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: Cart
        public List<Cart> getCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;

            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;

            }
            return lstCart;
        }


        public ActionResult AddCart(string id, string strURL)
        {
            List<Cart> lstCart = getCart();
            Cart product = lstCart.Find(n => n.show_id == id);
            if (product == null)
            {
                product = new Cart(id);
                lstCart.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.show_quantity++;
                return Redirect(strURL);
            }

        }


        private int SumQuantity()
        {
            int tsl = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tsl = lstCart.Sum(n => n.show_quantity);
            }
            return tsl;

        }

        private int sumProductQuantity()
        {
            int tsl = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tsl = lstCart.Count();
            }
            return tsl;
        }

        private double Total()
        {
            double tt = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                tt = lstCart.Sum(n => n.Total);
            }
            return tt;
        }


        public ActionResult Cart()
        {
            List<Cart> lstCart = getCart();
            ViewBag.SumQuantity = SumQuantity();
            ViewBag.Total = Total();
            ViewBag.sumProductQuantity = sumProductQuantity();
            return View(lstCart);
        }

        public ActionResult CartPartial()
        {
            ViewBag.SumQuantity = SumQuantity();
            ViewBag.Total = Total();
            ViewBag.sumProductQuantity = sumProductQuantity();
            return PartialView();
        }

        public ActionResult CartDelete(string id)
        {
            List<Cart> lstCart = getCart();
            Cart product = lstCart.SingleOrDefault(n => n.show_id == id);
            if (product != null)
            {
                lstCart.RemoveAll(n => n.show_id == id);
                return RedirectToAction("Cart");
            }
            return RedirectToAction("Cart");
        }

        public ActionResult CartUpdate(string id, FormCollection collection)
        {
            List<Cart> lstCart = getCart();
            Cart product = lstCart.SingleOrDefault(n => n.show_id == id);
            if (product != null)
            {
                product.show_quantity = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("Cart");
        }

        public ActionResult AllCartDelete()
        {
            List<Cart> lstCart = getCart();
            lstCart.Clear();
            return RedirectToAction("Cart");
        }

























    }
}
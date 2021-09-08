using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoping_Cart;
using Shoping_Cart.Models;


namespace Shoping_Cart.Controllers
{
    public class HomeController : Controller
    {
        myshopDBEntities1 db = new myshopDBEntities1();
        // GET: Home
        public ActionResult Index()
        {
            
            var p = db.tblproducts.ToList();
            ViewBag.p = p;

            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbluser usr)
        {
            myshopDBEntities1 obj = new myshopDBEntities1();
            var a = obj.tblusers.Where(l => l.uname.Equals(usr.uname) && l.upass.Equals(usr.upass)).FirstOrDefault();
            if (a != null)
            {
                Session["uname"] = usr.uname.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password!";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["uname"] == null)
            {
                ViewBag.msg = "Login First...!";
                return RedirectToAction("Adminindex");
            }
            return View();
        }


        public ActionResult cat(int id)
        {
           
            var p = db.tblproducts.Where(l => l.cid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.ToList();
            ViewBag.imgs = imgs;
            return View();
        }
        public ActionResult Pro(int id)
        {
            var p = db.tblproducts.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            var imgs = db.tblimages.Where(l => l.pid == id).ToList();
            ViewBag.imgs = imgs;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult cart()
        {
            ViewBag.c = ok.c;
            return View();
        }

        [HttpPost]

        public ActionResult cart(string pid,string pqty)
        {
            foreach(var item in ok.c)
            {
                if(item.iid == int.Parse(pid))
                {
                    item.iqty += int.Parse(pqty);
                    ViewBag.c = ok.c;
                    return View();
                }
                
            }
            cartitem i = new cartitem() {iid=int.Parse(pid),iqty=int.Parse(pqty)};
            ok.c.Add(i);
            ViewBag.c = ok.c;

            return View();
        }
        public ActionResult checkout()
        {
            return View();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoping_Cart;

namespace Shoping_Cart.Controllers
{
    public class ProductController : Controller
    {
        private myshopDBEntities1 db = new myshopDBEntities1();

        // GET: Product
        public ActionResult Index()
        {
            var tblproducts = db.tblproducts.Include(t => t.tblcategory);
            return View(tblproducts.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = db.tblproducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.tblcategories, "cid", "cname");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pid,pname,pprice,pdetails,cid")] tblproduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                db.tblproducts.Add(tblproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.tblcategories, "cid", "cname", tblproduct.cid);
            return View(tblproduct);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = db.tblproducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.tblcategories, "cid", "cname", tblproduct.cid);
            return View(tblproduct);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pid,pname,pprice,pdetails,cid")] tblproduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.tblcategories, "cid", "cname", tblproduct.cid);
            return View(tblproduct);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblproduct tblproduct = db.tblproducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblproduct tblproduct = db.tblproducts.Find(id);
            db.tblproducts.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: Insert Images function
        public ActionResult Images(int id)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pro = db.tblproducts.Where(l => l.pid == id).ToList(); //from table products
            if (pro == null) // if not found 
            {
                return HttpNotFound();
            }
            var imgs = db.tblimages.Where(l => l.pid == id).ToList();
            ViewBag.imgs = imgs;
            ViewBag.pro = pro;
            return View();
        }
        //now to submit image to the database after retreiving from Admin form input

        [HttpPost]
        public ActionResult Images(int id,HttpPostedFileBase file)
        {
            String path = System.IO.Path.Combine("~/Content/Images/" + file.FileName);
            file.SaveAs(Server.MapPath(path)); //image uploaded to the folder...

            tblimage obj = new tblimage(); //to store in the database so created and object
            obj.iname = file.FileName.ToString();
            obj.pid = id;
            db.tblimages.Add(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

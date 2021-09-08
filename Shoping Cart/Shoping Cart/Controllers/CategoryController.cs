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
    public class CategoryController : Controller
    {
        private myshopDBEntities1 db = new myshopDBEntities1();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.tblcategories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategories.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cid,cname")] tblcategory tblcategory)
        {
            if (ModelState.IsValid)
            {
                db.tblcategories.Add(tblcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcategory);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategories.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cid,cname")] tblcategory tblcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcategory);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcategory tblcategory = db.tblcategories.Find(id);
            if (tblcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblcategory);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblcategory tblcategory = db.tblcategories.Find(id);
            db.tblcategories.Remove(tblcategory);
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

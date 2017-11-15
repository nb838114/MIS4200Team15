using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricTeam15.DAL;
using CentricTeam15.Models;

namespace CentricTeam15.Controllers
{
    public class IgnitePassionForTheGreaterGoodsController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: IgnitePassionForTheGreaterGoods
        public ActionResult Index()
        {
            return View(db.IgnitePassionForTheGreaterGoods.ToList());
        }

        // GET: IgnitePassionForTheGreaterGoods/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood = db.IgnitePassionForTheGreaterGoods.Find(id);
            if (ignitePassionForTheGreaterGood == null)
            {
                return HttpNotFound();
            }
            return View(ignitePassionForTheGreaterGood);
        }

        // GET: IgnitePassionForTheGreaterGoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IgnitePassionForTheGreaterGoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood)
        {
            if (ModelState.IsValid)
            {
                ignitePassionForTheGreaterGood.ID = Guid.NewGuid();
                db.IgnitePassionForTheGreaterGoods.Add(ignitePassionForTheGreaterGood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ignitePassionForTheGreaterGood);
        }

        // GET: IgnitePassionForTheGreaterGoods/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood = db.IgnitePassionForTheGreaterGoods.Find(id);
            if (ignitePassionForTheGreaterGood == null)
            {
                return HttpNotFound();
            }
            return View(ignitePassionForTheGreaterGood);
        }

        // POST: IgnitePassionForTheGreaterGoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ignitePassionForTheGreaterGood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ignitePassionForTheGreaterGood);
        }

        // GET: IgnitePassionForTheGreaterGoods/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood = db.IgnitePassionForTheGreaterGoods.Find(id);
            if (ignitePassionForTheGreaterGood == null)
            {
                return HttpNotFound();
            }
            return View(ignitePassionForTheGreaterGood);
        }

        // POST: IgnitePassionForTheGreaterGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            IgnitePassionForTheGreaterGood ignitePassionForTheGreaterGood = db.IgnitePassionForTheGreaterGoods.Find(id);
            db.IgnitePassionForTheGreaterGoods.Remove(ignitePassionForTheGreaterGood);
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

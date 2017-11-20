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
    public class StriveToInnovatesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: StriveToInnovates
        public ActionResult Index()
        {
            return View(db.StriveToInnovates.ToList());
        }

        // GET: StriveToInnovates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StriveToInnovate striveToInnovate = db.StriveToInnovates.Find(id);
            if (striveToInnovate == null)
            {
                return HttpNotFound();
            }
            return View(striveToInnovate);
        }

        // GET: StriveToInnovates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StriveToInnovates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] StriveToInnovate striveToInnovate)
        {
            if (ModelState.IsValid)
            {
                striveToInnovate.ID = Guid.NewGuid();
                db.StriveToInnovates.Add(striveToInnovate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(striveToInnovate);
        }

        // GET: StriveToInnovates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StriveToInnovate striveToInnovate = db.StriveToInnovates.Find(id);
            if (striveToInnovate == null)
            {
                return HttpNotFound();
            }
            return View(striveToInnovate);
        }

        // POST: StriveToInnovates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] StriveToInnovate striveToInnovate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(striveToInnovate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(striveToInnovate);
        }

        // GET: StriveToInnovates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StriveToInnovate striveToInnovate = db.StriveToInnovates.Find(id);
            if (striveToInnovate == null)
            {
                return HttpNotFound();
            }
            return View(striveToInnovate);
        }

        // POST: StriveToInnovates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StriveToInnovate striveToInnovate = db.StriveToInnovates.Find(id);
            db.StriveToInnovates.Remove(striveToInnovate);
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

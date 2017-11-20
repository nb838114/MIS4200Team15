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
    public class InvestInAnExeptionalCulturesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: InvestInAnExeptionalCultures
        public ActionResult Index()
        {
            return View(db.InvestInAnExeptionalCultures.ToList());
        }

        // GET: InvestInAnExeptionalCultures/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestInAnExeptionalCulture investInAnExeptionalCulture = db.InvestInAnExeptionalCultures.Find(id);
            if (investInAnExeptionalCulture == null)
            {
                return HttpNotFound();
            }
            return View(investInAnExeptionalCulture);
        }

        // GET: InvestInAnExeptionalCultures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvestInAnExeptionalCultures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] InvestInAnExeptionalCulture investInAnExeptionalCulture)
        {
            if (ModelState.IsValid)
            {
                investInAnExeptionalCulture.ID = Guid.NewGuid();
                db.InvestInAnExeptionalCultures.Add(investInAnExeptionalCulture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investInAnExeptionalCulture);
        }

        // GET: InvestInAnExeptionalCultures/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestInAnExeptionalCulture investInAnExeptionalCulture = db.InvestInAnExeptionalCultures.Find(id);
            if (investInAnExeptionalCulture == null)
            {
                return HttpNotFound();
            }
            return View(investInAnExeptionalCulture);
        }

        // POST: InvestInAnExeptionalCultures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] InvestInAnExeptionalCulture investInAnExeptionalCulture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investInAnExeptionalCulture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investInAnExeptionalCulture);
        }

        // GET: InvestInAnExeptionalCultures/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestInAnExeptionalCulture investInAnExeptionalCulture = db.InvestInAnExeptionalCultures.Find(id);
            if (investInAnExeptionalCulture == null)
            {
                return HttpNotFound();
            }
            return View(investInAnExeptionalCulture);
        }

        // POST: InvestInAnExeptionalCultures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InvestInAnExeptionalCulture investInAnExeptionalCulture = db.InvestInAnExeptionalCultures.Find(id);
            db.InvestInAnExeptionalCultures.Remove(investInAnExeptionalCulture);
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

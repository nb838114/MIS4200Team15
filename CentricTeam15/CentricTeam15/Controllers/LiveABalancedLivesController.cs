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
    public class LiveABalancedLivesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: LiveABalancedLives
        public ActionResult Index()
        {
            return View(db.LiveABalancedLives.ToList());
        }

        // GET: LiveABalancedLives/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveABalancedLife liveABalancedLife = db.LiveABalancedLives.Find(id);
            if (liveABalancedLife == null)
            {
                return HttpNotFound();
            }
            return View(liveABalancedLife);
        }

        // GET: LiveABalancedLives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiveABalancedLives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] LiveABalancedLife liveABalancedLife)
        {
            if (ModelState.IsValid)
            {
                liveABalancedLife.ID = Guid.NewGuid();
                db.LiveABalancedLives.Add(liveABalancedLife);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liveABalancedLife);
        }

        // GET: LiveABalancedLives/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveABalancedLife liveABalancedLife = db.LiveABalancedLives.Find(id);
            if (liveABalancedLife == null)
            {
                return HttpNotFound();
            }
            return View(liveABalancedLife);
        }

        // POST: LiveABalancedLives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] LiveABalancedLife liveABalancedLife)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liveABalancedLife).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liveABalancedLife);
        }

        // GET: LiveABalancedLives/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiveABalancedLife liveABalancedLife = db.LiveABalancedLives.Find(id);
            if (liveABalancedLife == null)
            {
                return HttpNotFound();
            }
            return View(liveABalancedLife);
        }

        // POST: LiveABalancedLives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            LiveABalancedLife liveABalancedLife = db.LiveABalancedLives.Find(id);
            db.LiveABalancedLives.Remove(liveABalancedLife);
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

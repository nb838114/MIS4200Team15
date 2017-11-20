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
    public class EmbraceIntegrityAndOpennessesController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: EmbraceIntegrityAndOpennesses
        public ActionResult Index()
        {
            return View(db.EmbraceIntegrityAndOpennesses.ToList());
        }

        // GET: EmbraceIntegrityAndOpennesses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness = db.EmbraceIntegrityAndOpennesses.Find(id);
            if (embraceIntegrityAndOpenness == null)
            {
                return HttpNotFound();
            }
            return View(embraceIntegrityAndOpenness);
        }

        // GET: EmbraceIntegrityAndOpennesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmbraceIntegrityAndOpennesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness)
        {
            if (ModelState.IsValid)
            {
                embraceIntegrityAndOpenness.ID = Guid.NewGuid();
                db.EmbraceIntegrityAndOpennesses.Add(embraceIntegrityAndOpenness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(embraceIntegrityAndOpenness);
        }

        // GET: EmbraceIntegrityAndOpennesses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness = db.EmbraceIntegrityAndOpennesses.Find(id);
            if (embraceIntegrityAndOpenness == null)
            {
                return HttpNotFound();
            }
            return View(embraceIntegrityAndOpenness);
        }

        // POST: EmbraceIntegrityAndOpennesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(embraceIntegrityAndOpenness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(embraceIntegrityAndOpenness);
        }

        // GET: EmbraceIntegrityAndOpennesses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness = db.EmbraceIntegrityAndOpennesses.Find(id);
            if (embraceIntegrityAndOpenness == null)
            {
                return HttpNotFound();
            }
            return View(embraceIntegrityAndOpenness);
        }

        // POST: EmbraceIntegrityAndOpennesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EmbraceIntegrityAndOpenness embraceIntegrityAndOpenness = db.EmbraceIntegrityAndOpennesses.Find(id);
            db.EmbraceIntegrityAndOpennesses.Remove(embraceIntegrityAndOpenness);
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

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
    public class PracticeResponsibleStewardshipsController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: PracticeResponsibleStewardships
        public ActionResult Index()
        {
            return View(db.PracticeResponsibleStewardships.ToList());
        }

        // GET: PracticeResponsibleStewardships/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeResponsibleStewardship practiceResponsibleStewardship = db.PracticeResponsibleStewardships.Find(id);
            if (practiceResponsibleStewardship == null)
            {
                return HttpNotFound();
            }
            return View(practiceResponsibleStewardship);
        }

        // GET: PracticeResponsibleStewardships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PracticeResponsibleStewardships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,suggestion")] PracticeResponsibleStewardship practiceResponsibleStewardship)
        {
            if (ModelState.IsValid)
            {
                practiceResponsibleStewardship.ID = Guid.NewGuid();
                db.PracticeResponsibleStewardships.Add(practiceResponsibleStewardship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(practiceResponsibleStewardship);
        }

        // GET: PracticeResponsibleStewardships/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeResponsibleStewardship practiceResponsibleStewardship = db.PracticeResponsibleStewardships.Find(id);
            if (practiceResponsibleStewardship == null)
            {
                return HttpNotFound();
            }
            return View(practiceResponsibleStewardship);
        }

        // POST: PracticeResponsibleStewardships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,suggestion")] PracticeResponsibleStewardship practiceResponsibleStewardship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practiceResponsibleStewardship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practiceResponsibleStewardship);
        }

        // GET: PracticeResponsibleStewardships/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeResponsibleStewardship practiceResponsibleStewardship = db.PracticeResponsibleStewardships.Find(id);
            if (practiceResponsibleStewardship == null)
            {
                return HttpNotFound();
            }
            return View(practiceResponsibleStewardship);
        }

        // POST: PracticeResponsibleStewardships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PracticeResponsibleStewardship practiceResponsibleStewardship = db.PracticeResponsibleStewardships.Find(id);
            db.PracticeResponsibleStewardships.Remove(practiceResponsibleStewardship);
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

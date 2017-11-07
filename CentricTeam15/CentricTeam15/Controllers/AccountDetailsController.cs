﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricTeam15.DAL;
using CentricTeam15.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace CentricTeam15.Controllers
{
    public class AccountDetailsController : Controller
    {
        private AccountDetailsContext db = new AccountDetailsContext();

        // GET: AccountDetails
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
            return View(db.AccountDetails.ToList());
            }

            else
            {
                return View("Not Authorized");
            }
        }

        // GET: AccountDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // GET: AccountDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo")] AccountDetail ID)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                ID.ID = memberID;
                db.AccountDetails.Add(ID);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                return View("DuplicateUser");
                }
                }

            return View(ID);
        }

        // GET: AccountDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail user = db.AccountDetails.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);

            if (user.ID == memberID)
            {
            return View(user);
            }
            else
            {
            return View("NotAuthenticated");
            }

        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,bussinessUnit,title,hireDate,photo")] AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountDetail);
        }

        // GET: AccountDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            if (accountDetail == null)
            {
                return HttpNotFound();
            }
            return View(accountDetail);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountDetail accountDetail = db.AccountDetails.Find(id);
            db.AccountDetails.Remove(accountDetail);
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
  /*       public ActionResult Index(string searchString)
 {
var testusers = from u in db.AccountDetails select u;
         if (!String.IsNullOrEmpty(searchString))
    {
	testusers = testusers.Where(u => u.lastName.Contains(searchString)
|| u.firstName.Contains(searchString));
// if here, users were found so view them
	return View(testusers.ToList());
         }
      return View(db.AccountDetails.ToList());
    
 }
 */

    }

}


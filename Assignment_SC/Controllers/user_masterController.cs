﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_SC;

namespace Assignment_SC.Controllers
{
    [Authorize]
    public class user_masterController : Controller
    {
        private SC_demoEntities db = new SC_demoEntities();

        // GET: user_master
        public ActionResult Index()
        {
            return View(db.user_master.ToList());
        }

        // GET: user_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // GET: user_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email_id,Password,Mobile_no")] user_master user_master)
        {
            if (ModelState.IsValid)
            {
                db.user_master.Add(user_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_master);
        }

        // GET: user_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // POST: user_master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email_id,Password,Mobile_no")] user_master user_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_master);
        }

        // GET: user_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_master user_master = db.user_master.Find(id);
            if (user_master == null)
            {
                return HttpNotFound();
            }
            return View(user_master);
        }

        // POST: user_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_master user_master = db.user_master.Find(id);
            db.user_master.Remove(user_master);
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

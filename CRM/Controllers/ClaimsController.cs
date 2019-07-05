using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Data;
using CRM.Domain.Entities;

namespace CRM.Controllers
{
    public class ClaimsController : Controller
    {
        private Context db = new Context();

        // GET: Claims
        public ActionResult Index()
        {
            return View(db.Claims.ToList());
        }

        // GET: Claims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claims claims = db.Claims.Find(id);
            if (claims == null)
            {
                return HttpNotFound();
            }
            return View(claims);
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaimId,ClaimType,Status,ClaimSubject,Description,ClaimStartDate")] Claims claims)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(claims);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claims);
        }

        // GET: Claims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claims claims = db.Claims.Find(id);
            if (claims == null)
            {
                return HttpNotFound();
            }
            return View(claims);
        }

        // POST: Claims/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaimId,ClaimType,Status,ClaimSubject,Description,ClaimStartDate")] Claims claims)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claims).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claims);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claims claims = db.Claims.Find(id);
            if (claims == null)
            {
                return HttpNotFound();
            }
            return View(claims);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Claims claims = db.Claims.Find(id);
            db.Claims.Remove(claims);
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

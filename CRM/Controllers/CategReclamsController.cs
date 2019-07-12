using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Domain.Entities;
using CRM.Models;

namespace CRM.Controllers
{
    public class CategReclamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategReclams
        public ActionResult Index()
        {
            return View(db.CategReclams.ToList());
        }

        // GET: CategReclams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategReclam categReclam = db.CategReclams.Find(id);
            if (categReclam == null)
            {
                return HttpNotFound();
            }
            return View(categReclam);
        }

        // GET: CategReclams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategReclams/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategReclamId,ReclamCateg")] CategReclam categReclam)
        {
            if (ModelState.IsValid)
            {
                db.CategReclams.Add(categReclam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categReclam);
        }

        // GET: CategReclams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategReclam categReclam = db.CategReclams.Find(id);
            if (categReclam == null)
            {
                return HttpNotFound();
            }
            return View(categReclam);
        }

        // POST: CategReclams/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategReclamId,ReclamCateg")] CategReclam categReclam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categReclam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categReclam);
        }

        // GET: CategReclams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategReclam categReclam = db.CategReclams.Find(id);
            if (categReclam == null)
            {
                return HttpNotFound();
            }
            return View(categReclam);
        }

        // POST: CategReclams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategReclam categReclam = db.CategReclams.Find(id);
            db.CategReclams.Remove(categReclam);
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

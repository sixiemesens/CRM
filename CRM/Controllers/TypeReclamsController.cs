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
    public class TypeReclamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeReclams
        public ActionResult Index()
        {
            return View(db.TypeReclams.ToList());
        }

        // GET: TypeReclams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeReclam typeReclam = db.TypeReclams.Find(id);
            if (typeReclam == null)
            {
                return HttpNotFound();
            }
            return View(typeReclam);
        }

        // GET: TypeReclams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeReclams/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeReclamId,ReclamType")] TypeReclam typeReclam)
        {
            if (ModelState.IsValid)
            {
                db.TypeReclams.Add(typeReclam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeReclam);
        }

        // GET: TypeReclams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeReclam typeReclam = db.TypeReclams.Find(id);
            if (typeReclam == null)
            {
                return HttpNotFound();
            }
            return View(typeReclam);
        }

        // POST: TypeReclams/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeReclamId,ReclamType")] TypeReclam typeReclam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeReclam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeReclam);
        }

        // GET: TypeReclams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeReclam typeReclam = db.TypeReclams.Find(id);
            if (typeReclam == null)
            {
                return HttpNotFound();
            }
            return View(typeReclam);
        }

        // POST: TypeReclams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeReclam typeReclam = db.TypeReclams.Find(id);
            db.TypeReclams.Remove(typeReclam);
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

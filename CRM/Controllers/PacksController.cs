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
    public class PacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Packs
        public ActionResult Index()
        {
            var packs = db.Packs.Include(p => p.Offers);
            return View(packs.ToList());
        }

        // GET: Packs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packs packs = db.Packs.Find(id);
            if (packs == null)
            {
                return HttpNotFound();
            }
            return View(packs);
        }

        // GET: Packs/Create
        public ActionResult Create()
        {
            ViewBag.PacksId = new SelectList(db.Offers, "OffersId", "OfferName");
            return View();
        }

        // POST: Packs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacksId,PackPrice,PackName,PackStartDate,PackEndDate")] Packs packs)
        {
            if (ModelState.IsValid)
            {
                db.Packs.Add(packs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PacksId = new SelectList(db.Offers, "OffersId", "OfferName", packs.PacksId);
            return View(packs);
        }

        // GET: Packs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packs packs = db.Packs.Find(id);
            if (packs == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacksId = new SelectList(db.Offers, "OffersId", "OfferName", packs.PacksId);
            return View(packs);
        }

        // POST: Packs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacksId,PackPrice,PackName,PackStartDate,PackEndDate")] Packs packs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacksId = new SelectList(db.Offers, "OffersId", "OfferName", packs.PacksId);
            return View(packs);
        }

        // GET: Packs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packs packs = db.Packs.Find(id);
            if (packs == null)
            {
                return HttpNotFound();
            }
            return View(packs);
        }

        // POST: Packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Packs packs = db.Packs.Find(id);
            db.Packs.Remove(packs);
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

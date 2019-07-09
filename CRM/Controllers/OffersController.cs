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
    public class OffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offers
        public ActionResult Index()
        {
            var offers = db.Offers.Include(o => o.Packs);
            return View(offers.ToList());
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            ViewBag.OffersId = new SelectList(db.Packs, "PacksId", "PackName");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OffersId,OfferName,OfferPrice,OfferDescription,OfferStartDate,OfferEndDate")] Offers offers)
        {
            if (ModelState.IsValid)
            {
                db.Offers.Add(offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OffersId = new SelectList(db.Packs, "PacksId", "PackName", offers.OffersId);
            return View(offers);
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            ViewBag.OffersId = new SelectList(db.Packs, "PacksId", "PackName", offers.OffersId);
            return View(offers);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OffersId,OfferName,OfferPrice,OfferDescription,OfferStartDate,OfferEndDate")] Offers offers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OffersId = new SelectList(db.Packs, "PacksId", "PackName", offers.OffersId);
            return View(offers);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offers offers = db.Offers.Find(id);
            db.Offers.Remove(offers);
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

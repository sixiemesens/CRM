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
using CRM.Service;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CRM.Controllers
{
    public class ReclamationsController : Controller
    {
        ReclamationService RS = new ReclamationService();
     
        private ApplicationDbContext db = new ApplicationDbContext();

        //DataContract for Serializing Data - required to serve in JSON format
        [DataContract]
        public class DataPoint
        {
            public DataPoint(string label, double y)
            {
                this.Label = label;
                this.Y = y;
            }

            [DataMember(Name = "label")]
            public string Label = "";

            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }

        // GET: Reclamations
        public ActionResult Index()
        {

            List<DataPoint> data = new List<DataPoint>();

            //List<Reclamation> dataPoints = new List<Reclamation>();
            var reclamation = db.Reclamation.Include(r => r.CategReclam).Include(r => r.Customers).Include(r => r.TypeReclam);
              var dataPoints = reclamation.GroupBy(x => x.TypeReclam, x => x.Status , (groupKey, item) => new
                {
                    key = groupKey,
                    count=item.Count()
                }).ToList();

            //var DataPoints = dataPoints.ToList();
            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            foreach (var item in dataPoints)
            {
                data.Add(new DataPoint(item.key.ReclamType, item.count));
            }

            ViewBag.Statistique = JsonConvert.SerializeObject(data);

                        //Afficher nomre total de réclamation
            ViewBag.nb = RS.CountReclamation();

            return View(reclamation.ToList());
        }

        public ActionResult OrderByStatut()
        {
            var reclamationStatut = from r in db.Reclamation
                                    orderby r.Status ascending
                                    select r;
                return View(reclamationStatut);
        }

        //public ActionResult groupReclam()
        //{
        //    //List<Reclamation> group = new List<Reclamation>;
        //    var groupList = db.Reclamation
        //        .GroupBy(x => x.TypeReclam, x => x, (groupKey, item) => new
        //    {
        //        key = groupKey,
        //        item = item.ToList()
        //    }).ToList();

        //    return View(groupList.ToList());
        //}

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            List<Reclamation> lists = new List<Reclamation>();
            var reclamation = db.Reclamation.Include(r => r.CategReclam).Include(r => r.Customers).Include(r => r.TypeReclam);

            if (!String.IsNullOrEmpty(searchString))
            {
                lists = reclamation.ToList().Where(m => m.ReclamSubject.Contains(searchString)).ToList();
        }

            return View(lists);
        }


        // GET: Reclamations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = db.Reclamation.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // GET: Reclamations/Create
        public ActionResult Create()
        {
            ViewBag.CategReclamId = new SelectList(db.CategReclams, "CategReclamId", "ReclamCateg");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email");
            ViewBag.TypeReclamId = new SelectList(db.TypeReclams, "TypeReclamId", "ReclamType");
            return View();
        }

        // POST: Reclamations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReclamId,Status,ReclamSubject,Description,ReclamStartDate,CustomerId,TypeReclamId,CategReclamId")] Reclamation reclamation)
        {
            if (ModelState.IsValid)
            {
                db.Reclamation.Add(reclamation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategReclamId = new SelectList(db.CategReclams, "CategReclamId", "ReclamCateg", reclamation.CategReclamId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", reclamation.CustomerId);
            ViewBag.TypeReclamId = new SelectList(db.TypeReclams, "TypeReclamId", "ReclamType", reclamation.TypeReclamId);
            return View(reclamation);
        }

        // GET: Reclamations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = db.Reclamation.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategReclamId = new SelectList(db.CategReclams, "CategReclamId", "ReclamCateg", reclamation.CategReclamId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", reclamation.CustomerId);
            ViewBag.TypeReclamId = new SelectList(db.TypeReclams, "TypeReclamId", "ReclamType", reclamation.TypeReclamId);
            return View(reclamation);
        }

        // POST: Reclamations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReclamId,Status,ReclamSubject,Description,ReclamStartDate,CustomerId,TypeReclamId,CategReclamId")] Reclamation reclamation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategReclamId = new SelectList(db.CategReclams, "CategReclamId", "ReclamCateg", reclamation.CategReclamId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", reclamation.CustomerId);
            ViewBag.TypeReclamId = new SelectList(db.TypeReclams, "TypeReclamId", "ReclamType", reclamation.TypeReclamId);
            return View(reclamation);
        }

        // GET: Reclamations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = db.Reclamation.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // POST: Reclamations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamation reclamation = db.Reclamation.Find(id);
            db.Reclamation.Remove(reclamation);
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

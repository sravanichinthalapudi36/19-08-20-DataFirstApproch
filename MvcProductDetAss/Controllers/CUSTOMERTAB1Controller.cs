using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcProductDetAss;

namespace MvcProductDetAss.Controllers
{
    public class CUSTOMERTAB1Controller : Controller
    {
        private DotNetDataEntities db = new DotNetDataEntities();

        // GET: CUSTOMERTAB1
        public ActionResult Index()
        {
            var cUSTOMERTAB1 = db.CUSTOMERTAB1.Include(c => c.PRODUCTSTAB1);
            return View(cUSTOMERTAB1.ToList());
        }

        // GET: CUSTOMERTAB1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERTAB1 cUSTOMERTAB1 = db.CUSTOMERTAB1.Find(id);
            if (cUSTOMERTAB1 == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERTAB1);
        }

        // GET: CUSTOMERTAB1/Create
        public ActionResult Create()
        {
            ViewBag.produid = new SelectList(db.PRODUCTSTAB1, "produid", "produname");
            return View();
        }

        // POST: CUSTOMERTAB1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Custid,Custname,produid")] CUSTOMERTAB1 cUSTOMERTAB1)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERTAB1.Add(cUSTOMERTAB1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.produid = new SelectList(db.PRODUCTSTAB1, "produid", "produname", cUSTOMERTAB1.produid);
            return View(cUSTOMERTAB1);
        }

        // GET: CUSTOMERTAB1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERTAB1 cUSTOMERTAB1 = db.CUSTOMERTAB1.Find(id);
            if (cUSTOMERTAB1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.produid = new SelectList(db.PRODUCTSTAB1, "produid", "produname", cUSTOMERTAB1.produid);
            return View(cUSTOMERTAB1);
        }

        // POST: CUSTOMERTAB1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Custid,Custname,produid")] CUSTOMERTAB1 cUSTOMERTAB1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMERTAB1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produid = new SelectList(db.PRODUCTSTAB1, "produid", "produname", cUSTOMERTAB1.produid);
            return View(cUSTOMERTAB1);
        }

        // GET: CUSTOMERTAB1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERTAB1 cUSTOMERTAB1 = db.CUSTOMERTAB1.Find(id);
            if (cUSTOMERTAB1 == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERTAB1);
        }

        // POST: CUSTOMERTAB1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMERTAB1 cUSTOMERTAB1 = db.CUSTOMERTAB1.Find(id);
            db.CUSTOMERTAB1.Remove(cUSTOMERTAB1);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Concrete;

namespace BlindWalls.Controllers
{
    public class MuralsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Murals
        public ActionResult Index()
        {
            return View(db.Murals.ToList());
        }

        // GET: Murals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mural mural = db.Murals.Find(id);
            if (mural == null)
            {
                return HttpNotFound();
            }
            return View(mural);
        }

        // GET: Murals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Murals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuralId,MuralName,MuralDescription,ArtistID")] Mural mural)
        {
            if (ModelState.IsValid)
            {
                db.Murals.Add(mural);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mural);
        }

        // GET: Murals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mural mural = db.Murals.Find(id);
            if (mural == null)
            {
                return HttpNotFound();
            }
            return View(mural);
        }

        // POST: Murals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuralId,MuralName,MuralDescription,ArtistID")] Mural mural)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mural).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mural);
        }

        // GET: Murals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mural mural = db.Murals.Find(id);
            if (mural == null)
            {
                return HttpNotFound();
            }
            return View(mural);
        }

        // POST: Murals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mural mural = db.Murals.Find(id);
            db.Murals.Remove(mural);
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

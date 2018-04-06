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
using Domain.Entities;
using Domain.Abstract;
using BlindWalls.BusinessLogic.Manager;
using BlindWalls.Models;
using Domain.Entities;

namespace BlindWalls.Controllers
{
    public class MuralsController : Controller
    {
        private IMuralRepository muralRepository;
        private MuralManager muralManager;
        private int artistId;

        public MuralsController(IMuralRepository muralRepository)
        {
            this.muralRepository = muralRepository;
            muralManager = new MuralManager(muralRepository);
        }

        // GET: Murals
        public ActionResult Index()
        {
            //artistId = (int)TempData["artistId"];
            var muralList = muralManager.GetAllMurals();
            return View("Index", muralList);
        }

        // GET: Murals/Details/5
        public ActionResult Details(int id)
        {
            var mural = muralManager.GetMuralWithId(id);

            if (mural != null)
            {
                return View("MuralDetail");
            }
            
            return View();
        }

        
        // GET: Murals/Create
        public ActionResult Create()
        {
            return View("CreateMural");
        }

        // POST: Murals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuralName, MuralDescription, MuralLocation, ArtistID")] MuralModel model)
        {
            MuralBuilderInterface muralBuilder = new MuralBuilder();
            Mural mural = new Mural();
            model.ArtistId = (int)TempData["idArtist"];

            muralBuilder.buildArtistAccountWithRequiredParameters(model.MuralName, model.MuralDescription, model.ArtistId);
            muralBuilder.buildArtistWithOptionalParameters(model.MuralLocation);

            mural = muralBuilder.GetBuildedMural();

            return View(mural);
        }

        // GET: Murals/Edit/5
        public ActionResult Edit(int? id)
        {
           
            return View();
        }

        // POST: Murals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuralId,MuralName,MuralDescription,ArtistID")] Mural mural)
        {
        
            return View(mural);
        }

        // GET: Murals/Delete/5
        public ActionResult Delete(int? id)
        {
           
            return View();
        }

        // POST: Murals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}

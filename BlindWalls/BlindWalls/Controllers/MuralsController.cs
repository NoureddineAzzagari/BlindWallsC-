﻿using System;
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
using System.Security.Claims;

namespace BlindWalls.Controllers
{
    public class MuralsController : Controller
    {
        private IMuralRepository muralRepository;
        private MuralManager muralManager;
        public static LastViewedList lastviewedList = new LastViewedList();

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
                lastviewedList.Add(mural);   
                return View("Details", mural);
            }
            
            return View();
        }
        // GET: Murals/Lastviewed
        public ActionResult LastViewed()
        {
            var muralList = lastviewedList.getLastviewed();
            return View("LastViewed", muralList);
        }
        
        // GET: Murals/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Murals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuralName, MuralDescription, MuralLocation")] Mural model)
        {
            // Builder pattern doesnt seem to work however the artistID is properly added
            MuralBuilderInterface muralBuilder = new MuralBuilder();
            Mural mural = new Mural();

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            model.ArtistID = Int32.Parse(userId);

            muralBuilder.buildArtistAccountWithRequiredParameters(model.MuralName, model.MuralDescription);
            muralBuilder.buildArtistWithOptionalParameters(model.MuralLocation);

            mural = muralBuilder.GetBuildedMural();
            mural.ArtistID = model.ArtistID;
          //  mural.MuralDescription = model.MuralDescription;
         //   mural.MuralName = model.MuralName;

            muralRepository.InsertMural(mural);

            return View("Create", mural);
        }

        // GET: Murals/Edit/5
        public ActionResult Edit(int id)
        {
            Mural muraltoedit = muralManager.GetMuralWithId(id);
           
            return View("Edit", muraltoedit);
        }

        // POST: Murals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuralId,MuralName,MuralDescription,ArtistID")] Mural mural)
        {
            // add edit logic to manager and then put it here
            return View(mural);
        }

        // GET: Murals/Delete/5
        public ActionResult Delete(int id)
        {
            Mural muraltodelete = muralManager.GetMuralWithId(id);
            return View(muraltodelete);
        }

        // POST: Murals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            muralManager.DeleteMural(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}

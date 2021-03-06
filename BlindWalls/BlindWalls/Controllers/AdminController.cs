using BlindWalls.BusinessLogic.Manager;
using BlindWalls.Infrastructure;
using BlindWalls.Models;
﻿using BlindWalls.BusinessLogic.AOP;
using BlindWalls.BusinessLogic.Manager;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlindWalls.Controllers
{
    [Trace]
    public class AdminController : Controller
    {
        private IMuralRepository muralRepository;
        private IArtistRepository artistRepository;
        private AdminManager adminManager;
        Stats stats = Stats.GetSingleton();

        public AdminController(IMuralRepository muralRepository, IArtistRepository artistRepository)
        {
            this.muralRepository = muralRepository;
            this.artistRepository = artistRepository;
            adminManager = new AdminManager(muralRepository, artistRepository);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var muralList = adminManager.GetAllMurals();

            return View("Index", muralList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ArtistsOverview()
        {
            var artistList = adminManager.GetAllArtists();

            return View("ArtistsOverview", artistList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MuralsList(string searchStrategy, string searchParameter) 
        {
            var searchList = adminManager.GetAllMuralsWithSearchStrategy(searchParameter, searchStrategy);
            stats.addSearch();

            return View("Index", searchList);
        }

        // GET: Murals/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var mural = adminManager.GetMuralById(id);

            if (mural != null)
            {
                return View("Details", mural);

            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult StatsPage()
        {
            StatsModel statsmodel = new StatsModel();
            statsmodel.loggedIn = stats.amountUser();
            statsmodel.amountSearch = stats.amountSearched();

            return View("Stats", statsmodel);
        }
    }
}
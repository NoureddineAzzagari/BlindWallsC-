using BlindWalls.BusinessLogic.Manager;
using BlindWalls.Infrastructure;
using BlindWalls.Models;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlindWalls.Controllers
{
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

            return View("Index", searchList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult StatsPage()
        {
            StatsModel statsmodel = new StatsModel();
            statsmodel.LoggedIn = stats.amountUser();

            return View("Stats", statsmodel);
        }
    }
}
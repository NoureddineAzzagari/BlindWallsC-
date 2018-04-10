using BlindWalls.BusinessLogic;
using BlindWalls.Infrastructure;
using BlindWalls.Models;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BlindWalls.Controllers
{
    public class AuthController : Controller
    {
        private AuthManager authenticationManager;
        private IAccountRepository accountRepository;
        private IRoleRepository roleRepository;
        private IArtistRepository artistRepository;
        Stats stats = Stats.GetSingleton();
        
        public AuthController(IAccountRepository accountRepository, IRoleRepository roleRepository, IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
            authenticationManager = new AuthManager(accountRepository, roleRepository, artistRepository);
        }

       [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View("LogIn", model);
        }

        public ActionResult Login (LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }
            
            var account = authenticationManager.GetAccount(model.Username);
            var artist = authenticationManager.GetArtistWithAccountId(account.AccountID);
            

            if (authenticationManager.CheckAccountValidity(model.Username, model.Password))
            {
                var role = authenticationManager.GetAccount(model.Username).Role.RoleName;

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, artist.ArtistID.ToString()),
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, role.ToString())}, 
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                stats.addUser();

                authManager.SignIn(identity);
                
                return RedirectToAction("Index", "Murals");
            }

            ModelState.AddModelError("", "Uw gebruikersnaam of wachtwoord is onjuist of u heeft nog geen toegang tot het systeem.");
            return View("LogIn");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            stats.removeUser();

            return RedirectToAction("LogIn", "Auth");
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                accountRepository.InsertAccount(account);
                return RedirectToAction("LogIn", "Auth");
            }
            return View(account);
        }
    }
}
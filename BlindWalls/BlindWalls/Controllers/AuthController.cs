using BlindWalls.BusinessLogic;
using BlindWalls.Models;
using Domain.Abstract;
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
        private AuthManager authManager;
        private IArtistRepository artistRepository;
        
        public AuthController(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
            authManager = new AuthManager(artistRepository);
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

            if (authManager.CheckAccountValidity(model.Username, model.Password))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username)}, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
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
    }
}
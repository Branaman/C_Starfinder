using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using C_Starfinder.Models;
using C_Starfinder.Factories;
using Microsoft.AspNetCore.Identity;
namespace C_Starfinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController(UserFactory connect)
        {
            userFactory = connect;
        }
        // Home Route
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            ViewBag.errors = "";
            return View();
        }
        // Logout
        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        // Register new User
        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterUser NewUser)
        {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            NewUser.password = Hasher.HashPassword(NewUser, NewUser.password);
            ModelState.AddModelError("Registration",userFactory.AddUser(NewUser));
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        ViewBag.errors = ModelState.Values;
        return View("Index");
        }
        // Log in User
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginUser NewUser)
        {
        if (ModelState.IsValid)
        {
            LoginUser check = userFactory.GetUser(NewUser);
            var Hasher = new PasswordHasher<User>();
            if (check is LoginUser && (0 != Hasher.VerifyHashedPassword(check, check.password, NewUser.password)))
            {
                    HttpContext.Session.SetInt32("userID", check.idusers);
                    HttpContext.Session.SetString("loggedIn", "true");
                    return RedirectToAction("Index","Dash");    
            }
            ModelState.AddModelError("incorrectLogin","Incorrect Username or Password");
            ViewBag.errors = ModelState.Values;
            return View("Index");     
        }
        ViewBag.errors = ModelState.Values;
        return View("Index");
        }
    }
}

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
    public class DashController : Controller
    {
        private readonly UserFactory userFactory;
        public DashController(UserFactory connect)
        {
            userFactory = connect;
        }
        // Dash Route
        [HttpGet]
        [Route("/dash")]
        public IActionResult Index()
        {   
            ViewBag.errors = "";
            return View();
        }
    }
}

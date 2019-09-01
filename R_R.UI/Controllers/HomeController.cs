using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R_R.Common.Entities;
using R_R.Database.Services;
using R_R.UI.Models;

namespace R_R.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<R_RUser> _signInManager;
        


        public HomeController(SignInManager<R_RUser> signInManager)
        {
            _signInManager = signInManager;
         
        }
        public IActionResult Index()
        {
            

            
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/Account/Login", new {Area = "Identity"});
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

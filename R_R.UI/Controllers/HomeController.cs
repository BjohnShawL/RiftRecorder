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
        private readonly IUIReadService _uiRead;


        public HomeController(SignInManager<R_RUser> signInManager, IUIReadService _uiRead)
        {
            _signInManager = signInManager;
            this._uiRead = _uiRead;
        }
        public async Task<IActionResult> Index()
        {
            var uid = "131a96ae-32db-43a8-a866-d973b42b873c";

            var storyTags = (await _uiRead.GetStoryTags(1, uid, 2)).ToList();
            var notes = (await _uiRead.GetNotes(1,uid)).ToList();
            var games = (await _uiRead.GetGames(uid)).ToList();
            var characters = (await _uiRead.GetCharacter(uid,2));

            var concepts = (await _uiRead.GetConcepts(characters.ID)).ToList();

            
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

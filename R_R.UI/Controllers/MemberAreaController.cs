using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R_R.Common.Entities;
using R_R.Database.Services;

namespace R_R.UI.Controllers
{
    public class MemberAreaController : Controller
    {
        private readonly string _userId;
        private readonly UserManager<R_RUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUIReadService _db;

        public MemberAreaController(IHttpContextAccessor contextAccessor, UserManager<R_RUser> userManager, IMapper mapper, IUIReadService db)
        {
            _userManager = userManager;
            _mapper = mapper;
            _db = db;

            var user = contextAccessor.HttpContext.User;
            _userId = userManager.GetUserId(user);

        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Character()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Note()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StoryTag()
        {
            return View();
        }
    }
}
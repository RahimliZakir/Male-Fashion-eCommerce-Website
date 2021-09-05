using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity.Membership;
using MaleFashion.eCommerce.WebUI.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly FashionDbContext db;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public AccountController(FashionDbContext db, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignIn(SignInFormModel formModel)
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterFormModel formModel)
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {

            return View();
        }
    }
}

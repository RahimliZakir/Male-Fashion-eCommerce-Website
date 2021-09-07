using MaleFashion.eCommerce.WebUI.AppCode.Extensions;
using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity.Membership;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonalSideController : Controller
    {
        private readonly FashionDbContext db;

        public PersonalSideController(FashionDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            AppUser user = db.Users.FirstOrDefault(u => u.Id == User.GetUserId());

            return View(user);
        }
    }
}

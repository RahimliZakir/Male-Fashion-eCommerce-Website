using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using MaleFashion.eCommerce.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly FashionDbContext db;

        public BlogController(FashionDbContext db)
        {
            this.db = db;
        }

        [AllowAnonymous]
        public IActionResult Index(int pageIndex = 1, int pageSize = 9)
        {
            var data = db.Blogs.OrderBy(b => b.Id);

            var pagedViewModel = new PagedViewModel<Blog>(data, pageIndex, pageSize);

            return View(pagedViewModel);
        }
    }
}

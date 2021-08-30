using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using MaleFashion.eCommerce.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class BlogDetailsController : Controller
    {

        private readonly FashionDbContext db;

        public BlogDetailsController(FashionDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int? id)
        {
            BlogDetailsViewModel viewModel = new BlogDetailsViewModel();

            Blog blog = db.Blogs
                       .Include(a => a.Aphorism)
                       .FirstOrDefault(b => b.Id.Equals(id));

            viewModel.Blog = blog;

            viewModel.BlogDetailsTagsCollections = db.BlogDetailsTagsCollections
                                                   .Include(b => b.Blog)
                                                   .Where(bc => bc.Blog.Id == id)
                                                   .Include(t => t.Tags)
                                                   .ToList();

            foreach (var item in viewModel.BlogDetailsTagsCollections)
            {
                if (db.Tags.Any(t => t.Id == item.TagId))
                {
                    item.Tags = db.Tags.Where(t => t.Id == item.TagId).ToList();
                }
            }

            return View(viewModel);
        }
    }
}

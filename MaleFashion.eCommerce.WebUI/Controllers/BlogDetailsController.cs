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
            //viewModel.BlogDetailsTagsCollection = db.BlogDetailsTagsCollections
            //                                      .Include(b => b.Blog)
            //                                      .Include(t => t.Tag)
            //                                      .FirstOrDefault(b => b.BlogId == id);

            var collection = db.BlogDetailsTagsCollections.Include(bc => bc.Tag);

            var query = (from b in db.Blogs.Include(b => b.Aphorism)
                         join bc in collection on b.Id equals bc.BlogId
                         select new BlogDetailsViewModel
                         {

                             Id = b.Id,
                             Title = b.Title,
                             Description = b.Description,
                             ImagePath = b.ImagePath,
                             AphorismId = b.AphorismId,
                             AuthorImagePath = b.AuthorImagePath,
                             AuthorName = b.AuthorName,
                             AuthorSurname = b.AuthorSurname,
                             Content = b.Aphorism.Content,
                             Author = b.Aphorism.Author,
                             TagName = bc.Tag.TagName,
                             CreatedDate = b.CreatedDate
                         })
                     .AsQueryable();

            var data = query.ToList();

            return View(data);
        }
    }
}

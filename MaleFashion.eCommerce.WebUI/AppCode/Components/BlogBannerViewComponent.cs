using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using MaleFashion.eCommerce.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.AppCode.Components
{
    public class BlogBannerViewComponent : ViewComponent
    {
        private readonly FashionDbContext db;

        public BlogBannerViewComponent(FashionDbContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new BlogViewModel();

            viewModel.BlogBanner = db.BlogBanners.FirstOrDefault();

            return View(viewModel);
        }
    }
}

using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using MaleFashion.eCommerce.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class ShopController : Controller
    {
        readonly FashionDbContext db;

        public ShopController(FashionDbContext db)
        {
            this.db = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //IEnumerable<ProductMainCollection> productCollecion = db.ProductMainCollections
            //                                                      .Include(p => p.Product)
            //                                                      .Include(ca => ca.Category)
            //                                                      .Include(co => co.Color)
            //                                                      .Include(s => s.Size)
            //                                                      .Include(pt => pt.ProductTag)
            //                                                      .Include(pb => pb.Product.Brand)
            //                                                      .Include(pi => pi.Product.ProductImages);

            //DateTime dt = DateTime.UtcNow.AddHours(4).AddDays(20);

            //IEnumerable<ProductCampaignCollection> campaignCollection = db.ProductCampaignCollections
            //                                                            .Include(pc => pc.Campaign)
            //                                                            .Where(pc => pc.Campaign.IsApproved && pc.Campaign.ExpiredDate > dt);

            //IQueryable<DiscountProductViewModel> query = (from p in productCollecion
            //                                              join cp in campaignCollection on p.Id equals cp.ProductCollectionId
            //                                              into pcp
            //                                              from pcp_item in pcp.DefaultIfEmpty()
            //                                              select new DiscountProductViewModel
            //                                              {
            //                                                  Id = p.Id,
            //                                                  Title = p.Product.Title,
            //                                                  Description = p.Product.Description,
            //                                                  Brand = p.Product.Brand.BrandName,
            //                                                  Price = p.Product.Price,
            //                                                  PriceNew = pcp_item.PriceNew == null ? null : pcp_item.PriceNew,
            //                                                  CampaignTitle = pcp_item.Campaign.Title,
            //                                                  CampaignDescription = pcp_item.Campaign.Description,
            //                                                  Discount = pcp_item.Campaign.Discount != 0 ? null : pcp_item.Campaign.Discount,
            //                                                  ProductImages = p.Product.ProductImages,
            //                                                  Colors = db.Colors.ToList(),
            //                                                  Sizes = db.Sizes.ToList(),
            //                                                  Categories = db.Categories.ToList(),
            //                                                  ProductTags = db.ProductTags.ToList()
            //                                              })
            //                                              .AsQueryable();

            //IEnumerable<DiscountProductViewModel> data =  query.ToList();

            //return View(data);

            return View();
        }
    }
}

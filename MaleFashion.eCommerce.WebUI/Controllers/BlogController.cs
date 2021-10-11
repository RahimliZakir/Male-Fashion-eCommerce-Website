using MaleFashion.eCommerce.WebUI.AppCode.Extensions;
using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using MaleFashion.eCommerce.WebUI.Models.Entity.Membership;
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
            var data = db.Blogs.Include(l => l.Likes).Include(u => u.Unlikes).OrderBy(b => b.Id);

            // Limited Paged ViewModel
            var pagedViewModel = new PagedViewModel<Blog>(data, pageIndex, pageSize);

            return View(pagedViewModel);
        }

        [HttpPost]
        [Authorize]
        async public Task<IActionResult> Like(int blogId)
        {
            AppUser currentUser = await db.Users.FirstOrDefaultAsync(u => u.Id == User.GetUserId());
            int currentUserId = User.GetUserId();

            if (db.Unlikes.Any(u => u.UserId == currentUserId && u.BlogId == blogId))
            {
                Unlike currentUnlike = await db.Unlikes.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == currentUserId && u.BlogId == blogId);
                db.Unlikes.Remove(currentUnlike);
                await db.SaveChangesAsync();
            }

            if (!db.Likes.Any(l => l.UserId == currentUserId && l.BlogId == blogId))
            {
                var like = new Like
                {
                    BlogId = blogId,
                    UserId = currentUserId
                };

                try
                {
                    await db.Likes.AddAsync(like);
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Xeta bash verdi, bir neche-deqiqeden sonra yeniden yoxlayin!"
                    });
                }
            }

            return Json(new
            {
                error = false,
                likeCount = db.Likes.Count(l => l.BlogId == blogId),
                unlikeCount = db.Unlikes.Count(l => l.BlogId == blogId)
            });
        }

        [HttpPost]
        [Authorize]
        async public Task<IActionResult> Unlike(int id)
        {
            AppUser currentUser = await db.Users.FirstOrDefaultAsync(u => u.Id == User.GetUserId());
            int currentUserId = User.GetUserId();

            if (db.Likes.Any(u => u.UserId == currentUserId && u.BlogId == id))
            {
                Like currentLike = await db.Likes.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == currentUserId && u.BlogId == id);
                db.Likes.Remove(currentLike);
                await db.SaveChangesAsync();
            }

            if (!db.Unlikes.Any(u => u.UserId == currentUserId && u.BlogId == id))
            {
                var unlike = new Unlike
                {
                    BlogId = id,
                    UserId = currentUserId
                };

                try
                {
                    await db.Unlikes.AddAsync(unlike);
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Xeta bash verdi, bir neche-deqiqeden sonra yeniden yoxlayin!"
                    });
                }
            }

            return Json(new
            {
                error = false,
                unlikeCount = db.Unlikes.Count(l => l.BlogId == id),
                likeCount = db.Likes.Count(l => l.BlogId == id)
            });
        }
    }
}

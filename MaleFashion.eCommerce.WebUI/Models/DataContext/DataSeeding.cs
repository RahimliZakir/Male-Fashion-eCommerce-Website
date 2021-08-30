using MaleFashion.eCommerce.WebUI.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.DataContext
{
    public static class DataSeeding
    {
        public static IApplicationBuilder DataSeed(this IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                FashionDbContext db = scope.ServiceProvider.GetRequiredService<FashionDbContext>();

                db.Database.Migrate();

                if (!db.AppInfos.Any())
                {
                    db.AppInfos.Add(new AppInfo
                    {
                        HeaderLogoPath = "download.webp",
                        FooterLogoPath = "download (1).webp",
                        Description = " The customer is at the heart of our unique business model, which includes design.",
                        CardsLogoPath = "xpayment.png.pagespeed.ic.baCZTAO1zx.webp",
                        ContactTitle = "NEWLETTER",
                        ContactDescription = " Be the first to know about new arrivals, look books, sales & promos!",
                        FooterSiteInfo = @"<p>
                Copyright ©
                <script>
                  document.write(new Date().getFullYear());
                </script>
                2021 2020 All rights reserved | This template is made with
                <i class='fa fa-heart-o' aria-hidden='true'></i> 
                by
                <a href = 'https://colorlib.com/' target = '_blank'>Colorlib</a>
              </p>"
                    });

                    db.SaveChanges();
                }

                if (!db.Aphorisms.Any())
                {
                    db.Aphorisms.Add(new Aphorism
                    {
                        Content = @"“When designing an advertisement for a particular product many
                                  things should be researched like where it should be
                                  displayed.”",
                        Author = "John Smith"
                    });

                    db.Aphorisms.Add(new Aphorism
                    {
                        Content = @"“It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, 
                                  to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, 
                                  injected humour, or non-characteristic words etc.”",
                        Author = "Max Maxwell"
                    });

                    db.Aphorisms.Add(new Aphorism
                    {
                        Content = @"“The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from 'de Finibus Bonorum et Malorum' 
                                  by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.”",
                        Author = "Mark Clausenberg"
                    });

                    db.SaveChanges();
                }

                if (db.BlogBanners.Any() == false)
                {
                    db.BlogBanners.Add(new BlogBanner
                    {
                        ImagePath = "breadcrumb-bg.jpg"
                    });
                }

                if (db.Blogs.Any() != true)
                {
                    db.Blogs.Add(new Blog
                    {
                        Title = "What Curling Irons Are The Best Ones",
                        Description = @"<p>
                  Hydroderm is the highly desired anti - aging cream on the block.
                  This serum restricts the occurrence of early aging sings on
                  the skin and keeps the skin younger,
                        tighter and healthier.It
                  reduces the wrinkles and loosening of skin.This cream
                  nourishes the skin and brings back the glow that had lost in
                  the run of hectic years.
                </p>
                <p>
                  The most essential ingredient that makes hydroderm so
                  effective is Vyo - Serum,
                        which is a product of natural selected
                  proteins.This concentrate works actively in bringing about
                  the natural youthful glow of the skin.It tightens the skin
                  along with its moisturizing effect on the skin.The other
                  important ingredient,
                        making hydroderm so effective is “marine
                  collagen” which along with Vyo - Serum helps revitalize the
                  skin.
                </p>",
                        ImagePath = "blog-1.jpg",
                        AphorismId = 1,
                        AuthorImagePath = "author.jfif",
                        AuthorName = "Zakir",
                        AuthorSurname = "Rəhimli"
                    });

                    db.Blogs.Add(new Blog
                    {
                        Title = "Eternity Bands Do Last Forever",
                        Description = @"<p>
                  Hydroderm is the highly desired anti - aging cream on the block.
                  This serum restricts the occurrence of early aging sings on
                  the skin and keeps the skin younger,
                        tighter and healthier.It
                  reduces the wrinkles and loosening of skin.This cream
                  nourishes the skin and brings back the glow that had lost in
                  the run of hectic years.
                </p>
                <p>
                  The most essential ingredient that makes hydroderm so
                  effective is Vyo - Serum,
                        which is a product of natural selected
                  proteins.This concentrate works actively in bringing about
                  the natural youthful glow of the skin.It tightens the skin
                  along with its moisturizing effect on the skin.The other
                  important ingredient,
                        making hydroderm so effective is “marine
                  collagen” which along with Vyo - Serum helps revitalize the
                  skin.
                </p>",
                        ImagePath = "blog-2.jpg",
                        AphorismId = 2,
                        AuthorImagePath = "author.jfif",
                        AuthorName = "Zakir",
                        AuthorSurname = "Rəhimli"
                    });

                    db.Blogs.Add(new Blog
                    {
                        Title = "The Health Benefits Of Sunglasses",
                        Description = @"<p>
                  Hydroderm is the highly desired anti - aging cream on the block.
                  This serum restricts the occurrence of early aging sings on
                  the skin and keeps the skin younger,
                        tighter and healthier.It
                  reduces the wrinkles and loosening of skin.This cream
                  nourishes the skin and brings back the glow that had lost in
                  the run of hectic years.
                </p>
                <p>
                  The most essential ingredient that makes hydroderm so
                  effective is Vyo - Serum,
                        which is a product of natural selected
                  proteins.This concentrate works actively in bringing about
                  the natural youthful glow of the skin.It tightens the skin
                  along with its moisturizing effect on the skin.The other
                  important ingredient,
                        making hydroderm so effective is “marine
                  collagen” which along with Vyo - Serum helps revitalize the
                  skin.
                </p>",
                        ImagePath = "blog-3.jpg",
                        AphorismId = 1,
                        AuthorImagePath = "author.jfif",
                        AuthorName = "Zakir",
                        AuthorSurname = "Rəhimli"
                    });

                    db.SaveChanges();
                }

                if (db.Tags.Any() != true)
                {
                    db.Tags.Add(new Tag
                    {
                        TagName = "2020"
                    });

                    db.Tags.Add(new Tag
                    {
                        TagName = "Fashion"
                    });

                    db.Tags.Add(new Tag
                    {
                        TagName = "Lifestyle"
                    });

                    db.Tags.Add(new Tag
                    {
                        TagName = "Brand"
                    });

                    db.Tags.Add(new Tag
                    {
                        TagName = "New"
                    });

                    db.Tags.Add(new Tag
                    {
                        TagName = "Latest"
                    });

                    db.SaveChanges();
                }

                if (db.BlogDetailsTagsCollections.Any() == false)
                {
                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 1,
                        TagId = 1
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 1,
                        TagId = 2
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 1,
                        TagId = 3
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 2,
                        TagId = 4
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 2,
                        TagId = 5
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 2,
                        TagId = 6
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 3,
                        TagId = 3
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 3,
                        TagId = 4
                    });

                    db.BlogDetailsTagsCollections.Add(new BlogDetailsTagsCollection
                    {
                        BlogId = 3,
                        TagId = 6
                    });
                    db.SaveChanges();
                }
            }

            return app;
        }
    }
}

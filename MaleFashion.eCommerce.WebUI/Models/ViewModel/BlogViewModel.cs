using MaleFashion.eCommerce.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.ViewModel
{
    public class BlogViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }

        public BlogBanner BlogBanner { get; set; }
    }
}

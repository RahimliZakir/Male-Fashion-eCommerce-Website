using MaleFashion.eCommerce.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.ViewModel
{
    public class BlogDetailsViewModel
    {
        public Blog Blog { get; set; }

        public IEnumerable<BlogDetailsTagsCollection> BlogDetailsTagsCollections { get; set; }
    }
}

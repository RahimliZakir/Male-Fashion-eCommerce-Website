using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.Entity
{
    public class StarRating : BaseEntity
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

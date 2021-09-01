using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.Entity
{
    public class ProductMainCollection
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public int ProductTagId { get; set; }

        public virtual ProductTag ProductTag { get; set; }
    }
}

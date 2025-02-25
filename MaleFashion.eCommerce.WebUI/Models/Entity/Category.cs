﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual  ICollection<ProductMainCollection> ProductMainCollections { get; set; }
    }
}

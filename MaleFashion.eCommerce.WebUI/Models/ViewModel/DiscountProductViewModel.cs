using MaleFashion.eCommerce.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.ViewModel
{
    public class DiscountProductViewModel
    {
        public ProductMainCollection ProductMainCollection { get; set; }

        public ProductCampaignCollection ProductCampaignCollection { get; set; }
    }
}

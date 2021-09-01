using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Models.FormModel
{
    public class SubsFormModel
    {
        [Required(ErrorMessage = "Xahiş olunur mailinizi daxil edin!")]
        public string Email { get; set; }
    }
}

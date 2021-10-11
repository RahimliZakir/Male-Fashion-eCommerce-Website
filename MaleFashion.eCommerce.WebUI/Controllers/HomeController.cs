using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            // TempData Data Transfer To Contact Controller's Index Action
            List<int> numbers = new List<int>() { 13, 23, 77, 93 };

            TempData["Data"] = JsonConvert.SerializeObject(numbers);
            // TempData Data Transfer To Contact Controller's Index Action

            CookieOptions options = new CookieOptions();
            options.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(13)); ;
            HttpContext.Response.Cookies.Append("Welcome - Cookie", "TRUE", options);

            HttpContext.Session.SetInt32("Welcome - Session", 13);

            return View();
        }
    }
}

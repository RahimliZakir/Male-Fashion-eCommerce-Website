﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class ChatController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}

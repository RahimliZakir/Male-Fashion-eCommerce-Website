using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Controllers
{
    public class SubsController : Controller
    {
        private readonly IConfiguration conf;

        public SubsController(IConfiguration conf)
        {
            this.conf = conf;
        }

        [HttpPost]
        public IActionResult Index(string subsMail)
        {
            SmtpClient client = new SmtpClient()
            {
                Port = 25,
                Host = "smtp.mail.ru",
                EnableSsl = true
            };

            client.Credentials = new NetworkCredential(conf["SubsSMTP:FromMail"], conf["SubsSMTP:Pwd"]);

            MailMessage message = new MailMessage(conf["SubsSMTP:FromMail"], subsMail);
            message.Subject = conf.GetValue<string>("SubsSMTP:Title");
            message.Body = conf.GetValue<string>("SubsSMTP:Description");

            client.Send(message);

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}

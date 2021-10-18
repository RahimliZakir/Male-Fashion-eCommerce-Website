using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly FashionDbContext db;

        public SubsController(IConfiguration conf, FashionDbContext db)
        {
            this.conf = conf;
            this.db = db;
        }

        [HttpPost]
        [AllowAnonymous]
        async public Task<IActionResult> Index(string subsMail)
        {
            Subscription subscription = await db.Subscriptions.FirstOrDefaultAsync(s => s.Email.Equals(subsMail));

            if (subscription != null)
            {

            }
            else
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

                try
                {
                    client.Send(message);

                    return Json(new
                    {
                        error = false,
                        message = "Müvəffəqiyyətlə bizim abunəliyimizə qoşuldunuz, həmçinin mail ünvanınıza təsdiq mesajı göndərildi!"
                    });
                }
                catch (Exception)
                {
                    return Json(new
                    {
                        error = false,
                        message = "Xəta baş verdi, biraz sonra yenidən cəhd edin!"
                    });
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}

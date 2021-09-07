using MaleFashion.eCommerce.WebUI.AppCode.Extensions;
using MaleFashion.eCommerce.WebUI.Areas.Admin.Models.FormModel;
using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly FashionDbContext db;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration conf;

        public AccountController(FashionDbContext db, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration conf)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.conf = conf;
        }

        async public Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index), "Home", new
            {
                area = ""
            });
        }

        public IActionResult ChangeOrForgotPassword()
        {

            return View();
        }

        [HttpPost]
        async public Task<IActionResult> ChangeOrForgotPassword(ChangeOrForgotPasswordFormModel formModel)
        {
            string email = formModel.Email;

            AppUser userResult = await db.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

            if (userResult == null)
            {
                TempData["EmailUser"] = "Daxil etdiyiniz mail üzrə istifadəçimiz yoxdur!";
            }
            else
            {
                string token = await userManager.GeneratePasswordResetTokenAsync(userResult);

                string url = Url.Action("ResetPassword", "Account", values: new
                {
                    email = email,
                    token = token
                }, Request.Scheme);

                SmtpClient client = new SmtpClient()
                {
                    Port = 25,
                    Host = "smtp.mail.ru",
                    EnableSsl = true
                };

                client.Credentials = new NetworkCredential(conf["SubsSMTP:FromMail"], conf["SubsSMTP:Pwd"]);

                MailMessage message = new MailMessage(conf["SubsSMTP:FromMail"], email);
                message.Subject = "Şifrə yeniləmə linki.";
                message.Body = $"Bu <a href={url}>linkə</a> click edərək keçid linkinə yollana bilərsiniz!";

                client.Send(message);

                Thread.Sleep(2000);

                return RedirectToAction(nameof(ChangeOrForgotPasswordSent));
            }

            return View();
        }

        public IActionResult ChangeOrForgotPasswordSent()
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                ModelState.AddModelError("ResetError", "Xəta baş verdi!");

                //return NotFound();
            }
            else
            {
                ResetPasswordFormModel formModel = new ResetPasswordFormModel();

                formModel.Email = email;
                formModel.Token = token;

                return View(formModel);
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        async public Task<IActionResult> ResetPassword(ResetPasswordFormModel formModel)
        {
            AppUser userResult = await db.Users.FirstOrDefaultAsync(u => u.Email.Equals(formModel.Email));

            string token = formModel.Token;

            IdentityResult tokenResult = await userManager.ResetPasswordAsync(userResult, token, formModel.Password);

            if (tokenResult.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordSent));
            }
            else
            {
                foreach (IdentityError error in tokenResult.Errors)
                {
                    ModelState.AddModelError("ResetPasswordPostError", error.Description);
                }
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordSent()
        {

            return View();
        }
    }
}

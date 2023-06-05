﻿using EasyCashIdentity.DTOLayer.Dtos.AppUserDtos;
using EasyCashIdentity.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if(ModelState.IsValid) 
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "Istanbul",
                    District = "Istanbul",
                    ImageUrl = "Profile",
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
                if (result.Succeeded) 
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "onurabdulaji@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayit Islemini Gerceklestirmek Icin Onay Kodunuz : " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    // Mail Transfer Protocol
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587 , false);
                    client.Authenticate("onurabdulaji@gmail.com", "vibjobkhdjllvcle");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    return RedirectToAction("Index" , "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}

// Password Format
// 6 Karakter
// 1 Kucuk Harf
// 1 Buyuk Harf
// 1 Sembol
// 1 Sayi
// Password Format

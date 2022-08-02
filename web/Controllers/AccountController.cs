using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using web.EmailService;
using web.Identity;
using web.Models;

namespace web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        private SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult girisyap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> girisyap(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Eposta);
            if (user == null)
            {
                ModelState.AddModelError("", "E-posta adresi veya şifre yanlış");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Giriş yapabilmek için e-posta adresinizi onaylamalısınız");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Sifre, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            ModelState.AddModelError("", "E-posta adresi veya şifre yanlış");
            return View(model);
        }
        public IActionResult kayitol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> kayitol(KayitOlModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Cinsiyet == "Seçiniz")
            {
                ModelState.AddModelError("", "Cinsiyet seçiniz");
                return View(model);
            }
            if (model.MedeniDurum == "Seçiniz")
            {
                ModelState.AddModelError("", "Medeni durum seçiniz");
                return View(model);
            }
            if (model.KanGrubu == 0)
            {
                ModelState.AddModelError("", "Kan grubu seçiniz");
                return View(model);
            }
            if (model.Sehir == "Seçiniz")
            {
                ModelState.AddModelError("", "Sehir seçiniz");
                return View(model);
            }
            if (model.Ilce == "Seçiniz")
            {
                ModelState.AddModelError("", "İlçe seçiniz");
                return View(model);
            }

            // Email kontrolü
            var checkEmail = await _userManager.FindByEmailAsync(model.Eposta);
            if (checkEmail != null)
            {
                ModelState.AddModelError("", "Bu e-posta adresi daha önce kullanılmış");
                return View(model);
            }

            var user = new User
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Cinsiyet = model.Cinsiyet,
                PhoneNumber = model.Telefon,
                Tc = model.Tc,
                Email = model.Eposta,
                MedeniDurum = model.MedeniDurum,
                KanGrubu = model.KanGrubu,
                Sehir = model.Sehir,
                Ilce = model.Ilce,
                Adres = model.Adres,
                UserName = model.Eposta
            };

            var result = await _userManager.CreateAsync(user, model.Sifre);
            if (result.Succeeded)
            {
                //Generate token
                var newToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("epostaonay", "account", new
                {
                    userId = user.Id,
                    token = newToken
                });
                await _emailSender.SendEmailAsync(model.Eposta, "Hesabınızı onaylayın", $"Hesabınızı onaylamak için <a href='http://localhost:5001{url}'>tıklayın</a>");

                CreateAlert("Hesabınız oluşturuldu", "Kaydınızın tamamlanması için gerenek bağlantı e-posta adresinize gönderildi. Spam kutusunu kontrol ediniz", "success");

                return RedirectToAction("girisyap", "account");
            }

            CreateAlert("Hata", "Bilinmeyen bir hata oluştu tekrar deneyin", "success");
            return View(model);
        }

        public async Task<IActionResult> cikisyap()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> epostaonay(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateAlert("Hata", "Geçersiz istek", "danger");
                return RedirectToAction("girisyap", "account");
            }
            // User kontrolü
            var checkUser = await _userManager.FindByIdAsync(userId);
            if (checkUser == null)
            {
                CreateAlert("Hata", "Geçersiz kullanıcı", "danger");
                return RedirectToAction("girisyap", "account");
            }

            var result = await _userManager.ConfirmEmailAsync(checkUser, token);
            if (result.Succeeded)
            {
                CreateAlert("Hesabınız onaylandı", "Giriş yapabilirsiniz", "success");
                return RedirectToAction("girisyap", "account");
            }
            CreateAlert("Hata", "Hesabınız onaylanamadı", "danger");
            return RedirectToAction("girisyap", "account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public void CreateAlert(string title, string message, string alertType)
        {
            var alert = new AlertModel
            {
                Title = title,
                Message = message,
                Type = alertType
            };

            TempData["alert"] = JsonConvert.SerializeObject(alert);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using web.Data.Abstract;
using web.EmailService;
using web.Identity;
using web.Models;

// dotnet ef dbcontext scaffold "Data Source=SELCUK;Initial Catalog=KanBagisDb;Integrated Security=SSPI;" "Microsoft.EntityFrameworkCore.SqlServer" --output-dir "../data" --context KanBagisDbContext

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private SehirlerInterface _sehirler;
        private KanGruplariInterface _kangruplari;
        private HastanelerInterface _hastaneler;
        private IlcelerInterface _ilceler;
        private IlanlarInterface _ilanlar;
        private UserManager<User> _userManager;
        private IEmailSender _emailSender;
        private SignInManager<User> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IlanlarInterface ilanlar, SehirlerInterface sehirler, IlcelerInterface ilceler, HastanelerInterface hastaneler, KanGruplariInterface kangruplari)
        {
            _kangruplari = kangruplari;
            _hastaneler = hastaneler;
            _sehirler = sehirler;
            _ilceler = ilceler;
            _ilanlar = ilanlar;
            _emailSender = emailSender;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var anasayfailanlar = new List<IlanlarModel>();
            var ilanlar = _ilanlar.SonIlanlar(20);

            foreach (var item in ilanlar)
            {
                anasayfailanlar.Add(new IlanlarModel
                {
                    IlanId = item.IlanId,
                    HastaAd = item.HastaTamAd,
                    HastaSehir = item.Hastane.Sehir,
                    HastaIlce = item.Hastane.Ilce,
                    HastaKanGrubu = item.KanGrubu.KanGrubu,
                    IlanOzet = item.IlanOzeti,
                    IlanTarih = item.IlanTarihi
                });
            }
            return View(anasayfailanlar);
        }

        public IActionResult hakkimizda()
        {
            return View();
        }
        public IActionResult ilanlar(string sehir, string ilce, int kangrubuid, int page = 1)
        {
            var ilanlar = new List<Ilanlar>();
            var ilanlarModel = new List<IlanlarModel>();
            var ilanlarpagemodel = new IlanlarPageModel();
            var sehirler = _sehirler.GetAll();
            var kangruplari = _kangruplari.TumKanGruplari();
            const int pageSize = 10;

            // Hepsi boş
            if (sehir == null && ilce == null && kangrubuid == 0)
            {
                ilanlar = _ilanlar.TumIlanar(pageSize, page);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.TumIlanarCount(),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }
            // Şehir dolu
            else if (sehir != null && ilce == null && kangrubuid == 0)
            {
                ilanlar = _ilanlar.IlanlarBySehir(pageSize, page, sehir);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.IlanlarBySehirCount(sehir),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }
            // Kan grubu dolu
            else if (sehir == null && ilce == null && kangrubuid != 0)
            {
                ilanlar = _ilanlar.IlanlarByKanGrubu(pageSize, page, kangrubuid);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.IlanlarByKanGrubuCount(kangrubuid),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }
            // Şehir ve Kan grubu dolu
            else if (sehir != null && ilce == null && kangrubuid != 0)
            {
                ilanlar = _ilanlar.IlanlarBySehir_KanGrubu(pageSize, page, sehir, kangrubuid);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.IlanlarBySehir_KanGrubuCount(sehir, kangrubuid),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }
            // Şehir ve İlçe dolu
            else if (sehir != null && ilce != null && kangrubuid == 0)
            {
                ilanlar = _ilanlar.IlanlarBySehir_Ilce(pageSize, page, sehir, ilce);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.IlanlarBySehir_IlceCount(sehir, ilce),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }
            // Şehir, İlçe ve Kan grubu dolu
            else if (sehir != null && ilce != null && kangrubuid != 0)
            {
                ilanlar = _ilanlar.IlanlarBySehir_Ilce_KanGrubu(pageSize, page, sehir, ilce, kangrubuid);
                foreach (var ilan in ilanlar)
                {
                    ilanlarModel.Add(new IlanlarModel()
                    {
                        IlanId = ilan.IlanId,
                        HastaAd = ilan.HastaTamAd,
                        HastaSehir = ilan.Hastane.Sehir,
                        HastaIlce = ilan.Hastane.Ilce,
                        HastaKanGrubu = ilan.KanGrubu.KanGrubu,
                        IlanOzet = ilan.IlanOzeti,
                        IlanTarih = ilan.IlanTarihi
                    }
                    );
                }
                ilanlarpagemodel.PageInfo = new PageInfo()
                {
                    TotalItems = _ilanlar.IlanlarBySehir_Ilce_KanGrubuCount(sehir, ilce, kangrubuid),
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                };
            }

            ilanlarpagemodel.Ilanlar = ilanlarModel;
            ilanlarpagemodel.Sehirler = sehirler;
            ilanlarpagemodel.KanGruplari = kangruplari;

            ViewBag.sehir = HttpContext.Request.Query["sehir"];
            ViewBag.ilce = HttpContext.Request.Query["ilce"];
            ViewBag.kangrubuid = HttpContext.Request.Query["kangrubuid"];

            return View(ilanlarpagemodel);
        }
        public IActionResult negatiflist()
        {
            return View();
        }

        public IActionResult pozitiflist()
        {
            return View();
        }
        public async Task<IActionResult> ilandetay(int id)
        {
            var ilanDetay = new IlanDetay();
            var ilan = _ilanlar.IlanGetir(id);
            if (ilan.UserId != null)
            {
                var ilanVeren = await _userManager.FindByIdAsync(ilan.UserId);
                ilanDetay.IlanVeren = ilanVeren;
            }
            ilanDetay.Ilan = ilan;
            return View(ilanDetay);
        }


        public async Task<IActionResult> ilanver()
        {
            var sehirler = _sehirler.GetAll();
            var IlanVerModel = new IlanVerModel();
            IlanVerModel.Sehirler = sehirler;

            // Kullanıcı giriş yapmışsa
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                IlanVerModel.User = user;
            }

            return View(IlanVerModel);
        }

        [HttpPost]
        public async Task<IActionResult> ilanver(IlanVerModel model)
        {
            string UserId = null;
            var sehirler = _sehirler.GetAll();

            var IlanVerModel = new IlanVerModel();
            IlanVerModel.Sehirler = sehirler;

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                UserId = user.Id;
                IlanVerModel.User = user;
            }

            if (!ModelState.IsValid)
            {
                return View(IlanVerModel);
            }
            if (model.HastaneId == 0)
            {
                CreateAlert("Hata", "Hastane seçimi boş olamaz", "danger");
                return View(IlanVerModel);
            }
            if (model.KanGrubuId == 0)
            {
                CreateAlert("Hata", "Kan grubu seçimi boş olamaz", "danger");
                return View(IlanVerModel);
            }

            var ilan = new Ilanlar()
            {
                UserId = UserId,
                HastaTamAd = model.HastaTamAd,
                HastaYas = model.HastaYas,
                IletisimNumarasi1 = model.IletisimNumarasi1,
                IletisimNumarasi2 = model.IletisimNumarasi2,
                HastaneId = model.HastaneId,
                KanGrubuId = model.KanGrubuId,
                GerekliUnite = model.GerekliUnite,
                IlanOzeti = model.IlanOzeti
            };

            var result = _ilanlar.Create(ilan);
            CreateAlert("Kayıt eklendi", $"{model.HastaTamAd} adlı hastanın ilanı başarıyla eklendi", "success");

            // İlan ile aynı şehirde bulunan kayıtlı kullanıcılara e-posta gönderme
            var url = Url.Action("ilandetay", "home", new
            {
                id = result.IlanId
            });

            var sonilansehir = _ilanlar.SonIlanSehir(result.HastaneId);
            using (var db = new IdentityContext())
            {
                var sonilaninisehrineaitkullanicilar = db.Users
                .Where(w => w.Sehir == sonilansehir)
                .ToList();

                foreach (var kullanici in sonilaninisehrineaitkullanicilar)
                {
                    await _emailSender.SendEmailAsync(kullanici.Email, "Yakınınızda kan'a ihtiyacı olan bir hasta var.", $"Şehrinizde yeni bir ilan oluşturuldu hemen bağış yapmak için <a href='http://localhost:5001{url}'>tıklayın</a>");
                }

            }
            return RedirectToAction("ilanver");
        }

        public JsonResult ilcelerigetir(int id)
        {
            var ilceler = _ilceler.IlceleriGetir(id);
            return Json(ilceler);
        }
        public JsonResult hastanelerigetir(int SehirId, int IlceId)
        {
            var hastaneler = _hastaneler.HastaneleriGetir(SehirId, IlceId);
            return Json(hastaneler);
        }

        public IActionResult kanvermeninonemi()
        {
            return View();
        }

        public IActionResult iletisim()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> iletisim(IletisimModel model)
        {
            var adminemail = "kandostum@outlook.com";
            await _emailSender.SendEmailAsync(adminemail, model.Konu, "Gönderen: <strong>" + model.Ad + "</strong> <strong>" + model.Soyad + "</strong><p>Mesaj: " + model.Mesaj + "</p>");
            CreateAlert("Mesajınız oluşturuldu", "Mesajınız başarı ile iletildi", "success");
            return RedirectToAction("iletisim");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

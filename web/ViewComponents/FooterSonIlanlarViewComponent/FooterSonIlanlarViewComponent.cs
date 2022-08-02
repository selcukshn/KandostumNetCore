using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Data.Abstract;
using data;

namespace web.ViewComponents.NavbarViewComponent
{
    public class FooterSonIlanlarViewComponent : ViewComponent
    {
        private IlanlarInterface _ilanlar;
        public FooterSonIlanlarViewComponent(IlanlarInterface ilanlar)
        {
            _ilanlar = ilanlar;
        }
        public IViewComponentResult Invoke()
        {
            var ilanlar = _ilanlar.SonIlanlar(5);
            return View(ilanlar);
        }
    }
}
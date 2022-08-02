using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace web.Identity
{
    public class User : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public string Cinsiyet { get; set; }
        public string MedeniDurum { get; set; }
        public int KanGrubu { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
    }
}
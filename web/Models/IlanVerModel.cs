using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Identity;

namespace web.Models
{
    public class IlanVerModel
    {
        [Display(Name = "Hasta isim", Prompt = "Hasta isim")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(40, ErrorMessage = "Maksimum 40 karakter olabilir")]
        public string HastaTamAd { get; set; }


        [Display(Name = "Hasta yaş", Prompt = "Hasta yaş")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(2, ErrorMessage = "Maksimum 2 karakter olabilir")]
        public string HastaYas { get; set; }


        [Display(Name = "İletişim numarası 1", Prompt = "İletişim numarası 1")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(20, ErrorMessage = "Maksimum 20 karakter olabilir")]
        public string IletisimNumarasi1 { get; set; }


        [Display(Name = "İletişim numarası 2", Prompt = "İletişim numarası 2")]
        [MaxLength(20, ErrorMessage = "Maksimum 20 karakter olabilir")]
        public string IletisimNumarasi2 { get; set; }


        [Display(Name = "Hastanın Tedavi Gördüğü Hastane", Prompt = "Hastanın Tedavi Gördüğü Hastane")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public int HastaneId { get; set; }


        [Display(Name = "Kan Grubu", Prompt = "Kan Grubu")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public int KanGrubuId { get; set; }


        [Display(Name = "Gerekli Ünite Adeti", Prompt = "Gerekli Ünite Adeti")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(2, ErrorMessage = "Maksimum 2 karakter olabilir")]
        public string GerekliUnite { get; set; }


        [Display(Name = "İlan Metni", Prompt = "İlan Metni")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(1000, ErrorMessage = "Maksimum 1000 karakter olabilir")]
        public string IlanOzeti { get; set; }


        public List<Sehirler> Sehirler { get; set; }
        public List<Ilceler> Ilceler { get; set; }
        public User User { get; set; }
    }
}
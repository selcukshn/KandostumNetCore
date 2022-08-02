using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class IletisimModel
    {
        [Display(Name = "Adınız", Prompt = "Adınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(20, ErrorMessage = "Maksimum 20 karakter olabilir")]
        public string Ad { get; set; }

        [Display(Name = "Soyadınız", Prompt = "Soyadınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(20, ErrorMessage = "Maksimum 20 karakter olabilir")]
        public string Soyad { get; set; }

        [Display(Name = "E-posta adresiniz", Prompt = "E-posta adresiniz")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Doğru formatta giriniz")]
        [MaxLength(60, ErrorMessage = "Maksimum 60 karakter olabilir")]
        public string Eposta { get; set; }

        [Display(Name = "Konu başlığı", Prompt = "Konu başlığı")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(40, ErrorMessage = "Maksimum 40 karakter olabilir")]
        public string Konu { get; set; }

        [Display(Name = "Mesajınız", Prompt = "Mesajınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(500, ErrorMessage = "Maksimum 500 karakter olabilir")]
        public string Mesaj { get; set; }
    }
}
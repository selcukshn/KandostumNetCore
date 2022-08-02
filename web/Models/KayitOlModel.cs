using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class KayitOlModel
    {
        [Display(Name = "Adınız", Prompt = "Adınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(40, ErrorMessage = "Maksimum 40 karakter olabilir")]
        public string Ad { get; set; }

        [Display(Name = "Soyadınız", Prompt = "Soyadınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(40, ErrorMessage = "Maksimum 40 karakter olabilir")]
        public string Soyad { get; set; }

        [Display(Name = "Telefon numaranız", Prompt = "Telefon numaranız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Doğru formatta giriniz")]
        [MaxLength(15, ErrorMessage = "Maksimum 15 karakter olabilir")]
        public string Telefon { get; set; }

        [Display(Name = "T.C. Kimlik numaranız", Prompt = "T.C. Kimlik numaranız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MinLength(11, ErrorMessage = "Minimum 11 karaker olmalıdır")]
        [MaxLength(11, ErrorMessage = "Maksimum 11 karakter olabilir")]
        public string Tc { get; set; }

        [Display(Name = "E-posta adresiniz", Prompt = "E-posta adresiniz")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Doğru formatta giriniz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string Eposta { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Cinsiyet { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string MedeniDurum { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        public int KanGrubu { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Ilce { get; set; }


        [Display(Name = "Adresiniz", Prompt = "Adresiniz")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(500, ErrorMessage = "Maksimum 500 karakter olabilir")]
        public string Adres { get; set; }

        [Display(Name = "Parolanız", Prompt = "Parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string Sifre { get; set; }

        [Display(Name = "Parolanız tekrar girin", Prompt = "Tekrar parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare("Sifre")]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string SifreTekrar { get; set; }

    }
}

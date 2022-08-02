using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class LoginModel
    {
        [Display(Name = "E-posta", Prompt = "E-posta adresinizi giriniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Eposta { get; set; }

        [Display(Name = "Parola", Prompt = "Parolanızı girin")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        public string Sifre { get; set; }
    }
}
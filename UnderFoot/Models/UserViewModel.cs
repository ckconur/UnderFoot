using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

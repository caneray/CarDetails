using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E mail Boş Geçilemez!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        [Display(Name = "Kullanıcı Şifre")]
        public string Password { get; set; }
    }
}

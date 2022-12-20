using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Model Adı Boş Geçilemez!")]
        [Display(Name = "Model Adı")]
        public string BrandName { get; set; }
    }
}

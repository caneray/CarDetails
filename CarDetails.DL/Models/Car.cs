using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Araç Modeli Boş Geçilemez!")]
        [Display(Name = "Araç Model")]
        public string CarModel { get; set; }
        [Required(ErrorMessage = "Model Yılı Boş Geçilemez!")]
        [Display(Name = "Model Yılı")]
        public DateTime CarModelDate { get; set; }
      
        
        [Required(ErrorMessage = "Motor Gücü Boş Geçilemez!")]
        [Display(Name = "Motor Gücü ")]
        public int CarHP { get; set; }





        [Required(ErrorMessage = "Araç Paketi Boş Geçilemez!")]
        [Display(Name = "Araç Paketi")]
        public string PackageName { get; set; }
        [Required(ErrorMessage = "Yakıt Türü Boş Geçilemez!")]
        [Display(Name = "Yakıt Türü")]
        public string CarFuel { get; set; }
        [Required(ErrorMessage = "Fotoğraf Boş Geçilemez!")]
        [Display(Name = "Araç Fotoğrafı")]
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public Brand _Brand { get; set; }

        public int CaseTypeId { get; set; }
        public CaseType _CaseType { get; set; }

    }
}

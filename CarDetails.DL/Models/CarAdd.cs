using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDetails.DL.Models
{
	public class CarAdd
	{
		public string CarModel { get; set; }
		[Required(ErrorMessage = "Model Yılı Boş Geçilemez!")]
		[Display(Name = "Model Yılı")]
		public DateTime CarModelDate { get; set; }
		[Required(ErrorMessage = "Motor Gücü Boş Geçilemez!")]
		[Display(Name = "Motor Gücü")]
		public int CarHP { get; set; }
		[Required(ErrorMessage = "Araç Paketi Boş Geçilemez!")]
		[Display(Name = "Araç Paketi")]
		public string PackageName { get; set; }
		[Required(ErrorMessage = "Yakıt Türü Boş Geçilemez!")]
		[Display(Name = "Yakıt Türü")]
		public string CarFuel { get; set; }
		[Required(ErrorMessage = "Fotoğraf Boş Geçilemez!")]
		[Display(Name = "Araç Fotoğrafı")]
		public IFormFile ImageUrl { get; set; }
		public int BrandId { get; set; }

		public int CaseTypeId { get; set; }
	}
}

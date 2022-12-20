using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
	public class BrandAdd
	{
		public string BrandName { get; set; }
		[Required(ErrorMessage = "Marka Logo Boş Geçilemez!")]
		public IFormFile ImgUrl { get; set; }
	}
}

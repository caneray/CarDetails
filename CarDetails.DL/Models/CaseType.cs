using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
	public class CaseType
	{
		[Key]
		public int CaseTypeId { get; set; }
		[Required]
		[Display(Name = "Kasa Tipi")]
		public string CaseTypeName { get; set; }
	}
}

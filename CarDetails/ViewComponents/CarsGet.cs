using CarDetails.BL.Repository;
using CarDetails.DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDetails.PL.ViewComponents
{
	public class CarsGet : ViewComponent
	{
		CaseTypeRepository CaseType = new CaseTypeRepository();

		public IViewComponentResult Invoke() 
		{
			var result = CaseType.TList();
			return View(result); 
		}
	}
}

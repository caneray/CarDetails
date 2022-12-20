using CarDetails.BL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarDetails.PL.ViewComponents
{
	public class HomeBrandsGet : ViewComponent
	{
		BrandRepository brandRepository = new BrandRepository();

		public IViewComponentResult Invoke()
		{
			var result = brandRepository.TList();
			return View(result);
		}
	}
}

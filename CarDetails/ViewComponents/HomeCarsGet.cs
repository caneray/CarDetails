using CarDetails.BL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarDetails.PL.ViewComponents
{
	public class HomeCarsGet : ViewComponent
	{
		CarRepository carRepository= new CarRepository();

		public IViewComponentResult Invoke()
		{
			var result = carRepository.TList();
			return View(result);
		}
	}
}

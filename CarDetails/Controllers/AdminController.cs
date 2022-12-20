using CarDetails.BL.Repository;
using CarDetails.DL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace CarDetails.PL.Controllers
{
	public class AdminController : Controller
	{
		CaseTypeRepository caseTypeRepository = new CaseTypeRepository();
		BrandRepository brandRepository = new BrandRepository();
		CarRepository carRepository = new CarRepository();
		Context context = new Context();
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Cars()
		{
			var result = carRepository.TList();
			return View(result);
		}
		public IActionResult CreateCar()
		{
			List<SelectListItem> values = (from x in context.Brand.ToList()
										   select new SelectListItem
										   {
											   Text = x.BrandName,
											   Value = x.BrandId.ToString(),
										   }).ToList();
			ViewBag.brand = values;
			
			List<SelectListItem> values2 = (from x in context.CaseType.ToList()
										   select new SelectListItem
										   {
											   Text = x.CaseTypeName,
											   Value = x.CaseTypeId.ToString(),
										   }).ToList();
			ViewBag.casetype = values2;




			return View();
		}
		[HttpPost]
		public IActionResult CreateCar(CarAdd model)
		{
			Car c = new Car();
			if (ModelState.IsValid)
			{
				if (model.ImageUrl != null)
				{
					var extension = Path.GetExtension(model.ImageUrl.FileName);
					var newImageName = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
					var stream = new FileStream(location, FileMode.Create);
					model.ImageUrl.CopyTo(stream);
					c.ImageUrl = newImageName;
				}
				c.CarModel = model.CarModel;
				c.CarModelDate = model.CarModelDate;
				c.CarHP = model.CarHP;
				c.PackageName = model.PackageName;
				c.CarFuel = model.CarFuel;
				c.BrandId=model.BrandId;
				c.CaseTypeId= model.CaseTypeId;

				carRepository.TAdd(c);
				return RedirectToAction("Cars");
			}

			return View();
		}
		public IActionResult CarDelete(int id)
		{
			var result = carRepository.TGet(id);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				carRepository.TDelete(result);
				return RedirectToAction("Cars");
			}
		}
		public IActionResult CarEdit(int id)
		{
			var result = carRepository.TGet(id);
			if (id == 0)
			{
				return NotFound();
			}
			return View(result);
		}
		[HttpPost]
		public IActionResult CarEdit(Car model) //eksik
		{
			var result = carRepository.TGet(model.CarId);
			if (ModelState.IsValid)
			{
				result.CarModel = model.CarModel;
				result.CarModelDate = model.CarModelDate;
				result.CarHP = model.CarHP;
				result.PackageName = model.PackageName;
				result.CarFuel = model.CarFuel;
				result.ImageUrl = model.ImageUrl;
				result.BrandId = model.BrandId;
				result.CaseTypeId = model.CaseTypeId;
				carRepository.TUpdate(result);
				return RedirectToAction("Cars");
			}
			return View();
		}

		#region CASETYPE 

		public IActionResult CaseType()
		{
			var result = caseTypeRepository.TList();
			return View(result);
		}
		public IActionResult CreateCaseType()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateCaseType(CaseType model)
		{
			if (ModelState.IsValid)
			{
				caseTypeRepository.TAdd(model);
				return RedirectToAction("CaseType");
			}

			return View();
		}
		public IActionResult CaseTypeDelete(int id)
		{
			var result = caseTypeRepository.TGet(id);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				caseTypeRepository.TDelete(result);
				return RedirectToAction("CaseType");
			}
		}
		public IActionResult CaseTypeEdit(int id)
		{
			var result = caseTypeRepository.TGet(id);
			if (id == 0)
			{
				return NotFound();
			}
			return View(result);
		}
		[HttpPost]
		public IActionResult CaseTypeEdit(CaseType model)
		{
			var result = caseTypeRepository.TGet(model.CaseTypeId);
			if (ModelState.IsValid)
			{
				result.CaseTypeName = model.CaseTypeName;
				caseTypeRepository.TUpdate(result);
				return RedirectToAction("CaseType");
			}
			return View();
		}
		#endregion

		#region BRAND

		public IActionResult Brand()
		{
			var result = brandRepository.TList();
			return View(result);
		}
		public IActionResult BrandDelete(int id)
		{
			var result = brandRepository.TGet(id);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				brandRepository.TDelete(result);
				return RedirectToAction("Brand");
			}
		}
		public IActionResult CreateBrand()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateBrand(BrandAdd model)
		{

			Brand b = new Brand();
			if (ModelState.IsValid)
			{
				if (model.ImgUrl != null)
				{
					var extension = Path.GetExtension(model.ImgUrl.FileName);
					var newImageName = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
					var stream = new FileStream(location, FileMode.Create);
					model.ImgUrl.CopyTo(stream);
					b.ImgUrl = newImageName;
				}
			   b.BrandName= model.BrandName;

				brandRepository.TAdd(b);
				return RedirectToAction("Brand");
			}

			return View();



		}
		public IActionResult BrandEdit(int id)
		{
			var result = brandRepository.TGet(id);
			if (id == 0)
			{
				return NotFound();
			}
			return View(result);
		}
		[HttpPost]
		public IActionResult BrandEdit(Brand model)
		{
			var result = brandRepository.TGet(model.BrandId);
			if (ModelState.IsValid)
			{
				result.BrandName = model.BrandName;
				brandRepository.TUpdate(result);
				return RedirectToAction("Brand");
			}
			return View();
		}
		#endregion


	}
}

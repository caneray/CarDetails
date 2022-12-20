using CarDetails.BL.Repository;
using CarDetails.DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDetails.PL.Controllers
{
    public class AdminController : Controller
    {
        CaseTypeRepository caseTypeRepository = new CaseTypeRepository();
        BrandRepository brandRepository = new BrandRepository();
        public IActionResult Index()
        {
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
		public IActionResult CreateBrand(Brand model)
		{
			if (ModelState.IsValid)
			{
				brandRepository.TAdd(model);
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
	}
}

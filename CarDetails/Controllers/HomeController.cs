using CarDetails.DL.Models;
using CarDetails.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		Context c = new Context();

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
		public IActionResult About()
		{
			return View();
		}
        public IActionResult GetCars()
        {
            return View();
        }
        //public IActionResult GetCars(int id)
        //{
        //         var result= c.Car.Where(x=>x.CaseTypeId== id).ToList();
        //	return View(result);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
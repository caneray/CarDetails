using CarDetails.BL.Repository;
using CarDetails.DL.Models;
using CarDetails.Models;
using Firebase.Auth;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;

namespace CarDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		Context c = new Context();
		FirebaseAuthProvider auth;
		UserRepository user = new UserRepository();

		public HomeController(ILogger<HomeController> logger)
        {
			auth = new FirebaseAuthProvider(
						  new FirebaseConfig("AIzaSyANB0YN1Ro-5ACHnHp63elaRbRXtYZi30k"));
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
   //     public IActionResult SearchCar(string aranan)
   //     {
			//int arama = c.Car
			//	 .Where(p => p.CarModel.Contains(aranan))
			//	 .Single()
			//	 .CarId;


			//return View();
   //     }

		public IActionResult GetBrands(int id)
        {
			var result = c.Car.Where(x => x.BrandId == id).ToList();
			 return View(result);
		}
        public IActionResult GetCars(int id)
        {
            var result = c.Car.Where(x => x.CaseTypeId == id).ToList();
            return View(result);
        }
		public IActionResult CarDetail(int id)
		{
            var result=c.Car.Where(x=>x.CarId== id).ToList();
			return View(result);
		}
		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(SignUp loginModel)
		{
			UserModel _user = new UserModel();
			try
			{
				var a = await auth.CreateUserWithEmailAndPasswordAsync(loginModel.Email, loginModel.Password, loginModel.UserName, false);
				TempData["MailOnay"] = "Lütfen Mail Adresinizi Onaylayınız";

				_user.UserName = loginModel.UserName;
				_user.Password = loginModel.Password;
				_user.Email = loginModel.Email;
				if (ModelState.IsValid)
				{
					user.TAdd(_user);
					return RedirectToAction("Login");
				}
			}
			catch (Exception ex)
			{
				if (Response.StatusCode == 200)
				{
					TempData["Hata"] = "E mail mevcut!";
				}
			}

			return View();

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace MyTripMVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

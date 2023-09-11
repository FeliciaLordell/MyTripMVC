using MyTripMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyTripMVC.Views.Travels;

namespace MyTripMVC.Controllers
{
    public class TravelsController : Controller
    {

		DataService dataService;
		public TravelsController(DataService dataService)
		{
			this.dataService = dataService;
		}

		[HttpGet("")]
		[HttpGet("Index")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync(RegisterVM viewModel)
		{
			if (!ModelState.IsValid)
				return View();

			// Try to register user
			var errorMessage = await dataService.TryRegisterAsync(viewModel);
			if (errorMessage != null)
			{
				foreach (var error in errorMessage)
				{
					ModelState.AddModelError(string.Empty, error);
				}
				// Show error
				return View();
			}

			// Redirect user
			return RedirectToAction(nameof(Login));
		}

		[HttpGet("login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(LoginVM viewModel)
		{
			if (!ModelState.IsValid)
				return View();

			// Check if credentials is valid (and set auth cookie)
			var errorMessage = await dataService.TryLoginAsync(viewModel);
			if (errorMessage != null)
			{
				// Show error
				ModelState.AddModelError(string.Empty, errorMessage);
				return View();
			}

			// Redirect user
			return RedirectToAction(nameof(Index));
		}
		[HttpGet("logout")]
		public async Task<IActionResult> LogOutAsync()
		{

			await dataService.TryLogoutAsync();

			return RedirectToAction(nameof(Login));
        
		}

		[HttpGet("GetAll/{cityN}")]
		public async Task<IActionResult> GetSearch(string cityN)
		{
			var model = await dataService.GetSpecificCityAsync(cityN);
			return PartialView("_ShowAll", model);
		}

        [HttpGet("GetRestaurants/{cityN}")]
        public async Task<IActionResult> GetRestaurants(string cityN)
        {
            var model = await dataService.GetSpecificCityRestaurantsAsync(cityN);
            return PartialView("_ShowAll", model);
        }

        [HttpGet("GetActivities/{cityN}")]
        public async Task<IActionResult> GetActivities(string cityN)
        {
            var model = await dataService.GetSpecificCityActivitiesAsync(cityN);
            return PartialView("_ShowAll", model);
        }


		[HttpGet("/logo")]
		public IActionResult GetLogo()
		{

			return PartialView("_logo");
		}

		[HttpGet("/Details/{id}")]
		public async Task<IActionResult> GetDetails(int id)
		{
			var model = await dataService.GetDetails(id);
			return View(model);
		}

		[HttpPost("/AddTrip/{id}")]
		public IActionResult AddTrip(GetDetailsVM viewModel)
		{
			TempData["AddTripMessage"] = dataService.AddToTrip(viewModel, User);
			return RedirectToAction(nameof(GetDetails), new { id = viewModel.Id });
		}

        [HttpPost("/RemoveTrip/{id}")]
        public IActionResult RemoveTrip(int id)
        {
            dataService.RemoveFromTrip(id, User);
            return RedirectToAction(nameof(Mytrip), new { id = id });
        }


        [HttpGet("/Mytrip")]
		public IActionResult Mytrip()
		{
			var model = dataService.GetTrip(User);
			return View(model);

        }
	}
	

}

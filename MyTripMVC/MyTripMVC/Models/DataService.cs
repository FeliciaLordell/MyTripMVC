using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTripMVC.Views.Travels;
using System.Diagnostics;
using System.Security.Claims;
using static MyTripMVC.Views.Travels.IndexVM;
using static MyTripMVC.Views.Travels.MytripVM;

namespace MyTripMVC.Models
{
	public class DataService
	{
		ApplicationContext context;
		UserManager<ApplicationUser> userManager; // Hanterar användare
		SignInManager<ApplicationUser> signInManager; // Hanterar inlogging
		RoleManager<IdentityRole> roleManager; // Hanterar roller
		public DataService(ApplicationContext context,
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		RoleManager<IdentityRole> roleManager)
		{
			this.context = context;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
		}

		public async Task<string> TryLoginAsync(LoginVM viewModel)
		{
			SignInResult result = await signInManager.PasswordSignInAsync(
				viewModel.UserName,
				viewModel.Password,
				isPersistent: false,
				lockoutOnFailure: false);

			return result.Succeeded ? null : "Login failed";
		}

		public async Task TryLogoutAsync()
		{
			await signInManager.SignOutAsync();
		}

		public async Task<string[]?> TryRegisterAsync(RegisterVM viewModel)
		{
			var user = new ApplicationUser
			{
				UserName = viewModel.UserName,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email
			};

			IdentityResult result = await
				userManager.CreateAsync(user, viewModel.Password);
			if (result.Succeeded)
			{
				return null;
			}
			else
				return result.Errors.Select(o => o.Description)
					.ToArray();

		}

		public async Task<IndexVM> GetSpecificCityAsync(string cityNamePartial)
		{
			var cities = await context.Cities
				.Where(c => c.Name.Contains(cityNamePartial))
				.ToListAsync();

			if (cities.Any())
			{
				var cityNames = cities.Select(c => c.Name).ToList();
				return GetAll(cityNames);
			}
			else
			{
				return new IndexVM();
			}
		}

		public IndexVM GetAll(List<string> cityNames)
		{
			var restaurants = context.Restaurants
				.Where(r => cityNames.Contains(r.City.Name))
				.Select(r => new RestaurantVM
				{
					Name = r.Name,
					ImageUrl = r.ImageUrl,
					AltTag = r.AltTag,
					CityName = r.City.Name,
					Id = r.Id
				})
				.ToArray();

			var activities = context.Activities
				.Where(a => cityNames.Contains(a.City.Name))
				.Select(a => new ActivityVM
				{
					Name = a.Name,
					ImageUrl = a.ImageUrl,
					AltTag = a.AltTag,
					CityName = a.City.Name,
					Id = a.Id
				})
				.ToArray();

			return new IndexVM
			{
				restaurants = restaurants,
				activities = activities
			};
		}

		public async Task<IndexVM> GetSpecificCityRestaurantsAsync(string cityNamePartial)
		{
			var cities = await context.Cities
				.Where(c => c.Name.Contains(cityNamePartial))
				.ToListAsync();

			if (cities.Any())
			{
				var cityNames = cities.Select(c => c.Name).ToList();
				return GetRestaurant(cityNames);
			}
			else
			{
				return new IndexVM();
			}
		}

		public IndexVM GetRestaurant(List<string> cityNames)
		{
			var restaurants = context.Restaurants
				.Where(r => cityNames.Contains(r.City.Name))
				.Select(r => new RestaurantVM
				{
					Name = r.Name,
					ImageUrl = r.ImageUrl,
					CityName = r.City.Name,
					Id = r.Id
				})
				.ToArray();

			return new IndexVM
			{
				restaurants = restaurants
			};
		}

		public async Task<IndexVM> GetSpecificCityActivitiesAsync(string cityNamePartial)
		{
			var cities = await context.Cities
				.Where(c => c.Name.Contains(cityNamePartial))
				.ToListAsync();

			if (cities.Any())
			{
				var cityNames = cities.Select(c => c.Name).ToList();
				return GetActivities(cityNames);
			}
			else
			{
				return new IndexVM();
			}
		}

		public IndexVM GetActivities(List<string> cityNames)
		{
			var activities = context.Activities
				.Where(a => cityNames.Contains(a.City.Name))
				.Select(a => new ActivityVM
				{
					Name = a.Name,
					ImageUrl = a.ImageUrl,
					CityName = a.City.Name,
					Id = a.Id
				})
				.ToArray();

			return new IndexVM
			{
				activities = activities
			};
		}

		public async Task<GetDetailsVM?> GetDetails(int id)
		{
			var restaurantId = context.Restaurants.Where(r => r.Id == id).FirstOrDefault();
			if (restaurantId != null)
			{

				return context.Restaurants.Where(r => r.Id == id)
					.Select(r => new GetDetailsVM
					{
						Name = r.Name,
						Description = r.Description,
						Image = r.ImageUrl,
						AltTag = r.AltTag,
						Id = id,
						City = r.City.Name
					}
				).FirstOrDefault();
			}
			else
			{
				return context.Activities.Where(a => a.Id == id)
					.Select(a => new GetDetailsVM
					{
						Name = a.Name,
						Description = a.Description,
						Image = a.ImageUrl,
						AltTag = a.AltTag,
						Id = id,
						City = a.City.Name
					}
				).FirstOrDefault();
			}
		}

		public void RemoveFromTrip(int id, ClaimsPrincipal user)
		{
			var restaurantId = context.Restaurants.Where(r => r.Id == id).FirstOrDefault();
			string userid = userManager.GetUserId(user);

			if (restaurantId != null)
			{
				var userRestaurant = context.UserRestaurants
					.FirstOrDefault(ur => ur.RestaurantId == id && ur.IdUser == userid);

				if (userRestaurant != null)
				{
					context.UserRestaurants.Remove(userRestaurant);
					context.SaveChanges();
				}
			}
			else
			{
				var userActivity = context.UserActivities
					.FirstOrDefault(ua => ua.ActivityId == id && ua.IdUser == userid);

				if (userActivity != null)
				{
					context.UserActivities.Remove(userActivity);
					context.SaveChanges();
				}
			}
		}

		public string AddToTrip(GetDetailsVM model, ClaimsPrincipal user)
		{
			var restaurantId = context.Restaurants.Where(r => r.Id == model.Id).FirstOrDefault();
			string userid = userManager.GetUserId(user);

			if (restaurantId != null)
			{
				bool restaurantAlreadyAdded = context.UserRestaurants
					.Any(ur => ur.RestaurantId == model.Id && ur.IdUser == userid);

				if (!restaurantAlreadyAdded)
				{
					var restaurant = new UserRestaurant
					{
						IdUser = userid,
						RestaurantId = model.Id,
						Bookingdate = model.BookingDate,
						BookingTime = model.BookingTime
					};

					context.UserRestaurants.Add(restaurant);
					context.SaveChanges();

					return "Restaurant successfully added to MyTrip.";
				}
				else
				{
					return "Restaurant already added to MyTrip";
				}
			}
			else
			{
				bool activityAlreadyAdded = context.UserActivities
					.Any(ua => ua.ActivityId == model.Id && ua.IdUser == userid);

				if (!activityAlreadyAdded)
				{
					var activity = new UserActivity
					{
						IdUser = userid,
						ActivityId = model.Id,
						Bookingdate = model.BookingDate,
						BookingTime = model.BookingTime
					};
					context.UserActivities.Add(activity);
					context.SaveChanges();
					return "Activity Successfully added to MyTrip.";
				}
				else
				{
					return "Activity already added to MyTrip";
				}
			}
		}



		public MytripVM GetTrip(ClaimsPrincipal user)
		{
			string userid = userManager.GetUserId(user);

			var mytripVM = new MytripVM
			{
				CityGroups = new Dictionary<string, RestaurantActivityGroupVM>()
			};

			var restaurantGroups = context.UserRestaurants
				.Where(r => r.IdUser == userid)
				.Select(r => new
				{
					City = r.Restaurant.City.Name,
					Restaurant = new RestaurantTripVM
					{
						Id = r.Restaurant.Id,
						Name = r.Restaurant.Name,
						City = r.Restaurant.City.Name,
						BookedDate = r.Bookingdate,
						BookedTime = r.BookingTime
					}
				})
				.ToArray();

			var activityGroups = context.UserActivities
				.Where(r => r.IdUser == userid)
				.Select(r => new
				{
					City = r.Activity.City.Name,
					Activity = new ActivityTripVM
					{
						Id = r.Activity.Id,
						Name = r.Activity.Name,
						City = r.Activity.City.Name,
						BookedDate = r.Bookingdate,
						BookedTime = r.BookingTime
					}
				})
				.ToArray();

			var allCities = restaurantGroups.Select(r => r.City)
				.Union(activityGroups.Select(a => a.City))
				.Distinct()
				.ToArray();

			foreach (var city in allCities)
			{
				var restaurantTrips = restaurantGroups
					.Where(r => r.City == city)
					.Select(r => r.Restaurant)
					.ToArray();

				var activityTrips = activityGroups
					.Where(a => a.City == city)
					.Select(a => a.Activity)
					.ToArray();

				mytripVM.CityGroups[city] = new RestaurantActivityGroupVM
				{
					Restaurants = restaurantTrips,
					Activities = activityTrips
				};
			}

			return mytripVM;
		}
	}
}

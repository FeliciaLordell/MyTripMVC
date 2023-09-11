using MyTripMVC.Views.Travels;

namespace MyTripMVC.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public string AltTag { get; set; }
        public List<UserRestaurant> UserRestaurants { get; set; }

	}
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
		public string AltTag { get; set; }

		public List<UserActivity> UserActivities { get; set; }


    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Activity> Activities { get; set; }
        public List <Restaurant> Restaurants { get; set; }
    }

    public class UserActivity
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public ApplicationUser User { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public DateTime? Bookingdate { get; set; }
		public TimeSpan? BookingTime { get; set; }
	}
	public class UserRestaurant
	{
		public int Id { get; set; }
		public string IdUser { get; set; }
		public ApplicationUser User { get; set; }

		public int RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; }
		public DateTime? Bookingdate { get; set; }
		public TimeSpan? BookingTime { get; set; }
	}
}

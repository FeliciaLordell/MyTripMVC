using static MyTripMVC.Views.Travels.IndexVM;

namespace MyTripMVC.Views.Travels
{
    public class MytripVM
    {
        public Dictionary<string, RestaurantActivityGroupVM> CityGroups { get; set; }

        public class RestaurantActivityGroupVM
        {
            public RestaurantTripVM[] Restaurants { get; set; }
            public ActivityTripVM[] Activities { get; set; }
        }

        public class RestaurantTripVM
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int Id { get; set; }
            public DateTime? BookedDate { get; set; }
            public TimeSpan? BookedTime { get; set; }
        }

        public class ActivityTripVM
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int Id { get; set; }
			public DateTime? BookedDate { get; set; }
			public TimeSpan? BookedTime { get; set; }
		}
    }



}

namespace MyTripMVC.Views.Travels
{
    public class IndexVM
    {
        public RestaurantVM[] restaurants { get; set; }
        public ActivityVM[] activities { get; set; }
    public class RestaurantVM
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string AltTag { get; set; }

            public string CityName { get; set; }
            public int Id { get; set; }
        }

		public class ActivityVM
		{
			public string Name { get; set; }
            public string ImageUrl { get; set; }
			public string AltTag { get; set; }

			public string CityName { get; set; }
            public int Id { get; set; }
		}

	}


}

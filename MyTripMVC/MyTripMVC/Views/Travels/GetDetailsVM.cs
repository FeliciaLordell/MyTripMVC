using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyTripMVC.Views.Travels
{
	public class GetDetailsVM
	{
		[Required(ErrorMessage = "Hello man")]
        public string Name { get; set; }
		public string Description { get; set; }
        public string City { get; set; }
		public string Image { get; set; }
        public string AltTag { get; set; }
        public int Id { get; set; }
		public DateTime BookingDate { get; set; }
		public int NumberOfPeople { get; set; }

        public TimeSpan BookingTime { get; set; }

    }
}

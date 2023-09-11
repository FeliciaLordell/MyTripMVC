using System.ComponentModel.DataAnnotations;

namespace MyTripMVC.Views.Travels
{
	public class RegisterVM
	{
        [Required]
        [Display(Name = "Username")]

        public string UserName { get; set; }
        [Required]
		[EmailAddress(ErrorMessage ="Valid E-mail adress is required")]
		public string Email { get; set; }


		[Required]
		[Display(Name = "First Name")]

		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
      
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Repeat password")]
		[Compare(nameof(Password))]
		public string PasswordRepeat { get; set; }




	}
}

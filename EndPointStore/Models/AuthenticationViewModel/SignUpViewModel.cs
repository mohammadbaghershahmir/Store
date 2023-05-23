using Microsoft.AspNetCore.Mvc;

namespace EndPointStore.Models.AuthenticationViewModel
{
	public class SignUpViewModel
	{ 
		public string FullName { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RePassword { get; set; }
		
	}
}

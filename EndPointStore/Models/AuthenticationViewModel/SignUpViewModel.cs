using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace EndPointStore.Models.AuthenticationViewModel
{
	public class SignUpViewModel
	{
		[Required]
		public string FullName { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RePassword { get; set; }
		
	}
}

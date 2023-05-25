using Microsoft.Build.Framework;
namespace EndPointStore.Models.AuthenticationViewModel
{
	public class SignInViewModel
	{
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Url { get; set; } = "/";
    }
}

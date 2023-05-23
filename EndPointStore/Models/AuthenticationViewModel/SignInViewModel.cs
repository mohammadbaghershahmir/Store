namespace EndPointStore.Models.AuthenticationViewModel
{
	public class SignInViewModel
	{
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string Url { get; set; } = "/";
    }
}

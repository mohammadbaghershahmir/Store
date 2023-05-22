using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Store.Application.Services.Users.Command.Site.SignInUser;
using EndPointStore.Models.AuthenticationViewModel;
using Store.Application.Services.Users.Command.RegisterUser;

namespace EndPointStore.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly ISignInUserService _signInUserService;
		public AuthenticationController(ISignInUserService signInUserService)
		{
			_signInUserService = signInUserService;

		}
		[HttpGet]
		public async Task<IActionResult> SignIn()
		{
			return  View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn([FromBody]SignInViewModel Request)
		{
			var signeinResult =await _signInUserService.Execute(new RequestSignInUserDto
			{
				Email = Request.Email,
				Mobile = Request.Mobile,
				FullName = Request.FullName,
				Password = Request.Password,
				RePassword = Request.RePassword,
				RolesId = 3
			});

			if (signeinResult.IsSuccess == true)
			{
				var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier,signeinResult.Data.UserId.ToString()),
				new Claim(ClaimTypes.Email, Request.Email),
			    new Claim(ClaimTypes.MobilePhone, Request.Mobile),
				new Claim(ClaimTypes.Name, Request.FullName),
				new Claim(ClaimTypes.Role, "Customer"),
			};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties()
				{
					IsPersistent = true
				};
				//await HttpContext.SignInAsync(principal, properties);

			}
			return Json(signeinResult);
		}
	}
}

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Store.Application.Services.Users.Command.Site.SignInUser;
using EndPointStore.Models.AuthenticationViewModel;
using Store.Application.Services.Users.Command.RegisterUser;
using Microsoft.AspNetCore.Identity;
using Store.Common.Constant.Roles;
using Store.Application.Services.Users.Command.Site.SignUpUser;

namespace EndPointStore.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly ISignUpUserService _signUpUserService;
		private readonly ISignInUserService _signInUserService;
		public AuthenticationController(ISignUpUserService signUpUserService, ISignInUserService signInUserService)
		{
			_signUpUserService = signUpUserService;
			_signInUserService = signInUserService;
		}
		[HttpGet]
		public async Task<IActionResult> SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel Request)
		{
			var signeinResult = await _signUpUserService.Execute(new RequestSignUpUserDto
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
				 HttpContext.SignInAsync(principal, properties);

			}
			return Json(signeinResult);
		}
	
		public async Task<IActionResult> SignIn(string ReturnUrl = "/")
		{
			ViewBag.Url = ReturnUrl;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel signInUser)
		{
			var signIn =await _signInUserService.Execute(signInUser.UserName, signInUser.Password);
			if (signIn.IsSuccess == true)
			{
				var clims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier, signIn.Data.UserId.ToString()),
					new Claim(ClaimTypes.Email, signInUser.UserName),
					new Claim(ClaimTypes.Name, signIn.Data.FullName),
                        new Claim(ClaimTypes.Role, signIn.Data.Roles),
                };
				var identity = new ClaimsIdentity(clims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties()
				{
					IsPersistent = true,
					ExpiresUtc = DateTime.Now.AddDays(5),
				};
				 HttpContext.SignInAsync(principal, properties);
			}
			return Json(signIn);

		}
	}
}

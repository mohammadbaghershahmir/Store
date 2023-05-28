using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Store.Application.Services.Users.Command.Site.SignInUser;
using EndPointStore.Models.AuthenticationViewModel;
using Store.Application.Services.Users.Command.RegisterUser;
using Microsoft.AspNetCore.Identity;
using Store.Common.Constant.Roles;
using Store.Application.Services.Users.Command.Site.SignUpUser;
using Microsoft.AspNetCore.Authorization;
using Store.Domain.Entities.Users;
using Store.Common.Dto;
using Store.Common.Constant;
using Store.Application.Services.Users.Queries.GetRoles;

namespace EndPointStore.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly ISignUpUserService _signUpUserService;
		private readonly ISignInUserService _signInUserService;
		//private readonly SignInManager<Login> _signInManager;
        public AuthenticationController(ISignUpUserService signUpUserService, ISignInUserService signInUserService)
		{
			_signUpUserService = signUpUserService;
			_signInUserService = signInUserService;
			//_signInManager = signInManager;
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
				RolesId =UserRolesName.Customer
			});
			return Json(signeinResult);
		}
		[HttpGet]
		public IActionResult Login(string ReturnUrl = "/")
		{
			return View(new RequestSignInUserDto
            {
                Url = ReturnUrl,
            });
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(RequestSignInUserDto signInUser)
		{
		  var result=await _signInUserService.Execute(
			  new RequestSignInUserDto() {
				  Password = signInUser.Password
				  ,UserName=signInUser.UserName,
				  Url=signInUser.Url});
            HttpContext.Response.Cookies.Append(
            "cookieKey",
            "cookieValue",
            new CookieOptions { IsEssential = true }
        );
            return Json(result);
		}
	}
}

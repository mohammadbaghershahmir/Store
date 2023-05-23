using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands;
using Store.Application.Services.Commands.CheckEmail;
using Store.Application.Services.Commands.CheckUser;
using Store.Application.Services.Users.Command.EditUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Common.Constant;
using Store.Persistence.Contexs;

namespace EndPointStore.Areas.Admin.Controllers
{
	public class Common : Controller
	{
		private readonly ICheckUserExitsService _userExitsServices;
		private readonly ICheckEmailService _checkEmailService;
		private readonly ICheckMobileExitsService _checkMobileExitsService;

		public Common(ICheckUserExitsService userExitsServices,
			ICheckMobileExitsService checkMobileExitsService,
			ICheckEmailService checkEmailService

		)
		{
			_userExitsServices = userExitsServices;
			_checkEmailService = checkEmailService;
			_checkMobileExitsService = checkMobileExitsService;

		}
		public async Task<IActionResult> IsUserExits(string UserName)
		{
			var result = await _userExitsServices.Execute(UserName);
			if (result == null || result.Count <= 0)
			{

				return Json(true);
			}
			else return Json($"نام کاربری {UserName} تکراری است!");
		}
		public async Task<IActionResult> IsEmailExits(string Email, long Id)
		{
			var result = await _checkEmailService.Execute(Email, Id);
			if (result == null || result.Count <= 0)
			{

				return Json(true);
			}
			else return Json($"ایمیل {Email} تکراری است!");
		}
		public async Task<IActionResult> IsMobileExits(string Mobile, long Id)
		{
			var result = await _checkMobileExitsService.Execute(Mobile, Id);
			if (result == null || result.Count <= 0)
			{

				return Json(true);
			}
			else return Json($"شماره همراه {Mobile} تکراری است!");
		}

	}
}

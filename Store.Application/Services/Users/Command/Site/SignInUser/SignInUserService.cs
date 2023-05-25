using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.EditUser;
using Store.Common;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignInUser
{
	public class SignInUserService : ISignInUserService
	{
		private readonly IDatabaseContext _context;
		public SignInUserService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto<ResultUserLoginDto>> Execute(string username, string password)
		{
			//Query
			var user = await _context.Contacts.
				Include(w => w.User)
				.ThenInclude(u => u.UserInRoles)
				.ThenInclude(r=>r.Role)
				.Include(l => l.User)
				.ThenInclude(l => l.Logins)
				.Where(q => q.Value.Equals(username) && (q.ContactTypeId == (long)ContactTypeEnum.Email || q.ContactTypeId == (long)ContactTypeEnum.Mobail))
				.FirstOrDefaultAsync();
			//Check User
			if (user == null)
			{
				return new ResultDto<ResultUserLoginDto>()
				{
					Data = new ResultUserLoginDto()
					{

					},
					IsSuccess = false,
					Message = MessageInUser.MessageNotfindUser,
				};
			}
			//Check Password
			var verifyd = await _context.Logins.Where(t => t.UserId == user.UserId).FirstOrDefaultAsync();
			var passwordHasher = new PasswordHasher();
			bool resultVerifyPassword = passwordHasher.VerifyPassword(verifyd.Password, password);
			if (resultVerifyPassword == false)
			{
				return new ResultDto<ResultUserLoginDto>()
				{
					Data = new ResultUserLoginDto()
					{

					},
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidPass,
				};
			}
			//Check Role
			string roles = "";

			foreach (var item in user.User.UserInRoles)
			{
				roles += $"{item.Role.NameRole}";
            }

			//Login
			return new ResultDto<ResultUserLoginDto>()
			{
				Data = new ResultUserLoginDto()
				{
					Roles = roles,
					UserId = user.Id,
					FullName = user.User.FullName,
					UserName=user.Value
				},
				IsSuccess = true,
				Message = "ورود به سایت با موفقیت انجام شد",
			};
		}
	}
}

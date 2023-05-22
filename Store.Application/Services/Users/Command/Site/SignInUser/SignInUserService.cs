using Microsoft.AspNetCore.Identity;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
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
		public async Task<ResultDto<ResultRegisterUserDto>> Execute(RequestSignInUserDto Request)
		{
			try
			{
				if (Request.Password != Request.RePassword)
				{
					//Check Password
					return new ResultDto<ResultRegisterUserDto>()
					{
						Data = new ResultRegisterUserDto()
						{
							UserId = 0,
						},
						IsSuccess = false,
						Message = MessageInUser.MessagePass
					};
				}
				//Add User

				User user = new User()
				{
					FullName = Request.FullName,
					IsActive = true,
					InsertTime = DateTime.Now
				};
				await _context.Users.AddAsync(user);
				//Add  Mobile
				List<Contact> contact = new List<Contact>();
				contact.Add(new Contact()


				{

					ContactTypeId = (long)ContactTypeEnum.Mobail,
					User = user,
					UserId = user.Id,
					Value = Request.Mobile,
					Title = ContactsTypeTitle.Mobail
				}
					);
				//Add  Email
				contact.Add(new Contact()


				{
					ContactTypeId = (long)ContactTypeEnum.Email,
					User = user,
					UserId = user.Id,
					Value = Request.Email,
					Title = ContactsTypeTitle.Email
				}
				  );
				await _context.Contacts.AddRangeAsync(contact);
				//Add UserInRole
				List<UserInRole> userInRoles = new List<UserInRole>();
				userInRoles.Add(new UserInRole
				{
					
					RoleId =3,
					User = user,
					UserId = user.Id,
				});
				user.UserInRoles = userInRoles;
				await _context.UserInRoles.AddRangeAsync(userInRoles);
				//Hash Password
				var passwordHasher = new PasswordHasher();
				var hashedPassword = passwordHasher.HashPassword(Request.Password);
				//Add Login
				Login login = new Login()
				{
					User = user,
					UserId = user.Id,
					Password = hashedPassword
				};
				//Add SaveChanges
				await _context.Logins.AddAsync(login);
				await _context.SaveChangesAsync();
				//Show Result
				return new ResultDto<ResultRegisterUserDto>()
				{
					Data = new ResultRegisterUserDto()
					{
						UserId = user.Id,
					},
					IsSuccess = true,
					Message = MessageInUser.MessageInsert,
				};
			}
			catch (Exception)
			{
				return new ResultDto<ResultRegisterUserDto>()
				{
					Data = new ResultRegisterUserDto()
					{
						UserId = 0,
					},
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidOperation,
				};

			}
		}
	}
}

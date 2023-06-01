using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Common;
using Store.Common.Constant;
using Store.Common.Constant.Roles;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignUpUser
{
	public class SignUpUserService : ISignUpUserService
	{
		private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
		public SignUpUserService(IDatabaseContext context,UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_context = context;
            _userManager = userManager;
            _signInManager=signInManager;
		}
        public async Task<ResultDto<ResultRegisterUserDto>> Execute(RequestSignUpUserDto Request)
        {
            string message = "";
            try
            {
                //Add User
                User user = new User()
                {
                    FullName = Request.FullName,
                    IsActive = true,
                    InsertTime = DateTime.Now,
                    Email=Request.Email,
                    PhoneNumber=Request.Mobile,
                    UserName=Request.Email,
                    
                };
                //Add User
                var result = _userManager.CreateAsync(user, Request.Password).Result;
                //Check Result
               if(result.Succeeded)
                {
					//Add UserInRole
					var resultrole = await _userManager.AddToRoleAsync(user, UserRolesName.Customer);
                    //Login User
                    await   _signInManager.SignOutAsync();
                    var SignIn = _signInManager.PasswordSignInAsync(user, Request.Password, false, true).Result;
                    if (SignIn.Succeeded)
                    {
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
                }
				return new ResultDto<ResultRegisterUserDto>()
				{
					Data = new ResultRegisterUserDto()
					{
						UserId = "",
					},
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidOperation
				};
			}
            catch (Exception)
            {
				//foreach (var item in ex.Errors.ToList())
				//{
				//	message += item.Description + Environment.NewLine;
				//}
				return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId ="",
                    },
                    IsSuccess = false,
                    Message = message,
                };
            }
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.EditUser;
using Store.Common;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignInUser
{
	public class SignInUserService : ISignInUserService
	{
		
		private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
		public SignInUserService(SignInManager<User> signInManager,UserManager<User> userManager)
		{
			_userManager= userManager;
            _signInManager = signInManager;
		}
        public async Task<ResultDto<ResultUserLoginDto>> Execute(RequestSignInUserDto request)
        {
            //Query
            var user=await _userManager.FindByEmailAsync(request.UserName);
            var pass = await _userManager.CheckPasswordAsync(user,request.Password);
            var GetRol = await _userManager.GetRolesAsync(user);
            //Check User
            if (user==null)
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

            try
            {
                if (pass)
                {
                    var result = _signInManager.SignInAsync(user, true, authenticationMethod:null);
                    {
                        List<string> roles = new List<string>();
                        //Check Role
                        try
                        {
                           
                            roles.AddRange(GetRol);

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        //Login
                        return new ResultDto<ResultUserLoginDto>()
                        {
                            Data = new ResultUserLoginDto()
                            {
                                Roles = roles,
                                UserId = user.Id,
                                FullName = user.FullName,
                                UserName = user.UserName
                            },
                            IsSuccess = true,
                            Message = "ورود به سایت با موفقیت انجام شد",
                        };
                        //if (!result.Succeeded)
                        //{
                        //    //foreach (var item in result.ToList())
                        //    //{
                        //    //	message += item.Description + Environment.NewLine;
                        //    //}
                        //}
                    }
                }
                
            }
            catch (AggregateException ex)
            {

              
            }
	
			return new ResultDto<ResultUserLoginDto>()
			{
				Data = new ResultUserLoginDto()
				{
					
					UserId = user.Id,
					FullName = user.FullName,
					UserName = user.UserName
				},
				IsSuccess = true,
				Message = MessageInUser.MessageInvalidOperation,
			};



		}
    }
}

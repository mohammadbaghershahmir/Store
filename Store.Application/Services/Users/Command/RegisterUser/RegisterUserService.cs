using Store.Common;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.AspNetCore.Identity;

namespace Store.Application.Services.Users.Command.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly UserManager<User> _userManager;
        public RegisterUserService(UserManager<User> UserManager)
        {
            _userManager = UserManager;
        }

        public async Task<ResultDto<ResultRegisterUserDto>> Execute(RequestRegisterUserDto request)
        {
            try
            {
                User newUser = new User()
                {
                    FirstName = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.Email,
                    Gender = request.Gender,
                    FullName = request.Name + " " + request.LastName,
                    InsertTime = DateTime.Now,
                    PhoneNumber = request.Mobile,
                    IsActive = request.IsActive,
                };
                //Add User
                var result = _userManager.CreateAsync(newUser, request.Password).Result;
                //Add Contact
                //List<Contact> contact = new List<Contact>();
                //if (request.Phone.Trim().Length > 0)
                //{
                //    contact.Add(new Contact()


                //    {
                //        ContactTypeId = (int)ContactTypeEnum.Phone,
                //        User =newUser ,
                //        //UserId = newUser.Id,
                //        Value = request.Phone,
                //        Title = ContactsTypeTitle.Phone
                //    }
                //       );
                //}
                //Add UserInRole
                var UserInRole = _userManager.AddToRolesAsync(newUser, request.Roles).Result;
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = newUser.Id,
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
                        UserId = "",
                    },
                    IsSuccess = false,
                    Message = MessageInUser.MessageInvalidOperation,
                };
            }
        }

        //public async Task<ResultDto<ResultRegisterUserDto>> Execute(RequestRegisterUserDto request)
        //{
        //    try
        //    {
        //        //Check Password
        //        if (request.Password != request.RePassword)
        //        {
        //            return new ResultDto<ResultRegisterUserDto>()
        //            {
        //                Data = new ResultRegisterUserDto()
        //                {
        //                    UserId = 0,
        //                },
        //                IsSuccess = false,
        //                Message = MessageInUser.MessagePass
        //            };
        //        }
        //        //Add User
        //        User user = new User()
        //        {
        //            Name = request.Name,
        //            LastName = request.LastName,
        //            Gender = request.Gender,
        //            IsActive = request.IsActive,
        //            FullName = request.Name + " " + request.LastName,
        //            InsertTime = DateTime.Now
        //        };
        //        //Add UserInRole
        //        List<UserInRole> userInRoles = new List<UserInRole>();
        //        foreach (var item in request.RolesId)
        //        {
        //            var roles = _context.Roles.Find(item);
        //            userInRoles.Add(new UserInRole()
        //            {
        //                Role = roles,
        //                RoleId = roles.Id,
        //                User = user,
        //                UserId = roles.Id,
        //            });
        //        }
        //        //Add Contacts And Check Email&&Mobile
        //        List<Contact> contact = new List<Contact>();
        //        contact.Add(new Contact()


        //        {

        //            ContactTypeId = (long)ContactTypeEnum.Mobail,
        //            User = user,
        //            UserId = user.Id,
        //            Value = request.Mobile,
        //            Title = ContactsTypeTitle.Mobail
        //        }
        //            );
       
        //        if (request.Address.Trim().Length > 0)
        //        {
        //            contact.Add(new Contact()


        //            {
        //                ContactTypeId = (long)ContactTypeEnum.Address,
        //                User = user,
        //                UserId = user.Id,
        //                Value = request.Address,
        //                Title = ContactsTypeTitle.Address
        //            }
        //               );
        //        }
        //        contact.Add(new Contact()


        //        {
        //            ContactTypeId = (long)ContactTypeEnum.Email,
        //            User = user,
        //            UserId = user.Id,
        //            Value = request.Email,
        //            Title = ContactsTypeTitle.Email
        //        }
        //           );
        //        user.UserInRoles = userInRoles;
        //        //HashedPassword
        //        var passwordHasher = new PasswordHasher();
        //        var hashedPassword = passwordHasher.HashPassword(request.Password);
        //        //Add Login
        //        Login login = new Login()
        //        {
        //            User = user,
        //            UserId = user.Id,
        //            UserName = request.UserName,
        //            Password = hashedPassword
        //        };
        //        //Add And SaveChanges
        //        await _context.Users.AddAsync(user);
        //        await _context.Logins.AddAsync(login);
        //        await _context.UserInRoles.AddRangeAsync(userInRoles);
        //        await _context.Contacts.AddRangeAsync(contact);
        //        await _context.SaveChangesAsync();
        //        //Show Result
        //        return new ResultDto<ResultRegisterUserDto>()
        //        {
        //            Data = new ResultRegisterUserDto()
        //            {
        //                UserId = user.Id,
        //            },
        //            IsSuccess = true,
        //            Message = MessageInUser.MessageInsert,
        //        };
        //    }
        //    catch (Exception)
        //    {

        //        return new ResultDto<ResultRegisterUserDto>()
        //        {
        //            Data = new ResultRegisterUserDto()
        //            {
        //                UserId = 0,
        //            },
        //            IsSuccess = false,
        //            Message = MessageInUser.MessageInvalidOperation,
        //        };
        //    }


        //}
    }
}

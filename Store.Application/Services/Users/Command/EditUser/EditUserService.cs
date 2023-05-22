using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Common.Constant;
using Store.Common.Constant.Roles;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Store.Application.Services.Users.Command.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;
        public EditUserService(IDatabaseContext context)
        {
            _context = context;
        }


        public async Task<ResultDto> Execute(EditUserDto requestEditUserService)
        {
            var usrlist =await _context.Users.Include(p => p.Logins)
                         .Include(p => p.Contacts)
                         .Include(p => p.UserInRoles)
                         .Where(p => p.Id == requestEditUserService.Id)
                         .FirstOrDefaultAsync();

            if (usrlist == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }

            //Remove Contacts
            var contactList = usrlist.Contacts.ToList();
            _context.Contacts.RemoveRange(contactList);
            await _context.SaveChangesAsync();

            //add contact
            List<Contact> contact = new List<Contact>();
            if (requestEditUserService.Mobile.Trim().Length > 0)
            {
                contact.Add(new Contact()
                {

                    ContactTypeId = (long)ContactTypeEnum.Mobail,
                    UserId = requestEditUserService.Id,
                    Value = requestEditUserService.Mobile,
                    Title = ContactsTypeTitle.Mobail
                }
                );
            }
            if (requestEditUserService.Phone.Trim().Length > 0)
            {
                contact.Add(new Contact()
                {
                    ContactTypeId = (long)ContactTypeEnum.Phone,

                    UserId = requestEditUserService.Id,
                    Value = requestEditUserService.Phone,
                    Title = ContactsTypeTitle.Phone
                }
                   );
            }
            if (requestEditUserService.Address.Trim().Length > 0)
            {
                contact.Add(new Contact()
                {
                    ContactTypeId = (long)ContactTypeEnum.Address,

                    UserId = requestEditUserService.Id,
                    Value = requestEditUserService.Address,
                    Title = ContactsTypeTitle.Address
                }
                   );
            }
            if (requestEditUserService.Email.Trim().Length > 0)
            {
                contact.Add(new Contact()
                {
                    ContactTypeId = (long)ContactTypeEnum.Email,

                    UserId = requestEditUserService.Id,
                    Value = requestEditUserService.Email,
                    Title = ContactsTypeTitle.Email
                }
               );
            }
            await _context.Contacts.AddRangeAsync(contact);

            //Remove Contacts
            var userInRollsList = usrlist.UserInRoles.ToList();
            _context.UserInRoles.RemoveRange(userInRollsList);
            await _context.SaveChangesAsync();


            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach (var item in requestEditUserService.IdesInRole)
            {
                var roles = _context.Roles.Find(item);
                _context.UserInRoles.Add(new UserInRole()
                {

                    RoleId = roles.Id,
                    //User = user,
                    UserId = requestEditUserService.Id,
                });
            }
            usrlist.Name = requestEditUserService.Name;
            usrlist.LastName = requestEditUserService.LastName;
            usrlist.FullName = requestEditUserService.Name + " " + requestEditUserService.LastName;
            usrlist.IsActive = requestEditUserService.IsActive;
            usrlist.Gender = requestEditUserService.Gender;
            usrlist.UpdateTime = DateTime.Now;
           await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageUpdate
            };
        }
    }
}

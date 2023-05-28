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

        public async Task<ResultDto> Execute(EditUserDto EditUserService)
        {
            throw new NotImplementedException();
        }


        //public async Task<ResultDto> Execute(EditUserDto EditUserService)
        //{
        //    var usrlist = await _context.Users.Include(p => p.Logins)
        //                 .Include(p => p.Contacts)
        //                 .Include(p => p.UserInRoles)
        //                 .Where(p => p.Id == EditUserService.Id)
        //                 .FirstOrDefaultAsync();
        //    //Chck Null ListUser
        //    if (usrlist == null)
        //    {
        //        return new ResultDto
        //        {
        //            IsSuccess = false,
        //            Message = MessageInUser.MessageNotFind
        //        };
        //    }

        //    //Remove Contacts
        //    var contactList = usrlist.Contacts.ToList();
        //    _context.Contacts.RemoveRange(contactList);
        //    await _context.SaveChangesAsync();

        //    //Add contact
        //    List<Contact> contact = new List<Contact>();
        //    if (EditUserService.Mobile.Trim().Length > 0)
        //    {
        //        contact.Add(new Contact()
        //        {

        //            ContactTypeId = (long)ContactTypeEnum.Mobail,
        //            UserId = EditUserService.Id,
        //            Value = EditUserService.Mobile,
        //            Title = ContactsTypeTitle.Mobail
        //        }
        //        );
        //    }
        //    if (EditUserService.Phone.Trim().Length > 0)
        //    {
        //        contact.Add(new Contact()
        //        {
        //            ContactTypeId = (long)ContactTypeEnum.Phone,

        //            UserId = EditUserService.Id,
        //            Value = EditUserService.Phone,
        //            Title = ContactsTypeTitle.Phone
        //        }
        //           );
        //    }
        //    if (EditUserService.Address.Trim().Length > 0)
        //    {
        //        contact.Add(new Contact()
        //        {
        //            ContactTypeId = (long)ContactTypeEnum.Address,

        //            UserId = EditUserService.Id,
        //            Value = EditUserService.Address,
        //            Title = ContactsTypeTitle.Address
        //        }
        //           );
        //    }
        //    if (EditUserService.Email.Trim().Length > 0)
        //    {
        //        contact.Add(new Contact()
        //        {
        //            ContactTypeId = (long)ContactTypeEnum.Email,

        //            UserId = EditUserService.Id,
        //            Value = EditUserService.Email,
        //            Title = ContactsTypeTitle.Email
        //        }
        //       );
        //    }
        //    await _context.Contacts.AddRangeAsync(contact);

        //    //Remove Contacts
        //    var userInRollsList = usrlist.UserInRoles.ToList();
        //    _context.UserInRoles.RemoveRange(userInRollsList);
        //    await _context.SaveChangesAsync();

        //    //Add UserInRole
        //    List<UserInRole> userInRoles = new List<UserInRole>();
        //    foreach (var item in EditUserService.IdesInRole)
        //    {
        //        var roles = _context.Roles.Find(item);
        //        _context.UserInRoles.Add(new UserInRole()
        //        {

        //            RoleId = roles.Id,
        //            UserId = EditUserService.Id,
        //        });
        //    }
        //    //Add UsersEdit
        //    usrlist.Name = EditUserService.Name;
        //    usrlist.LastName = EditUserService.LastName;
        //    usrlist.FullName = EditUserService.Name + " " + EditUserService.LastName;
        //    usrlist.IsActive = EditUserService.IsActive;
        //    usrlist.Gender = EditUserService.Gender;
        //    usrlist.UpdateTime = DateTime.Now;
        //    await _context.SaveChangesAsync();
        //    //Show Result
        //    return new ResultDto()
        //    {
        //        IsSuccess = true,
        //        Message = MessageInUser.MessageUpdate
        //    };
        //}
    }
}

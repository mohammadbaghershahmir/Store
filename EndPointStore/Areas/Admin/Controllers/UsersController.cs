using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckEmail;
using Store.Application.Services.Commands.CheckUser;
using Store.Application.Services.Users.Command.DeleteUser;
using Store.Application.Services.Users.Command.EditUser;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System.ComponentModel;
using System.Reflection;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly IGetUsersServices _usersServices;
        private readonly IGetRolesService _rolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveService _removeService;
        private readonly IGetEditUserService _geteditUserService;
        private readonly IEditUserService _editUserService;
        private readonly ICheckEmailService _checkEmailService;
        private readonly IDatabaseContext _databaseContext;
        public UsersController(IGetUsersServices getUsersServices,
            IGetRolesService rolesService
            , IRegisterUserService registerUserService
            , IRemoveService removeService
            , IGetEditUserService geteditUserService
            , IEditUserService editUserService
            , ICheckEmailService checkEmailService
            , IDatabaseContext databaseContext
            )
        {
            _rolesService = rolesService;
            _usersServices = getUsersServices;
            _registerUserService = registerUserService;
            _removeService = removeService;
            _geteditUserService = geteditUserService;
            _editUserService = editUserService;
            _checkEmailService = checkEmailService;
            _databaseContext = databaseContext;

        }
        public async Task<IActionResult> Index(string serchkey, int page = 1)
        {
            var t = await _usersServices.Execute(

                new RequestGetUsersDto
                {

                    Page = page,
                    SearchKey = serchkey,
                }
                );
            return View(await _usersServices.Execute(

                new RequestGetUsersDto
                {

                    Page = page,
                    SearchKey = serchkey,
                }
                ));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_rolesService.Execute().Data, "Id", "Title");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _registerUserService.Execute(new RequestRegisterUserDto
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Password = request.Password,
                    RePassword = request.RePassword,
                    IsActive = request.IsActive,
                    Gender = request.Gender,
                    Mobile = request.Mobile,
                    Email = request.Email,
                    Address = request.Address,
                    Phone = request.Phone,
                    RolesId = request.RolesId,
                }
               );
                return Json(result);
            }
            return Json(new ResultDto
            {
                IsSuccess = false,
                Message = "ثبت ناموفق"
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long UserId)
        {
            return Json(await _removeService.Execute(UserId));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            ViewBag.Roles = new SelectList(_rolesService.Execute().Data, "Id", "Title");
            var result = await _geteditUserService.Execute(Id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditUserDto request)
        {
            var result = await _editUserService.Execute(new EditUserDto
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Gender = request.Gender,
                IsActive = request.IsActive,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                Mobile = request.Mobile,
                IdesInRole = request.IdesInRole
            }
           );
            return Json(new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageUpdate
            });
        }
    }
}

using Store.Persistence.Contexs;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Command.DeleteUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Application.Services.Users.Command.EditUser;
using Store.Application.Services.Commands.CheckUser;
using Store.Application.Services.Commands.CheckEmail;
using Store.Application.Services.Commands;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Store.Application.Services.Users.Command.Site.SignUpUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net;
using Store.Domain.Entities.Users;
using Identity.Bugeto.Helpers;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.FileManager.Queries.ListDirectory;
using Store.Application.Services.FileManager.Commands.CreateDirectory;
using Store.Application.Services.FileManager.Commands.UploadFiles;
using Store.Application.Services.FileManager.Commands.RemoveFiles;
using Store.Application.Services.ProductsSite.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.ProductsSite.FacadPatternSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using Store.Application.Services.UsersAddress.Commands.AddAddressServiceForSite;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;
using Store.Application.Services.UsersAddress.Commands.EditAddressServiceForSite;
using Store.Application.Services.UsersAddress.Commands.RemoveAddressService_ForSite;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CmsConnectionString")));
builder.Services.AddIdentity<User, Role>(
    options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DatabaseContex>()
              .AddDefaultTokenProviders();
builder.Services.AddDistributedMemoryCache();
//Scopeds
builder.Services.AddScoped<IDatabaseContext, DatabaseContex>();
builder.Services.AddScoped<IGetUsersServices, GetUsersServices>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveService, RemoveUserService>();
builder.Services.AddScoped<IGetEditUserService, GetEditUserService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<ICheckUserExitsService, CheckUserService>();
builder.Services.AddScoped<ICheckEmailService, CheckEmailService>();
builder.Services.AddScoped<ICheckMobileExitsService, CheckMobileService>();
builder.Services.AddScoped<ICheckEmailService, CheckEmailService>();
builder.Services.AddScoped<ISignUpUserService, SignUpUserService>();
builder.Services.AddScoped<ISignInUserService, SignInUserService>();
builder.Services.AddScoped<IlogOutUser, LogOutUserService>();
builder.Services.AddScoped<IFileDirectoryService, FileDirectoryServices>();
builder.Services.AddScoped<ICreateDirectory, CreateDirectoryService>();
builder.Services.AddScoped<IUploadFileService, UploadFileService>();
builder.Services.AddScoped<IRemoveFilesOrDirectoriesService, RemoveFilesOrDirectoriesService>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IProductFacadSite, ProductFacadSite>();
builder.Services.AddScoped<IGetCategorySiteService, GetCategorySiteService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IGetProvinceServices, GetProvinceServices>();
builder.Services.AddScoped<IGetCityService, GetCityService>();
builder.Services.AddScoped<IGetCityForPayServices, GetCityForPayServices>();
builder.Services.AddScoped<IAddAddressServiceForSite, AddAddressServiceForSite>(); 
builder.Services.AddScoped<IGetAddressUserForSite, GetAddressUserForSite>();
builder.Services.AddScoped<IGetEditAddressUserForSite, GetEditAddressUserForSite>();
builder.Services.AddScoped<IEditAddressUserForSite, EditAddressUserForSite>();
builder.Services.AddScoped<IRemoveAddressUserForSite, RemoveAddressUserForSite>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
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

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CmsConnectionString")));
//Scopeds
builder.Services.AddScoped<IDatabaseContext, DatabaseContex>();
builder.Services.AddScoped<IGetUsersServices, GetUsersServices>();
builder.Services.AddScoped<IGetRolesService,GetRolesService>();
builder.Services.AddScoped<IRegisterUserService,RegisterUserService>();
builder.Services.AddScoped<IRemoveService, RemoveUserService>();
builder.Services.AddScoped<IGetEditUserService, GetEditUserService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<ICheckUserExitsService,CheckUserService>();
builder.Services.AddScoped<ICheckEmailService, CheckEmailService>();
builder.Services.AddScoped<ICheckMobileExitsService, CheckMobileService>();
builder.Services.AddScoped<ICheckEmailService,CheckEmailService>();
builder.Services.AddScoped<ISignUpUserService, SignUpUserService>();
builder.Services.AddScoped<ISignInUserService, SignInUserService>();
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

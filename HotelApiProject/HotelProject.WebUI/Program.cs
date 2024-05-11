using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.MessageServices;
using HotelProject.WebUI.Models.Mail;
using HotelProject.WebUI.ValidationRules.GuestVL;
using HotelProject.WebUI.ValidationRules.MailVL;
using HotelProject.WebUI.ValidationRules.RegisterVL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
//Burada yazdýðýn kodlarýn doðruluðuyla birlite sýrasý da önemlidir unutma
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
///// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program)); //dto da eþleþtirdiðim classlar için kullandýk

//Dtolarý Validation iþlemleri için eþleþtirme
builder.Services.AddTransient<IValidator<CreateGuestDto>, GuestCreateValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, GuestUpdateValidator>();
builder.Services.AddTransient<IValidator<AdminMailViewModel>, MailPostValidator>();
///

//#region oturum yönetimi
//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
//#endregion




//NotificationService
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireDigit = false;
})
.AddPasswordValidator<RegisterCreateValidator>()
.AddEntityFrameworkStores<Context>();

//Authorization iþleminin devamý
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

///Authorization iþleminde login path verme
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Login/Index/";
});

//serilog start
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//serilog end

builder.Host.UseSerilog((hostcontext, services, configuration) =>
{
    configuration.WriteTo.Console().WriteTo.File("C:\\Users\\baran\\Desktop\\logs\\log.txt", rollingInterval: RollingInterval.Day);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Error page kullanýmý
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();

//Proje seviyesinde Authorize iþlemi
app.UseAuthentication();

//app.UseSession();


app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(

        name: "default",

        pattern: "{controller=Dashboard}/{action=Index}/{id?}");

});

app.Run();

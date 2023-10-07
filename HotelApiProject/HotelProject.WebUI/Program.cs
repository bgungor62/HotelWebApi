using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program)); //dto da eþleþtirdiðim classlar için kullandýk
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

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
    configuration.WriteTo.Console().WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(

        name: "default",

        pattern: "{controller=Staf}/{action=Index}/{id?}");

});

app.Run();

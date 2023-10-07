using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Swagger da yazdýðýmýz kodlarý görebilmek için bu tanýmlamalarý yazarýz
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal, EFStaffDal>();
builder.Services.AddScoped<IStaffService, StaffManager>();

//Room
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IRoomDal, EFRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

//Testimonial
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ITestimonialsDal, EFTestimonialsDal>();
builder.Services.AddScoped<ITestimonialsService, TestimonialsManager>();

//Service
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IServiceDal, EFServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

//subscribe
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ISubscribeDal, EFSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

//about
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

//booking
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

//contact
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


//Automapper
builder.Services.AddAutoMapper(typeof(Program));



//InMemoryCache
builder.Services.AddMemoryCache();
//InMemoryCache end






////Serilog Host Start
builder.Host.UseSerilog((hostcontext, services, configuration) =>
{
    configuration.WriteTo.Console().WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);

});

/// end






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("ApiAltYapi", opts =>
    {
        opts.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
var app = builder.Build();


app.UseCors("OtelApiCors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

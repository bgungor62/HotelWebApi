using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//Swagger da yazdýðýmýz kodlarý görebilmek için bu tanýmlamalarý yazarýz

//staff
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal, EFStaffDal>();
builder.Services.AddScoped<IStaffService, StaffManager>();

//room
builder.Services.AddScoped<IRoomDal, EFRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

//testimonial
builder.Services.AddScoped<ITestimonialsDal, EFTestimonialsDal>();
builder.Services.AddScoped<ITestimonialsService, TestimonialsManager>();

//Service
builder.Services.AddScoped<IServiceDal, EFServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

//subscribe
builder.Services.AddScoped<ISubscribeDal, EFSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

//about
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

//booking
builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

//contact
builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

//guest
builder.Services.AddScoped<IGuestDal, EFGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

//sendmessage
builder.Services.AddScoped<ISendMessageDal, EFSendMessageDal>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();

//messagecategory
builder.Services.AddScoped<IMessageCategoryDal, EFMessageCategoryDal>();
builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

//worklocation
builder.Services.AddScoped<IWorkLocationDal, EFWorkLocationDal>();
builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();

//appusers
builder.Services.AddScoped<IAppUserDal, EFAppUserDal>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();



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
//end

builder.Services.AddControllers().AddNewtonsoftJson(
    opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    )
    .AddOData(conf =>
    {
        conf.Filter().Count();
    });
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


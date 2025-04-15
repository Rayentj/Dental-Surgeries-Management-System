using AutoMapper;
using DentalApp.Api.Mapper;
using DentalApp.Data.Repositories;
using DentalApp.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Add support for both API and MVC Views
builder.Services.AddControllers();            // For API controllers
builder.Services.AddControllersWithViews();   // For Razor Views

// ? EF Core DB Context
builder.Services.AddDbContext<DentalAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Swagger (API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ? AutoMapper config
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ? Register your repositories and services
DependencyContainer.RegisterService(builder.Services);

var app = builder.Build();

// ? Use Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Available at /swagger
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ? Enable serving static files (CSS, JS for views)

app.UseRouting();
app.UseAuthorization();

// ? Routing setup
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}");

// ? Still map all API controllers
app.MapControllers(); // Your API controllers work as usual

app.Run();

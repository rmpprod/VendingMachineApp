using Microsoft.EntityFrameworkCore;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Infrastructure;
using VendingMachineApp.Server.Interfaces;
using VendingMachineApp.Server.Repositories;
using VendingMachineApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VendingMachineContext>(options => options.UseSqlServer(connectionStr));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IIncludeableRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Drink>, DrinkRepository>();
builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();
builder.Services.AddScoped<IRepository<OrderItem>, OrderItemsRepository>();
builder.Services.AddScoped<IRepository<Coin>, CoinRepository>();
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AdminService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

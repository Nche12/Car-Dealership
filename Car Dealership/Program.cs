global using Microsoft.EntityFrameworkCore;
global using Car_Dealership.Models;
global using Car_Dealership.Interfaces;
global using Car_Dealership.Data;
global using Car_Dealership.Services;
global using Microsoft.AspNetCore.Mvc;
global using Car_Dealership.DTOs.User;
global using Car_Dealership.DTOs.UserRole;
global using Car_Dealership.DTOs.CarMake;
global using Car_Dealership.DTOs.CarModel;
global using Car_Dealership.DTOs.TransmissionType;
global using Car_Dealership.DTOs.FuelType;
global using Car_Dealership.DTOs.SeatType;
global using Car_Dealership.DTOs.CarType;
global using Car_Dealership.DTOs.DriveType;
global using Car_Dealership.DTOs.CarColour;
global using Car_Dealership.DTOs.Client;
global using Car_Dealership.DTOs.Frequency;
global using Car_Dealership.DTOs.AdvertisingPlatform;

global using AutoMapper;
global using Car_Dealership;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TenantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<ICarMakeService, CarMakeService>();
builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();
builder.Services.AddScoped<ISeatTypeService, SeatTypeService>();
builder.Services.AddScoped<ICarTypeService, CarTypeService>();
builder.Services.AddScoped<ICarDriveTypeService, CarDriveTypeService>();
builder.Services.AddScoped<ICarColourService, CarColourService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFrequencyService, FrequencyService>();
builder.Services.AddScoped<IAdvertPlatformService, AdvertPlatformService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:5168", "https://localhost:7196")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

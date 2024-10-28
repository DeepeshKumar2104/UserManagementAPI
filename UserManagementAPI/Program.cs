using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;
using UserManagementAPI.Repository.Interface;
using UserManagementAPI.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Db");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Database connection string is missing or empty.");
}

builder.Services.AddDbContext<Project5Context>(options =>
    options.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString))
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthInterface , AuthServices>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

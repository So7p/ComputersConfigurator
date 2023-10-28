using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.IoC;
using ComputerStore.Application.Services;
using ComputerStore.Infastructure.IoC;
using ComputerStore.Infastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Charting;
using System.Reflection;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(Assembly.Load("ComputerStore.Application"));

builder.Services.ConfigureServices();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbContext();
builder.Services.ConfigureUnitOfWork();

builder.Services.AddCors(opt => opt.AddPolicy("AllowAllPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

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

using ComputerStore.Application.Common.Interfaces.Services;
using ComputerStore.Application.IoC;
using ComputerStore.Application.Services;
using ComputerStore.Infastructure.IoC;
using ComputerStore.Infastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddInfastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(Assembly.Load("ComputerStore.Application"));

/*builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IModelService, ModelService>();*/

builder.Services.ConfigureServices();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbContext();
builder.Services.ConfigureUnitOfWork();

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

using ExamenFinal.Interfaces;
using ExamenFinal.Persistence;
using ExamenFinal.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection_string));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPreguntasService, PreguntasService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

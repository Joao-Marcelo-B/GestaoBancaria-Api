using Data;
using GestaoBancariaApi.Data;
using GestaoBancariaApi.Models;
using GestaoBancariaApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connUserString = builder.Configuration
    .GetConnectionString("UsuarioConnection");

string connClienteString = builder.Configuration
    .GetConnectionString("ClienteConnection");


builder.Services.AddDbContext<UsuarioDbContext>
    (opts =>
    {
        opts.UseMySql(connUserString,
            ServerVersion.AutoDetect(connUserString));
    });

builder.Services.AddDbContext<ClienteContext>
    (opts =>
    {
        opts.UseMySql(connClienteString,
            ServerVersion.AutoDetect(connClienteString));
    });

builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper
    (AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioService>();

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

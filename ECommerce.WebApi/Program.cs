using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Business.DependencyResolvers.Autofac;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Autofac container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Autofac modülünü 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{

    builder.RegisterModule(new AutofacBusinessModule());
    builder.RegisterModule(new AutofacAutoMapperModule());
});
builder.Services.AddCors(a =>
{
    a.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddCors();

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

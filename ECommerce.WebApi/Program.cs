using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Business.AutoMapper;
using ECommerce.Business.DependencyResolvers.Autofac;
using System.ComponentModel;
using System.Text.Json.Serialization;

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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Angular uygulamanýzýn URL'si
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

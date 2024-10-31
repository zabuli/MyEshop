using System.Reflection;
using MyEshop.Application.Services;
using MyEshop.Core.Interfaces;
using MyEshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyEshop.Infrastructure;
using MyEshop.TestUtilities.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

var useMockData = builder.Configuration.GetValue<bool>("UseMockData");

if (useMockData)
{
    builder.Services.AddTransient<IProductRepository, MockProductRepository>();
}
else
{
    builder.Services.AddDbContext<MyEshopDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyEshopDB")));
    
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
}

builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyEshop API", Version = "v1" });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Test"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Eshop API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

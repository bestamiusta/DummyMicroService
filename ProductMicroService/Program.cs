using Microsoft.EntityFrameworkCore;
using ProductMicroService.DbContexts;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ProductMicroService.Repository;

/* azure deploy user guide from https://www.youtube.com/watch?v=MP4zatl3jF8&ab_channel=kudvenkat
 * simple microservice sample demonstrated from https://www.c-sharpcorner.com/article/microservice-using-asp-net-core/
 * 
 * **/



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

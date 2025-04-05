using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductApi.ProductApi.Domain.Interfaces;
using ProductApi.ProductApi.Infrastructure;
using ProductApi.ProductApi.Infrastructure.Data;
using ProductApi.ProductApi.Infrastructure.Repositories;
using ProductApi.Services;


var builder = WebApplication.CreateBuilder(args);


// Ba�lant� dizesini appsettings.json dosyas�ndan al�yoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i ve SQL Server ba�lant�s�n� yap�land�r�yoruz (LocalDB)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Services katman�nda ProductService'i ekliyoruz
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Controllers kullanmak i�in gerekli servisleri ekliyoruz
builder.Services.AddControllers();
// Swagger servislerini ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Bu sat�r, Swagger i�in gerekli servisi ekler


// ProductSeeder'� DI konteynerine kaydedelim
builder.Services.AddScoped<ProductSeeder>();

var app = builder.Build();
// Swagger'� sadece geli�im ortam�nda kullanmak i�in
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Veritaban� verisi eklemek i�in Seeder'� �al��t�ral�m
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ProductSeeder>();
    await seeder.SeedAsync();
}


// Hata y�netimi i�in gerekli middleware ekliyoruz
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// API'yi �al��t�rabilmek i�in gerekli olan endpointleri tan�ml�yoruz
app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductApi.ProductApi.Domain.Interfaces;
using ProductApi.ProductApi.Infrastructure;
using ProductApi.ProductApi.Infrastructure.Data;
using ProductApi.ProductApi.Infrastructure.Repositories;
using ProductApi.Services;


var builder = WebApplication.CreateBuilder(args);


// Baðlantý dizesini appsettings.json dosyasýndan alýyoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i ve SQL Server baðlantýsýný yapýlandýrýyoruz (LocalDB)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Services katmanýnda ProductService'i ekliyoruz
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Controllers kullanmak için gerekli servisleri ekliyoruz
builder.Services.AddControllers();
// Swagger servislerini ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Bu satýr, Swagger için gerekli servisi ekler


// ProductSeeder'ý DI konteynerine kaydedelim
builder.Services.AddScoped<ProductSeeder>();

var app = builder.Build();
// Swagger'ý sadece geliþim ortamýnda kullanmak için
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Veritabaný verisi eklemek için Seeder'ý çalýþtýralým
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ProductSeeder>();
    await seeder.SeedAsync();
}


// Hata yönetimi için gerekli middleware ekliyoruz
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// API'yi çalýþtýrabilmek için gerekli olan endpointleri tanýmlýyoruz
app.MapControllers();

app.Run();

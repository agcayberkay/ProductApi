# 🛍️ Product API

Bu proje, ürünlerin listelenmesi, eklenmesi, güncellenmesi ve silinmesi gibi temel işlemleri gerçekleştiren bir RESTful Web API'dir. Katmanlı mimari kullanılarak .NET Core teknolojisi ile geliştirilmiştir.

## 🚀 Özellikler

- Ürün listeleme (GET)
- Ürün ekleme (POST)
- Ürün güncelleme (PUT)
- Ürün silme (DELETE)
- Katmanlı mimari (N Katmanlı Mimari)
- Entity Framework Core ile veritabanı işlemleri
- Swagger ile API dokümantasyonu
- Hata yönetimi ve validasyon desteği

## 🧱 Kullanılan Teknolojiler

- .NET 6 / .NET 7
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger (Swashbuckle)

## 📂 Proje Yapısı

ProductApi
│
├── ProductApi.API --> API Katmanı (Controller'lar)
├── ProductApi.Application --> İş kuralları (Service, DTO, Validasyonlar)
├── ProductApi.Domain --> Entity'ler ve Interface'ler
├── ProductApi.Infrastructure--> Repository, DbContext
└── ProductApi.Persistence --> Veritabanı işlemleri ve konfigürasyonlar



## ⚙️ Kurulum

1. Bu repoyu klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/product-api.git
   
2. appsettings.json dosyasındaki veritabanı bağlantı cümlesini kendi ortamınıza göre güncelleyin.

3. Migration oluşturup veritabanını güncelleyin:
dotnet ef migrations add InitialCreate
dotnet ef database update

4. Uygulamayı çalıştırın:
dotnet run

5. Swagger arayüzü ile test etmek için tarayıcınızda şu adresi açın:
http://localhost:5000/swagger

📌 Notlar
Bu proje eğitim ve geliştirme amacıyla hazırlanmıştır.

Yeni özellikler eklenebilir ve projeye katkı sağlanabilir.

JWT ile kimlik doğrulama ve Unit Test altyapısı isteğe bağlı olarak entegre edilebilir.

🤝 Katkı Sağlamak
Pull request gönderebilir veya issue oluşturarak katkı sağlayabilirsiniz.

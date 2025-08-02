👤 Identity API Projesi
Bu proje, ASP.NET Core ile hazırlanmış temel bir Identity API uygulamasıdır.
📌 Amaç: Kullanıcı kayıt ve giriş işlemlerini güvenli şekilde gerçekleştirmek.

🔧 Kullanılan Teknolojiler
ASP.NET Core 8 💻

Entity Framework Core ⚙️

SQL Server 🗄️

Identity Library 🔐

Swagger (API testleri için) 📘

🚀 Özellikler
✅ Kullanıcı Kaydı (Register)
→ Email ve şifre ile kayıt olunur.
→ Şifreler Identity üzerinden hashlenerek saklanır.

✅ Giriş (Login)
→ Email ve şifreyle kimlik doğrulama yapılır.
→ Hatalı girişlerde uyarı mesajı döner.

✅ Kullanıcı Listeleme (Get Users)
→ Tüm kullanıcılar JSON formatında görüntülenebilir.

📁 Proje Yapısı
Dtos/ → Register ve Login için veri taşıma sınıfları

Context/ → EF Core ile Identity veritabanı konfigürasyonu

Controllers/AccountsController.cs → API uç noktaları


📝 Notlar
🔐 Şifreleme, ASP.NET Core Identity tarafından otomatik yapılmaktadır.
📌 Bu projede default IdentityUser sınıfı kullanılmıştır.


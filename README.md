# SoftITo Backend 2026

Bu repo, SoftITo 2026 eğitim sürecinde geliştirilen 10 adet ASP.NET Core projesini içermektedir. Her proje, bir öncekinin üzerine yeni bir teknoloji veya mimari yaklaşım ekleyerek ilerlemektedir.

## Projeler

### 📘 Proje 1 — Öğrenci Sistemi
**Teknoloji:** ASP.NET Core MVC · EF Core Code-First · SQL Server  
Öğrenci yönetim sistemi. Code-First yaklaşımıyla veritabanı şeması oluşturulmuş; öğrenciler için tam CRUD desteği sağlanmıştır.

### 🏥 Proje 2 — Hastane Sistemi
**Teknoloji:** ASP.NET Core MVC · EF Core Db-First · SQL Server  
Hastane yönetim sistemi. Mevcut bir veritabanından Db-First yaklaşımıyla oluşturulmuş modeller üzerine kurulmuştur. Hastalar, doktorlar ve randevular için işlemler içerir.

### 📦 Proje 3 — Stok Kontrol Sistemi
**Teknoloji:** ASP.NET Core Razor Pages · SQL Server  
Stok takip uygulaması. Razor Pages modeli kullanılarak geliştirilmiş, sayfa tabanlı CRUD ve filtreleme özellikleri içermektedir.

### 📚 Proje 4 — Kütüphane Sistemi
**Teknoloji:** ASP.NET Core MVC · EF Core Code-First · N-Katmanlı Mimari  
Kütüphane yönetim sistemi. Proje; N-katmanlı mimariyle geliştirilmiştir. Kitaplar, üyeler ve ödünç alma işlemleri için gelişmiş yönetim ekranları sunar.

### 🏨 Proje 5 — Otel Sistemi
**Teknoloji:** ASP.NET Core MVC · EF Core · AJAX  
Otel rezervasyon ve yönetim sistemi. Sayfayı yenilemeden işlemlerin yapılabilmesi için yoğun AJAX kullanılmıştır. Müşteri, oda ve rezervasyon yönetimi içerir.

### 🛒 Proje 6 — Dapper E-Ticaret
**Teknoloji:** ASP.NET Core MVC · Dapper · SQL Server  
E-ticaret platformu. Veri tabanı işlemleri için mikro ORM aracı olan Dapper kullanılarak yüksek performans hedeflenmiştir. Ürün ve kategori yönetimini içerir.

### 💼 Proje 7 — Proje Yönetim Sistemi (HR Project)
**Teknoloji:** ASP.NET Core MVC · EF Core  
İnsan kaynakları ve proje takip sistemi. Personeller, görevler ve projeler arası ilişkiler kurularak yönetim sağlanmıştır.

### 🚗 Proje 8 — Araç Kiralama Sistemi
**Teknoloji:** ASP.NET Core Web API · ASP.NET Core MVC · EF Core  
Araç kiralama platformu. Arka planda Web API hizmetleri çalışırken, ön yüzde MVC ile istemci tarafı geliştirilmiş ve API-MVC haberleşmesi kullanılmıştır.

### 🏢 Proje 9 — Emlak Yönetim Sistemi
**Teknoloji:** ASP.NET Core MVC · N-Katmanlı Mimari · Repository Pattern · Unit of Work · Identity  
Kapsamlı emlak ilan sistemi. Gelişmiş N-Katmanlı Mimari, Generic Repository Pattern, Unit of Work ve ASP.NET Core Identity kullanılarak endüstri standartlarında inşa edilmiştir.

### 🚀 Proje 10 — Bitirme Projesi (Hastane Yönetim Sistemi)
**Teknoloji:** ASP.NET Core Web API · ASP.NET Core MVC · EF Core · Dapper · JWT  
SoftITo 2026 Backend Projeleri (Bitirme Projesi). Çok katmanlı mimariyle geliştirilmiş; arka planda JWT güvenliğine sahip bir RESTful Web API, ön tarafta ise HttpClient ile haberleşen bir MVC istemcisi bulunmaktadır. Performans kritik noktalarda Stored Procedure ve Dapper kullanılmıştır.

## ⚙️ Gereksinimler
- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server / LocalDB
- Visual Studio 2022+ veya VS Code

## 🚀 Çalıştırma
Projeleri Visual Studio'da açarak veya terminalden ilgili `.csproj` dizinine gidip aşağıdaki komutu kullanarak çalıştırabilirsiniz:

```bash
dotnet run
```
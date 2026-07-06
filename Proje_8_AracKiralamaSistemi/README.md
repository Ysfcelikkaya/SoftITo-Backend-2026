<div align="center">

# 🚗 ARAÇ KİRALAMA SİSTEMİ 🔑
### Car Rental System

[![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)]()

<p align="center">
  <b>Dapper mikro ORM ile geliştirilmiş, API/MVC ayrık mimarili modern araç kiralama uygulaması.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Öne Çıkan Özellikler](#-öne-çıkan-özellikler)
- [🛠 Kullanılan Teknolojiler](#-kullanılan-teknolojiler-ve-stack)
- [📂 Proje Klasör Yapısı](#-proje-klasör-yapısı)
- [💻 Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [🚀 Kurulum Adımları](#-kurulum-adımları)

---

## 🎯 PROJE HAKKINDA

Bu proje, kullanıcıların araç kiralama işlemlerini kolayca ve hızlı bir şekilde gerçekleştirebileceği, yenilikçi ve modern bir web uygulamasıdır.

Sistem, birbirinden bağımsız iki temel yapı taşı olan **Web API** ve **MVC (Model-View-Controller)** projeleri şeklinde .NET 8 kullanılarak geliştirilmiştir.

---

## ✨ ÖNE ÇIKAN ÖZELLİKLER

Sistem, araç kiralama akışını kolaylaştıran temel modüllerden oluşur:

### 🔍 1. Araç Listeleme Modülü
- 📋 **Detaylı Listeleme:** Sistemdeki tüm araçları, özellikleri ve güncel durumlarıyla görüntüleyebilme.

### 📅 2. Kiralama ve Rezervasyon Modülü
- 🗓️ **Tarih Bazlı Kiralama:** Belirli tarih aralıkları için kolayca araç kiralayabilme altyapısı.

### ⚡ 3. Performans Katmanı
- 🚀 **Yüksek Hız:** Backend tarafında **Dapper (Mikro ORM)** kullanılarak veritabanı işlemlerinde maksimum hız ve verimlilik.

### 💻 4. Kullanıcı Arayüzü Modülü
- 🎨 **Kullanıcı Dostu Tasarım:** .NET MVC kullanılarak geliştirilmiş, akıcı bir kullanıcı deneyimi.

### 📚 5. API Dokümantasyon Modülü
- 🔴 **Canlı Dokümantasyon:** Swagger arayüzü ile API servislerinin anlık testi ve dokümantasyonu.

---

## 🛠 KULLANILAN TEKNOLOJİLER VE STACK

### ⚙️ Backend (AracKiralamaApi)

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| 🌐 **Framework** | `.NET 8.0 Web API` | RESTful servis mimarisi. |
| 💽 **Veritabanı** | `Microsoft SQL Server (LocalDB)` | İlişkisel veritabanı yönetimi. |
| ⚡ **ORM** | `Dapper` | Hızlı ve hafif mikro ORM ile veritabanı erişimi. |
| 📚 **Dokümantasyon** | `Swashbuckle (Swagger UI)` | API servislerinin anlık testi ve dokümantasyonu. |

### 🖥️ Frontend (AracKiralamaMvc)

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| 🌐 **Framework** | `.NET 8.0 MVC` | Model-View-Controller mimarisi. |
| 🔄 **İstemci İşlemleri** | `Newtonsoft.Json` | API'den gelen JSON verilerinin işlenmesi. |
| 🗄️ **ORM (Opsiyonel)** | `Entity Framework Core` | Altyapıda ileri dönük olarak hazır bulundurulmaktadır. |

---

## 📂 PROJE KLASÖR YAPISI

Proje, birbirinden bağımsız iki ana klasörden oluşmaktadır:

```text
📁 AracKiralama-main/
│
├── 📁 AracKiralamaApi/      # Backend API Projesi
│   ├── 📁 Controllers/      # API Endpoint'leri
│   ├── 📁 Models/           # Veri Modelleri
│   ├── 📁 Data/             # Dapper Veritabanı Bağlantı ve İşlemleri
│   └── 📄 appsettings.json  # Veritabanı Connection String Ayarları
│
└── 📁 AracKiralamaMvc/      # Frontend Web Projesi
    ├── 📁 Controllers/      # MVC Kontrolcüleri (API Tüketimi vb.)
    ├── 📁 Views/            # Kullanıcı Arayüzü (HTML/CSS/Razor)
    └── 📁 Models/           # View Modelleri
```

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
- 🛢️ **SQL Server** (veya Visual Studio ile gelen LocalDB)
- 💻 **IDE:** Visual Studio 2022 (Önerilen) veya Visual Studio Code.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi Bilgisayarınıza İndirin

Projeyi Git üzerinden klonlayın veya ZIP olarak indirip klasöre çıkartın.

### Adım 2: Veritabanı Bağlantısını Ayarlayın

`AracKiralamaApi/AracKiralamaApi/appsettings.json` dosyasını açın ve `ConnectionStrings` altındaki `Default` bağlantı ayarının sisteminize (SQL Server) uygun olduğundan emin olun.

> *Varsayılan olarak LocalDB ayarlıdır:* `Server=(localdb)\MSSQLLocalDB;Database=AracKiralama;TrustServerCertificate=true;`

### Adım 3: API'yi Başlatın

Öncelikle **AracKiralamaApi** projesini derleyip çalıştırın. Tarayıcınızda otomatik olarak API dokümantasyonu olan `Swagger UI` ekranı açılacaktır.

### Adım 4: Web Arayüzünü (MVC) Başlatın

API projesi arka planda çalışmaya devam ederken, **AracKiralamaMvc** projesini çalıştırın. Web uygulaması tarayıcınızda açılacak ve sistem kullanıma hazır olacaktır.


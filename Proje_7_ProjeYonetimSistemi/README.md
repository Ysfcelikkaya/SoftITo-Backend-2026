<div align="center">

# 🚀 PROJE YÖNETİM SİSTEMİ 📁
### Project Management System

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC_%26_API-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet)
[![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-ORM-3B82F6?style=for-the-badge&logo=nuget)](https://docs.microsoft.com/en-us/ef/core/)

<p align="center">
  <b>Modern, modüler ve güvenli proje, görev ve geliştirici yönetim platformu.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Detaylı Özellikler](#-detaylı-özellikler)
- [🏗️ Proje Mimarisi](#️-proje-mimarisi)
- [🛠 Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [📂 Klasör Yapısı](#-klasör-yapısı)
- [🚀 Kurulum Adımları](#-kurulum-adımları)

---

## 🎯 PROJE HAKKINDA

**Proje Yönetim Sistemi**, yazılım ekiplerinin projelerini, görevlerini ve kaynaklarını tek bir merkezden kolayca yönetmelerini sağlayan kapsamlı bir çözümdür.

Mimari olarak **Backend (Web API)** ve **Frontend (MVC)** olmak üzere iki ayrı katmandan oluşmaktadır. Bu sayede servis tabanlı, ölçeklenebilir ve esnek bir yapı sunar.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, proje yönetim akışını kolaylaştıran temel modüllerden oluşur:

### 🧑‍💻 1. Geliştirici Yönetimi Modülü
- 📌 **Geliştirici Ekleme:** Geliştiricileri sisteme ekleme, güncelleme ve takip etme.

### 📁 2. Proje Yönetimi Modülü
- 🆕 **Proje Oluşturma:** Yeni projeler oluşturma, mevcut projeleri düzenleme ve detaylandırma.

### ✅ 3. Görev (Task) Takip Modülü
- 🎯 **Görev Atama:** Projelere ve geliştiricilere özel görevler atama.
- 📊 **Durum İzleme:** Görev durumlarının izlenmesi.

### 🔐 4. Rol ve Kullanıcı Yönetimi Modülü
- 🔑 **Güvenli Oturum:** Güvenli oturum açma ve kullanıcı yetkilendirme.
- 🛡️ **Rol Tabanlı Erişim:** Users ve Roles modelleri ile rol tabanlı erişim kontrolü (MVC projesinde).

### 🔌 5. RESTful API Mimarisi
- 🌐 **API Uç Noktaları:** Dış sistemler ve frontend ile tam entegre çalışabilen güçlü API uç noktaları.

### 🗄️ 6. Code-First Veritabanı Modülü
- ⚙️ **Otomatik Yönetim:** Entity Framework Core ile model üzerinden otomatik veritabanı yönetimi ve migrasyonlar.

---

## 🏗️ PROJE MİMARİSİ

Proje, birbiriyle haberleşen 2 ana bileşenden oluşmaktadır:

1. ⚙️ **HrProjectApi:** RESTful standartlarına uygun olarak geliştirilmiş ASP.NET Core Web API uygulaması. Veritabanı işlemleri ve iş mantığı bu katmanda yürütülür.
2. 🖥️ **HrProjectMvc:** Kullanıcı arayüzünü (UI) barındıran ASP.NET Core MVC uygulaması. API ile haberleşerek son kullanıcıya veri sunar ve kullanıcı işlemlerini alır.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Dil** | `C#` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **Framework** | `.NET Core (ASP.NET Core MVC & Web API)` | İki katmanlı servis tabanlı mimari. |
| 🗄️ **ORM** | `Entity Framework Core` | Code-First yaklaşımı ile veritabanı yönetimi. |
| 💽 **Veritabanı** | `SQL Server` | Appsettings üzerinden değiştirilebilir yapı. |
| 🏛️ **Mimari** | `N-Tier Architecture`, `REST API` | Servis tabanlı, ölçeklenebilir ve esnek yapı. |

---

## 📂 KLASÖR YAPISI

Proje dizin yapısı, katmanlı (N-Tier) mimari standartlarına sadık kalınarak oluşturulmuştur:

```bash
📦 ProjeYonetimSistemi-main
 ┣ 📂 HrProject
 ┃ ┣ 📂 HrProjectApi   # Backend REST API Uygulaması
 ┃ ┃ ┣ 📂 Controllers  # API Endpoint'leri
 ┃ ┃ ┣ 📂 Models       # Veritabanı Tablo Modelleri (Developers, Projects, Tasks vb.)
 ┃ ┃ ┣ 📂 Migrations   # EF Core Migrasyon Dosyaları
 ┃ ┃ ┗ 📜 Program.cs   # API Konfigürasyonları
 ┃ ┗ 📂 HrProjectMvc   # Frontend MVC Uygulaması
 ┃   ┣ 📂 Controllers  # Sayfa Yönlendirmeleri ve API İstekleri
 ┃   ┣ 📂 Models       # View Modelleri ve Veri Modelleri
 ┃   ┣ 📂 Views        # Kullanıcı Arayüzü (HTML/CSS/JS)
 ┃   ┗ 📜 Program.cs   # MVC Konfigürasyonları
 ┗ 📜 README.md        # Proje Dokümantasyonu
```

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Depoyu Klonlayın

```bash
git clone https://github.com/KullaniciAdi/ProjeYonetimSistemi.git
cd ProjeYonetimSistemi-main/HrProject
```

### Adım 2: Veritabanı Bağlantı Ayarlarını Yapılandırın

API ve MVC projelerinin kök dizinindeki `appsettings.json` ve `appsettings.Development.json` dosyalarını açarak kendi SQL Server bağlantı dizesini (`ConnectionStrings`) güncelleyin.

### Adım 3: Veritabanı Migrasyonlarını Uygulayın

API projesi dizininde terminali açıp aşağıdaki komutu çalıştırarak veritabanını oluşturun:

```bash
cd HrProjectApi/HrProjectApi
dotnet ef database update
```

### Adım 4: Projeleri Ayağa Kaldırın

Projenin tam anlamıyla çalışması için hem API hem de MVC projelerinin aynı anda ayağa kalkması gereklidir. Visual Studio kullanıyorsanız çözüm (Solution) özelliklerinden **"Multiple startup projects"** (Çoklu başlangıç projeleri) seçeneğini aktif edip her iki projeyi de aynı anda başlatabilirsiniz.

Terminal üzerinden başlatmak için, iki ayrı terminal penceresi açmanız gerekir:

**API için:**

```bash
cd HrProjectApi/HrProjectApi
dotnet run
```

**MVC için:** *(Yeni bir terminalde)*

```bash
cd HrProjectMvc/HrProjectMvc
dotnet run
```

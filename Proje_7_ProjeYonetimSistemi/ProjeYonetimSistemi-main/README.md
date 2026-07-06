<div align="center">
  <h1>🚀 Proje Yönetim Sistemi</h1>
  <p>Modern, modüler ve güvenli proje, görev ve geliştirici yönetim platformu.</p>
  
  [![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
  [![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
  [![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC_%26_API-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet)
  [![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-ORM-3B82F6?style=for-the-badge&logo=nuget)](https://docs.microsoft.com/en-us/ef/core/)
</div>

<br/>

## 📖 Proje Hakkında

**Proje Yönetim Sistemi**, yazılım ekiplerinin projelerini, görevlerini ve kaynaklarını tek bir merkezden kolayca yönetmelerini sağlayan kapsamlı bir çözümdür. 

Mimari olarak **Backend (Web API)** ve **Frontend (MVC)** olmak üzere iki ayrı katmandan oluşmaktadır. Bu sayede servis tabanlı, ölçeklenebilir ve esnek bir yapı sunar.

## ✨ Temel Özellikler

- **🧑‍💻 Geliştirici Yönetimi:** Geliştiricileri sisteme ekleme, güncelleme ve takip etme.
- **📁 Proje Yönetimi:** Yeni projeler oluşturma, mevcut projeleri düzenleme ve detaylandırma.
- **✅ Görev (Task) Takibi:** Projelere ve geliştiricilere özel görevler atama, görev durumlarını izleme.
- **🔐 Rol ve Kullanıcı Yönetimi:** Güvenli oturum açma, kullanıcı yetkilendirme ve rol tabanlı erişim kontrolü (MVC projesinde yer alan Users ve Roles modelleri ile).
- **🔌 RESTful API Mimarisi:** Dış sistemler ve frontend ile tam entegre çalışabilen güçlü API uç noktaları.
- **🗄️ Code-First Veritabanı:** Entity Framework Core ile model üzerinden otomatik veritabanı yönetimi ve migrasyonlar.

## 🏗️ Proje Mimarisi

Proje 2 ana bileşenden oluşmaktadır:

1. ⚙️ **HrProjectApi**: RESTful standartlarına uygun olarak geliştirilmiş ASP.NET Core Web API uygulaması. Veritabanı işlemleri ve iş mantığı bu katmanda yürütülür.
2. 🖥️ **HrProjectMvc**: Kullanıcı arayüzünü (UI) barındıran ASP.NET Core MVC uygulaması. API ile haberleşerek son kullanıcıya veri sunar ve kullanıcı işlemlerini alır.

## 💻 Kullanılan Teknolojiler

- **Dil:** C#
- **Framework:** .NET Core (ASP.NET Core MVC & Web API)
- **ORM:** Entity Framework Core
- **Veritabanı:** SQL Server (Appsettings üzerinden değiştirilebilir)
- **Mimari:** N-Tier Architecture, REST API

## 📂 Klasör Yapısı

```bash
📦 ProjeYonetimSistemi-main
 ┣ 📂 HrProject
 ┃ ┣ 📂 HrProjectApi  # Backend REST API Uygulaması
 ┃ ┃ ┣ 📂 Controllers # API Endpoint'leri
 ┃ ┃ ┣ 📂 Models      # Veritabanı Tablo Modelleri (Developers, Projects, Tasks vb.)
 ┃ ┃ ┣ 📂 Migrations  # EF Core Migrasyon Dosyaları
 ┃ ┃ ┗ 📜 Program.cs  # API Konfigürasyonları
 ┃ ┗ 📂 HrProjectMvc  # Frontend MVC Uygulaması
 ┃   ┣ 📂 Controllers # Sayfa Yönlendirmeleri ve API İstekleri
 ┃   ┣ 📂 Models      # View Modelleri ve Veri Modelleri
 ┃   ┣ 📂 Views       # Kullanıcı Arayüzü (HTML/CSS/JS)
 ┃   ┗ 📜 Program.cs  # MVC Konfigürasyonları
 ┗ 📜 README.md       # Proje Dokümantasyonu
```

## 🚀 Kurulum ve Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

### 1. Depoyu Klonlayın
```bash
git clone https://github.com/KullaniciAdi/ProjeYonetimSistemi.git
cd ProjeYonetimSistemi-main/HrProject
```

### 2. Veritabanı Bağlantı Ayarları
API ve MVC projelerinin kök dizinindeki `appsettings.json` ve `appsettings.Development.json` dosyalarını açarak kendi SQL Server bağlantı dizesini (`ConnectionStrings`) güncelleyin.

### 3. Veritabanı Migrasyonları
API projesi dizininde terminali açıp aşağıdaki komutu çalıştırarak veritabanını oluşturun:
```bash
cd HrProjectApi/HrProjectApi
dotnet ef database update
```

### 4. Projeleri Ayağa Kaldırın
Projenin tam anlamıyla çalışması için hem API hem de MVC projelerinin aynı anda ayağa kalkması gereklidir. Visual Studio kullanıyorsanız çözüm (Solution) özelliklerinden **"Multiple startup projects"** (Çoklu başlangıç projeleri) seçeneğini aktif edip her iki projeyi de aynı anda başlatabilirsiniz.
Terminal üzerinden başlatmak için:

**API için:**
```bash
cd HrProjectApi/HrProjectApi
dotnet run
```

**MVC için:** (Yeni bir terminalde)
```bash
cd HrProjectMvc/HrProjectMvc
dotnet run
```

## 🤝 Katkıda Bulunma

1. Bu depoyu forklayın.
2. Yeni bir özellik dalı oluşturun (`git checkout -b ozellik/YeniOzellik`).
3. Değişikliklerinizi commit'leyin (`git commit -m 'Harika bir özellik eklendi'`).
4. Dalınızı gönderin (`git push origin ozellik/YeniOzellik`).
5. Bir Pull Request oluşturun.

## 📄 Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. İstediğiniz gibi kullanabilir ve geliştirebilirsiniz.

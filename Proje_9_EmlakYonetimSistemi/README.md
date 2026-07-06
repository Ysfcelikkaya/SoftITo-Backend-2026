<div align="center">

# 🏠 EMLAK YÖNETİM SİSTEMİ 🏢
### Real Estate Management System

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![Entity Framework Core](https://img.shields.io/badge/Entity_Framework-Core-0078D7?style=for-the-badge&logo=dotnet)]()
[![Architecture](https://img.shields.io/badge/Architecture-N--Tier-FF6F00?style=for-the-badge)]()

<p align="center">
  <b>ASP.NET Core MVC ve Entity Framework Core ile geliştirilmiş kapsamlı bir gayrimenkul yönetim platformu.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Öne Çıkan Özellikler](#-öne-çıkan-özellikler)
- [🏗️ Mimari ve Teknolojiler](#️-mimari-ve-teknolojiler)
- [📂 Proje Dizin Yapısı](#-proje-dizin-yapısı)
- [🚀 Kurulum Adımları](#-kurulum-adımları)

---

## 🎯 PROJE HAKKINDA

**Emlak Yönetim Sistemi**, gayrimenkul danışmanlarının ve kullanıcıların emlak alım-satım ve kiralama süreçlerini dijital ortamda yönetmelerini sağlayan modern bir web uygulamasıdır.

Kullanıcı dostu arayüzü ve güçlü altyapısı sayesinde ilan yönetimi, randevu takibi ve favori ilanları kaydetme gibi işlemleri hızlı ve güvenilir bir şekilde gerçekleştirmenizi sağlar.

---

## ✨ ÖNE ÇIKAN ÖZELLİKLER

Sistem, emlak yönetim akışını kolaylaştıran 5 temel modülden oluşur:

### 🔑 1. Kullanıcı & Rol Yönetimi Modülü
- 👥 **Yetki Seviyeleri:** Müşteri ve Yönetici (Admin) olmak üzere farklı yetki seviyelerine sahip gelişmiş kullanıcı rolleri.

### 🏢 2. Detaylı İlan Yönetimi Modülü
- 📌 **İlan Oluşturma:** Satılık, kiralık vb. farklı emlak tipleri için görsel destekli, detaylı ilan oluşturma.
- 🔄 **Düzenleme ve Silme:** İlanların düzenlenmesi ve sistemden kaldırılması.

### 📅 3. Randevu Sistemi Modülü
- 🗓️ **Takvim Entegrasyonu:** Kullanıcıların ilgilendikleri gayrimenkuller için sistem üzerinden takvim entegreli randevu talep edebilmesi.

### ❤️ 4. Favoriler Modülü
- ⭐ **İlan Favorileme:** Ziyaretçilerin beğendikleri ilanları kendi listelerine ekleyerek daha sonra kolayca ulaşabilmesi.

### 🛠️ 5. Yönetim Paneli (Admin) Modülü
- 🎛️ **Merkezi Kontrol:** Yöneticilerin sistemdeki tüm ilanları, onay bekleyenleri, kullanıcıları ve randevuları merkezi olarak kontrol edebileceği arayüz.

---

## 🏗️ MİMARİ VE TEKNOLOJİLER

Proje, sürdürülebilir, test edilebilir ve genişletilebilir bir yapı kurmak adına modern yazılım mimarisi prensipleriyle (S.O.L.I.D) geliştirilmiştir.

### 📐 Katmanlı Mimari (N-Tier Architecture)

| Katman | Sorumluluk |
|---|---|
| 🌐 `EmlakProjectORM` | Sunum ve Arayüz Katmanı / Web |
| 🧱 `EmlakProjectORM.Models` | Domain Varlıkları / Entities |
| 💾 `EmlakProjectORM.Data` | Veri Erişim Katmanı / Data Access |

### 🧩 Tasarım Şablonları (Design Patterns)

- **Repository Pattern:** Veritabanı işlemlerini soyutlayarak tekrar kullanılabilir ve test edilebilir bir yapı sunar.
- **Unit of Work Pattern:** Veritabanı transaction işlemlerini tek bir merkezden yöneterek veri tutarlılığını garanti altına alır.

### 🛠 Kullanılan Teknolojiler

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `ASP.NET Core MVC` | Model-View-Controller mimarisi. |
| 🗄️ **ORM** | `Entity Framework Core` | Code-First yaklaşımı ile veritabanı yönetimi. |
| 💽 **Veritabanı** | `MS SQL Server` | İlişkisel veritabanı yönetimi. |

---

## 📂 PROJE DİZİN YAPISI

Proje dizin yapısı, katmanlı (N-Tier) mimari standartlarına sadık kalınarak oluşturulmuştur:

```bash
📦 EmlakYonetimSistemi
 ┣ 📂 EmlakProjectORM         # MVC Projesi (Controllers, Views, wwwroot, Program.cs)
 ┣ 📂 EmlakProjectORM.Models  # Veritabanı Sınıfları (AppUser, Property, Appointment vb.)
 ┗ 📂 EmlakProjectORM.Data    # Veritabanı Context'i, Repository ve UoW Sınıfları
```

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi İndirin

```bash
git clone https://github.com/kullaniciadi/EmlakYonetimSistemi.git
cd EmlakYonetimSistemi
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

`EmlakProjectORM` projesi içerisindeki `appsettings.json` veya `appsettings.Development.json` dosyasını açarak `DefaultConnection` connection string'ini kendi yerel SQL Server ayarlarınıza göre güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmlakYonetimDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### Adım 3: Veritabanını Oluşturun (Migrations)

Visual Studio üzerinde "Package Manager Console"u (PMC) açıp, Default Project olarak `EmlakProjectORM.Data`'yı seçerek şu komutu çalıştırın:

```powershell
Update-Database
```

Veya .NET CLI kullanıyorsanız terminalden şu komutu girin:

```bash
dotnet ef database update --project EmlakProjectORM.Data --startup-project EmlakProjectORM
```

### Adım 4: Projeyi Başlatın

Visual Studio üzerinden projeyi `F5` ile başlatabilirsiniz. Terminal kullanıyorsanız:

```bash
cd EmlakProjectORM
dotnet run
```

Proje genellikle `https://localhost:5001` veya `http://localhost:5000` adresinde ayağa kalkacaktır.

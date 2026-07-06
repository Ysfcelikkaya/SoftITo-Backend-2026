<div align="center">

# 📚 KÜTÜPHANE SİSTEMİ 📖
### Library Management System

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_MVC-Core-blue?style=for-the-badge&logo=windows-terminal&logoColor=white)]()
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-CodeFirst-34A853?style=for-the-badge&logo=nuget&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()
[![QuestPDF](https://img.shields.io/badge/QuestPDF-Reporting-red?style=for-the-badge)]()

<p align="center">
  <b>Kitap, yazar, kategori ve kullanıcı yönetimini sağlayan modern ve katmanlı mimariye sahip kütüphane otomasyon yazılımı.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Detaylı Özellikler](#-detaylı-özellikler)
- [🛠 Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [💻 Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [🚀 Kurulum Adımları](#-kurulum-adımları)
- [🗂️ Proje Mimarisi](#️-proje-mimarisi)

---

## 🎯 PROJE HAKKINDA

**Kütüphane Sistemi**, `ASP.NET Core MVC` ve `Entity Framework Core` kullanılarak geliştirilmiş, kitap, yazar, kategori ve kullanıcı yönetimini sağlayan modern ve **katmanlı (N-Tier) mimariye** sahip bir otomasyon projesidir.

Proje, veritabanı işlemlerinde **Code-First** yaklaşımını benimser ve gelişmiş raporlama modülleri (PDF/Excel) sayesinde veritabanındaki verilerin farklı formatlarda dışa aktarılmasına imkân tanır.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, kütüphane yönetim akışını kolaylaştıran temel modüllerden oluşur:

### 📚 1. Kitap Yönetimi Modülü
- 📌 **Yeni Kitap Kaydı:** Sisteme yeni kitap ekleme işlemleri.
- 🔄 **Bilgi Güncelleme:** Mevcut kitap bilgilerinin düzenlenmesi.
- 🗑️ **Kitap Silme:** Sistemden kitap kaydı silme işlemleri.
- 📋 **Kitap Listeleme:** Tüm kitapların listelenmesi.

### ✍️ 2. Yazar ve Kategori Yönetimi Modülü
- 🖋️ **Yazar Takibi:** Kitaplara ait yazar bilgilerinin detaylı takibi.
- 🏷️ **Kategori Yönetimi:** Kitap kategorilerinin tanımlanması ve düzenlenmesi.
- ♻️ **Tam CRUD Desteği:** Ekle / Oku / Güncelle / Sil işlemlerinin tamamı.

### 👥 3. Kullanıcı Yönetimi Modülü
- 🔐 **Kayıt & Giriş:** Kullanıcı (Account) kayıt ve giriş işlemleri.
- 🔑 **Oturum Yönetimi:** Kullanıcı oturumlarının güvenli bir şekilde yönetilmesi.

### 📊 4. Detaylı Raporlama Modülü
- 📄 **PDF Çıktısı:** `QuestPDF` entegrasyonu ile veritabanındaki verilerin PDF formatında detaylı raporlanması.
- 📈 **Excel Çıktısı:** `EPPlus` kullanılarak kitap ve istatistik verilerinin Excel formatında dışa aktarımı.

### 🏗️ 5. N-Tier (Katmanlı) Mimari
- `Kutuphane.Data`: Veritabanı bağlamı (Context) ve migration işlemleri.
- `Kutuphane.Model`: Veritabanı tablolarına karşılık gelen nesne modelleri (Entity).
- `KutuphaneSistemi`: Web arayüzü (UI), Controller katmanı ve iş mantığı.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `.NET 10.0` | ASP.NET Core MVC ile güçlü sunucu tarafı. |
| 🗄️ **ORM** | `Entity Framework Core 10.0.9` | Code-First yaklaşımı ile SQL-Nesne bağdaştırması. |
| 💽 **Veritabanı** | `Microsoft SQL Server` | İlişkisel veritabanı yönetimi. |
| 📄 **Raporlama (PDF)** | `QuestPDF` | Veritabanı verilerinin PDF formatında raporlanması. |
| 📈 **Raporlama (Excel)** | `EPPlus` | Kitap ve istatistik verilerinin Excel'e aktarımı. |
| 🎨 **Frontend** | `HTML5`, `CSS3`, `Razor Views` | Görünüm motoru olarak Razor Views kullanımı. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **[.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)**
- 🛢️ **SQL Server** (LocalDB veya tam sürüm)
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen) veya Visual Studio Code.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi Klonlayın

```bash
git clone <repo-url>
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

`KutuphaneSistemi/appsettings.json` dosyası içerisindeki `ConnectionStrings` bölümünü, kendi yerel SQL Server instance'ınıza göre güncelleyin.

### Adım 3: Migration'ları Uygulayın (Veritabanını Oluşturun)

Proje dizininde (Solution düzeyinde) terminal açarak veritabanını oluşturun:

```bash
dotnet ef database update --project Kutuphane.Data --startup-project KutuphaneSistemi
```

> *Not: Visual Studio kullanıyorsanız Package Manager Console üzerinden `Update-Database` komutunu çalıştırabilirsiniz.*

### Adım 4: Projeyi Başlatın

Uygulamayı derleyip çalıştırmak için:

```bash
cd KutuphaneSistemi
dotnet run
```

Ardından tarayıcınızdan `http://localhost:<port>` adresine giderek sistemi kullanmaya başlayabilirsiniz.

---

## 🗂️ PROJE MİMARİSİ

Proje dizin yapısı, katmanlı (N-Tier) mimari standartlarına sadık kalınarak oluşturulmuştur:

```text
📦 KutuphaneSistemi
 ┣ 📂 Kutuphane.Data        # Data Access katmanı (EF Core işlemleri ve DbContext)
 ┣ 📂 Kutuphane.Model       # Domain/Model katmanı (Kitap, Yazar, Kategori class'ları)
 ┣ 📂 KutuphaneSistemi      # Presentation katmanı (MVC Controllers, Views, wwwroot)
 ┗ 📜 KutuphaneSistemi.slnx # Visual Studio Solution dosyası
```

---

<p align="center">
  <i>Bu proje eğitim ve geliştirme amacıyla tasarlanmıştır.</i> 🌟
</p>

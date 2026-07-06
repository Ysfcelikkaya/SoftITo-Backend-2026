<div align="center">

# 🛒 DAPPER E-TİCARET YÖNETİM SİSTEMİ 📦

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_MVC-Core-blue?style=for-the-badge&logo=windows-terminal&logoColor=white)]()
[![Dapper](https://img.shields.io/badge/Dapper-v2.1.79-1F72B8?style=for-the-badge&logo=nuget&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()
[![QuestPDF](https://img.shields.io/badge/QuestPDF-Reporting-red?style=for-the-badge)]()

<p align="center">
  <b>Dapper mikro ORM ile geliştirilmiş, PDF/Excel raporlama destekli hızlı ve hafif e-ticaret yönetim paneli.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Detaylı Özellikler](#-detaylı-özellikler)
- [🛠 Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [💻 Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [🚀 Kurulum Adımları](#-kurulum-adımları)
- [📊 Raporlama Hakkında](#-raporlama-hakkında)
- [🗂️ Proje Mimarisi](#️-proje-mimarisi)

---

## 🎯 PROJE HAKKINDA

Bu proje, **ASP.NET Core MVC** ve hızlı, hafif bir mikro ORM aracı olan **Dapper** kullanılarak geliştirilmiş kapsamlı bir e-ticaret yönetim panelidir.

Proje; kategori, ürün, müşteri ve sipariş yönetiminin yanı sıra **PDF ve Excel** formatında dinamik raporlama yeteneklerine de sahiptir.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, e-ticaret yönetim akışını kolaylaştıran 6 temel modülden oluşur:

### 🔐 1. Kimlik Doğrulama Modülü
- 🔑 **Session Tabanlı Giriş:** Güvenli kullanıcı girişi (`AuthController`).

### 🗂️ 2. Kategori Yönetimi Modülü
- 🏷️ **Kategorilendirme:** Ürünlerin kategorize edilmesi ve yönetilmesi (`CategoryController`).

### 📦 3. Ürün Yönetimi Modülü
- 📌 **Ürün Ekleme:** Yeni ürün ekleme ve listeleme işlemleri.
- 🔄 **Güncelleme:** Ürün bilgilerinin düzenlenmesi.
- 📊 **Stok Takibi:** Ürün stok durumunun takip edilmesi (`ProductController`).

### 👥 4. Müşteri Yönetimi Modülü
- 📋 **Veritabanı Kontrolü:** Müşteri veritabanının kontrolü ve düzenlenmesi (`CustomerController`).

### 🛒 5. Sipariş Yönetimi Modülü
- 📈 **Sipariş Takibi:** Sipariş süreçlerinin işlenmesi ve takibi (`OrderController`).

### 📈 6. Dışa Aktarım ve Raporlama Modülü
- 📄 **PDF/Excel Raporlama:** Satış ve sipariş verilerinin detaylı bir şekilde Excel veya PDF olarak raporlanması (`ReportController`).

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `.NET 10.0` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **Framework** | `ASP.NET Core MVC` | Model-View-Controller mimarisi ile temiz kod yapısı. |
| ⚡ **ORM** | `Dapper (v2.1.79)` | Hızlı ve hafif mikro ORM ile veritabanı erişimi. |
| 💽 **Veritabanı** | `Microsoft SQL Server` | İlişkisel veritabanı yönetimi. |
| 📊 **Excel Raporlama** | `EPPlus (v8.6.1)` | Tablo verilerinin `.xlsx` formatında oluşturulması. |
| 📄 **PDF Raporlama** | `QuestPDF (v2026.6.0)` | Fatura ve sipariş dökümlerinin PDF formatında üretilmesi. |
| 🎨 **Frontend** | `Razor Views`, `HTML5`, `CSS3`, `Bootstrap` | Kullanıcı dostu arayüz tasarımı. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **[.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)**
- 🛢️ **Microsoft SQL Server**
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen) veya Visual Studio Code.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi İndirin

Terminal üzerinden projeyi bilgisayarınıza klonlayın (veya ZIP olarak indirin):

```bash
git clone <proje-repo-url>
cd Dapper-E-Ticaret-master/odevdpper
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

Projeyi çalıştırmadan önce `appsettings.json` dosyasını açarak SQL Server bağlantı dizenizi (Connection String) kendi veritabanı bilgilerinize göre güncelleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Adım 3: Projeyi Derleyin ve Başlatın

Terminal veya Komut İstemcisi üzerinden aşağıdaki komutları sırasıyla çalıştırın:

```bash
# Bağımlılıkları yükleyin
dotnet restore

# Projeyi derleyin ve çalıştırın
dotnet run
```

Uygulama varsayılan olarak `https://localhost:7XXX` veya `http://localhost:5XXX` adresinde çalışacaktır.

---

## 📊 RAPORLAMA HAKKINDA

Proje içerisindeki `ReportController` sayesinde yöneticiler kritik verileri dışarı aktarabilir:

- **EPPlus:** Tablo halindeki verilerin Excel formatında (`.xlsx`) oluşturulmasını sağlar.
- **QuestPDF:** Ücretsiz ve açık kaynaklı bir kütüphane olan QuestPDF ile fatura ve sipariş dökümlerinin yüksek kaliteli PDF formatında üretilmesini sağlar. *(Lisans: Community)*

---

## 🗂️ PROJE MİMARİSİ

Proje, MVC (Model-View-Controller) mimarisine uygun olarak tasarlanmıştır:

```text
📦 odevdpper
 ┣ 📂 Controllers      # HTTP isteklerini karşılayan iş mantığı (Auth, Category, Product vb.)
 ┣ 📂 Models           # Veritabanı varlıkları (Category.cs, Product.cs, Order.cs vb.)
 ┣ 📂 Data             # Dapper Context ayarları ve veritabanı bağlantısı
 ┣ 📂 Views            # Kullanıcıya sunulan Razor arayüz dosyaları
 ┣ 📂 wwwroot          # Statik web dosyaları (CSS, JavaScript, İmajlar)
 ┣ 📜 Program.cs       # Uygulamanın başlangıç ve servis konfigürasyon noktası
 ┗ 📜 appsettings.json # Veritabanı ve ortam ayarları
```


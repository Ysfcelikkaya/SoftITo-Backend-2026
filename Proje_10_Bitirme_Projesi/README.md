<div align="center">

# 🏥 HASTANE YÖNETİM SİSTEMİ 🩺

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET_Core-Web_API-blue?style=for-the-badge&logo=blazor&logoColor=white)]()
[![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()

<p align="center">
  <b>Modern, ölçeklenebilir ve güvenli hastane ve sağlık kurumu otomasyon yazılımı.</b><br>
  <i>SoftITo 2026 Backend Bitirme Projesi</i>
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

**Hastane Yönetim Sistemi**, hastane operasyonlarını (hasta kayıt, doktor atama, randevu vb.) dijitalleştirmek amacıyla geliştirilmiş uçtan uca bir yazılım çözümüdür. Arka planda yüksek performanslı bir **RESTful Web API** koşarken, ön tarafta **ASP.NET Core MVC** kullanılarak kullanıcı dostu bir arayüz tasarlanmıştır.

Bu sistem sayesinde sağlık kurumları:

- 🏥 **Hasta ve doktor bilgilerini** tek bir merkezden yönetebilir,
- 🔐 **JWT tabanlı kimlik doğrulama** ile güvenli erişim sağlayabilir,
- ⚡ **Yüksek performanslı altyapı** sayesinde işlemleri kesintisiz gerçekleştirebilir.

Proje, kurumsal mimari standartlarına ve temiz kod (Clean Code) prensiplerine uygun olarak geliştirilmiş olup, kritik sorgularda performansı artırmak için Stored Procedure ve Micro-ORM araçları içermektedir.

> **Not:** Bu proje, **SoftITo 2026 Backend Bitirme Projesi** kapsamında tasarlanmış ve geliştirilmiştir.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, sağlık kurumu işleyişini kolaylaştıran temel modüllerden oluşur:

### 👥 1. Hasta & Doktor Yönetimi
- 📝 **Hasta Kaydı:** Sisteme yeni hasta bilgilerinin eklenmesi ve düzenlenmesi.
- 👨‍⚕️ **Doktor Yönetimi:** İlgili branşlara doktor atanması ve takibi.

### 🔐 2. Güvenlik & Yetkilendirme
- 🛡️ **JWT Entegrasyonu:** Güvenli oturum yönetimi ve bulut tabanlı kimlik doğrulama.
- 🔑 **Azure SDK:** Bulut hizmetleriyle entegre güvenlik çözümleri.

### ⚡ 3. Performans Optimizasyonu
- 🚀 **Stored Procedures:** Kritik veritabanı işlemlerinde (CRUD) yanıt sürelerinin maksimize edilmesi.
- 🔄 **Micro-ORM:** İhtiyaç duyulan noktalarda Dapper kullanılarak yüksek hızlı veri çekimi.

### 🌐 4. Uçtan Uca Haberleşme
- 🔌 **API İstemcisi:** MVC arayüzünün `HttpClient` kullanarak Web API'den kesintisiz veri alıp vermesi.
- 📄 **Dökümantasyon:** Tüm servis uç noktalarının **Swagger (OpenAPI)** ile test edilebilir formata getirilmesi.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C# 12`, `.NET 8.0` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **API & Arayüz** | `ASP.NET Core Web API`, `MVC` | RESTful servisler ve kullanıcı dostu arayüz. |
| 🗄️ **Veri Yönetimi** | `MS SQL Server`, `EF Core`, `Dapper` | İlişkisel veritabanı ve ORM yaklaşımları. |
| 🔒 **Güvenlik** | `JWT (JSON Web Token)`, `Azure SDK` | Modern kimlik doğrulama standartları. |
| 🧩 **Araçlar** | `Swagger`, `HttpClient`, `Git` | API dökümantasyonu ve versiyonlama. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **.NET 8.0 SDK**
- 🗄️ **MS SQL Server** (LocalDB veya standart kurulum)
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen) veya Visual Studio Code.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi Klonlayın

```bash
git clone https://github.com/Ysfcelikkaya/Bitirme_Projesi.git
cd Bitirme_Projesi/HospitalApp
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın
`appsettings.json` dosyalarındaki `ConnectionStrings:Default` bölümünün yerel SQL Server ayarlarınıza uygun olduğundan emin olun.

### Adım 3: Bağımlılıkları Yükleyin ve Derleyin

Projeyi derlemek için terminalde aşağıdaki komutu çalıştırın:

```bash
dotnet build
```

### Adım 4: Projeyi Çalıştırın

Önce API projesini, ardından MVC projesini çalıştırın:

```bash
# API projesi için
cd HospitalAppApi/HospitalAppApi
dotnet run

# Yeni bir terminalde MVC projesi için
cd ../../HospitalAppMvc/HospitalAppMvc
dotnet run
```

Tarayıcınız üzerinden MVC uygulamasına veya Swagger dökümantasyon sayfasına (API portu üzerinden) ulaşabilirsiniz.

---

## 🗂️ PROJE MİMARİSİ (Çok Katmanlı Yapı)

Proje dizin yapısı, anlaşılabilirlik ve sürdürülebilirlik açısından Çok Katmanlı (N-Tier) standartlarına uygun olarak tasarlanmıştır:

```text
📂 HospitalApp
├── 📁 HospitalAppApi/    # RESTful servislerin barındırıldığı backend katmanı
├── 📁 HospitalAppMvc/    # Web API ile haberleşen son kullanıcı arayüz katmanı
└── 📁 HospitalAppDppr/   # Dapper (Micro-ORM) ile veri erişimi yapılan katman
```

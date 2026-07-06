<div align="center">

# 🏥 HASTANE BİLGİ YÖNETİM SİSTEMİ 🩺

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_MVC-Core-blue?style=for-the-badge&logo=windows-terminal&logoColor=white)]()
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-DbFirst-34A853?style=for-the-badge&logo=nuget&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.x-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)]()

<p align="center">
  <b>Sağlık kuruluşları için geliştirilmiş modern, hızlı ve yönetilebilir otomasyon yazılımı.</b>
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

**Hastane Sistemi**, hastane içerisindeki karmaşık veri yönetimini basitleştirmek ve dijitalleştirmek için tasarlanmış bir **ASP.NET Core MVC** web uygulamasıdır.

Proje, veritabanı öncelikli **(Database First)** yaklaşımı kullanılarak **Entity Framework Core** ile geliştirilmiştir. Gelişmiş arama ve filtreleme özellikleri sayesinde doktorlar, hastalar ve randevular arasındaki ilişkiyi en yüksek verimlilikle yönetmenizi sağlar.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, iş akışını kolaylaştıran 4 temel yapıtaşından oluşur:

### 🤒 1. Hasta Yönetimi Modülü
- 📌 **Yeni Hasta Kaydı:** Hastaların T.C. Kimlik, Ad, Soyad ve iletişim bilgilerinin sisteme eklenmesi.
- 🔄 **Bilgi Güncelleme:** Mevcut hastaların adres ve iletişim bilgilerinin düzenlenmesi.
- 🗑️ **Hasta Çıkışı:** Sistemden hasta kaydı silme işlemleri.
- 📋 **Hasta Listeleme:** Tüm hastaların dinamik tablolar üzerinde listelenmesi.

### 👨‍⚕️ 2. Doktor Yönetimi Modülü
- 🩺 **Doktor Ekleme:** Uzmanlık alanlarıyla birlikte yeni doktorların sisteme tanımlanması.
- 📊 **Doktor Takibi:** Hastanede görev alan tüm doktorların departman/uzmanlık bazında görüntülenmesi.
- ✏️ **Düzenleme İşlemleri:** Doktor bilgilerinde (unvan, iletişim vs.) güncelleme yapılması.

### 📅 3. Randevu Yönetimi Modülü
- 🤝 **Randevu Eşleştirme:** İlgili hasta ile uzman doktor arasında tarih ve saat bazlı randevu oluşturulması.
- 🗓️ **Takvim Yönetimi:** Geçmiş ve gelecek randevuların listelenerek takibi.
- ❌ **Randevu İptali:** Gerektiğinde oluşturulan randevuların iptal edilmesi (silinmesi).

### 🔍 4. Gelişmiş Arama Modülü
- 🕵️‍♂️ **Hızlı Arama:** Binlerce kayıt arasından spesifik hasta veya doktorlara anında ulaşım.
- ⚡ **Filtreleme:** İsim veya branşa göre detaylı arama sonuçları getirme.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `.NET 10.0` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **Framework** | `ASP.NET Core MVC` | Model-View-Controller mimarisi ile temiz kod yapısı. |
| 🗄️ **ORM** | `Entity Framework Core 10` | Database-First yaklaşımı ile SQL-Nesne bağdaştırması. |
| 💽 **Veritabanı** | `MS SQL Server` | İlişkisel veritabanı yönetimi (Hasta, Doktor, Randevu tabloları). |
| 🎨 **Frontend** | `HTML5`, `CSS3`, `Bootstrap` | Mobil uyumlu (Responsive) ve kullanıcı dostu arayüz tasarımı. |
| 🧩 **Scripting** | `jQuery` & `Vanilla JS` | Dinamik sayfa içi etkileşimler. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **.NET 10.0 SDK**
- 🛢️ **SQL Server** (Express, Developer veya LocalDB sürümü)
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen), Visual Studio Code veya JetBrains Rider.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi Klonlayın

```bash
git clone https://github.com/Ysfcelikkaya/HastaneSistemi.git
cd HastaneSistemi/DbFirstProject
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

Proje, Database First yaklaşımıyla yapıldığı için hazır bir SQL Server veritabanınız bulunmalıdır. `appsettings.json` dosyasını açın ve `ConnectionStrings` bloğundaki değerleri kendi SQL Server'ınıza göre güncelleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SİZİN_SUNUCUNUZ;Database=HastaneDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

### Adım 3: Bağımlılıkları Yükleyin

NuGet paketlerini yüklemek için terminalde aşağıdaki komutu çalıştırın:

```bash
dotnet restore
```

### Adım 4: Projeyi Çalıştırın

Tüm ayarlar tamam! Projeyi başlatmak için:

```bash
dotnet run
```

Tarayıcınızdan konsolda belirtilen `http://localhost:5000` veya `https://localhost:5001` adresine giderek uygulamaya erişebilirsiniz.

---

## 🗂️ PROJE MİMARİSİ (MVC Yapısı)

Proje dizin yapısı, anlaşılabilirlik ve sürdürülebilirlik açısından standart MVC yapısına sadık kalınarak oluşturulmuştur:

```text
📂 HastaneSistemi
└── 📂 DbFirstProject
    ├── 📁 Controllers/       # (C) Kullanıcı isteklerini yöneten sınıflar
    │   ├── DoktorController.cs
    │   ├── HastaController.cs
    │   └── RandevuController.cs
    ├── 📁 Models/            # (M) Veritabanı tabloları ve EF Core DbContext nesnesi
    ├── 📁 Views/             # (V) Bootstrap ile tasarlanmış kullanıcı arayüzleri (.cshtml)
    ├── 📁 wwwroot/           # Stil (CSS), Script (JS) ve dış kütüphaneler (Bootstrap, jQuery)
    ├── 📄 appsettings.json   # Veritabanı bağlantı metni ve global ayarlar
    └── 📄 Program.cs         # Dependency Injection (Bağımlılık Enjeksiyonu) ve Middleware ayarları
```

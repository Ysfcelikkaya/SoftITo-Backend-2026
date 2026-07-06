<div align="center">

# 🏨 OTEL YÖNETİM SİSTEMİ 🛎️
### Hotel Management System

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_MVC-Core-blue?style=for-the-badge&logo=windows-terminal&logoColor=white)]()
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-10.0-34A853?style=for-the-badge&logo=nuget&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.x-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)]()

<p align="center">
  <b>Modern, hızlı ve kullanışlı bir ASP.NET Core MVC otel otomasyonu.</b>
</p>

</div>

---

## 📋 İÇİNDEKİLER

- [🎯 Proje Hakkında](#-proje-hakkında)
- [✨ Detaylı Özellikler](#-detaylı-özellikler)
- [🛠 Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [💻 Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [🚀 Kurulum Adımları](#-kurulum-adımları)
- [📸 Ekran Görüntüleri](#-ekran-görüntüleri-ve-kullanım)

---

## 🎯 PROJE HAKKINDA

**Otel Yönetim Sistemi**, otellerin oda, müşteri ve rezervasyon süreçlerini dijital ortamda yönetebilmesi için geliştirilmiş kapsamlı bir web uygulamasıdır. **ASP.NET Core MVC** (.NET 10) ve **Entity Framework Core** teknolojileri kullanılarak modern web standartlarına uygun, hızlı ve ölçeklenebilir bir yapıda tasarlanmıştır.

Kullanıcı dostu arayüzü sayesinde otel personelleri kolaylıkla odaların durumunu takip edebilir, yeni rezervasyonlar oluşturabilir ve müşteri kayıtlarını yönetebilir.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, otel yönetim akışını kolaylaştıran 4 temel modülden oluşur:

### 🔑 1. Kullanıcı Doğrulama Modülü
- 🖥️ **Giriş / Kayıt Ol:** Personele özel giriş ve kayıt ekranları.
- 🔐 **Oturum Yönetimi:** Kolay ve güvenli oturum yönetimi.

### 🛏️ 2. Oda Yönetimi Modülü
- 📌 **Oda Ekleme:** Yeni oda ekleme, güncelleme ve silme işlemleri.
- 🏷️ **Oda Tipi Belirleme:** Suit, Tek Kişilik vb. oda tiplerinin tanımlanması.
- 💰 **Fiyatlandırma:** Günlük oda ücretinin (fiyat) belirlenmesi.
- 🟢 **Müsaitlik Takibi:** Odaların Dolu/Boş durumunun anlık olarak takip edilmesi.

### 📅 3. Rezervasyon Yönetimi Modülü
- 🗓️ **Rezervasyon Oluşturma:** Belirli tarihler (Giriş-Çıkış) arasında müşteri için oda rezerve etme.
- 🧮 **Ücret Hesaplama:** Rezervasyon süresine ve oda fiyatına göre toplam ücretin hesaplanması.
- ⚠️ **Çakışma Kontrolü:** Çakışan rezervasyonların kontrol edilebilmesi.

### 👥 4. Müşteri / Kullanıcı Yönetimi Modülü
- 📝 **Müşteri Kaydı:** Ad Soyad, e-posta ve telefon numarası bilgileriyle müşteri kaydı oluşturma.
- 📋 **Listeleme:** Müşterilerin listelenmesi, güncellenmesi ve sistemden silinmesi.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `.NET 10.0` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **Framework** | `ASP.NET Core MVC` | Model-View-Controller mimarisi ile temiz kod yapısı. |
| 🗄️ **ORM** | `Entity Framework Core 10` | Veritabanı işlemlerinin yönetimi. |
| 💽 **Veritabanı** | `Microsoft SQL Server` | İlişkisel veritabanı yönetimi. |
| 🎨 **Frontend** | `HTML5`, `CSS3`, `Bootstrap 5` | Mobil uyumlu (Responsive) ve kullanıcı dostu arayüz tasarımı. |
| 🧩 **Scripting** | `jQuery` | Dinamik sayfa içi etkileşimler. |
| 💻 **Geliştirme Ortamı** | `Visual Studio` / `Visual Studio Code` | Proje geliştirme ve hata ayıklama. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **.NET 10 SDK**
- 🛢️ **SQL Server** (LocalDB veya tam sürüm)
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen) veya güncel bir IDE.

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Veritabanı Ayarlarını Yapılandırın

`OtelProjesi` klasörü altındaki `appsettings.json` dosyasını açarak SQL Server bağlantı dizenizi (Connection String) kendi bilgisayarınıza göre düzenleyin:

```json
"ConnectionStrings": {
  "Default": "Server=YOUR_SERVER_NAME;Database=OtelSistemiDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```

### Adım 2: Veritabanını Oluşturun (Migrations)

Proje dizininde (Terminal / Package Manager Console üzerinden) aşağıdaki komutu çalıştırarak veritabanı tablolarını oluşturun:

```bash
dotnet ef database update
```

> *Not: Visual Studio kullanıyorsanız Package Manager Console üzerinden `Update-Database` komutunu çalıştırabilirsiniz.*

### Adım 3: Projeyi Başlatın

Terminal ekranında aşağıdaki komutu yazarak projeyi ayağa kaldırabilirsiniz:

```bash
dotnet run
```

Proje genellikle `https://localhost:5001` veya benzer bir adreste çalışmaya başlayacaktır. Tarayıcınızdan bu adrese giderek sistemi kullanmaya başlayabilirsiniz!


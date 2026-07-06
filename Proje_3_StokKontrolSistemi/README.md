<div align="center">

# 📦 STOK KONTROL SİSTEMİ 📊

[![.NET](https://img.shields.io/badge/.NET-8.0/9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core Razor Pages](https://img.shields.io/badge/ASP.NET_Core-Razor_Pages-blue?style=for-the-badge&logo=blazor&logoColor=white)]()
[![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.x-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)]()

<p align="center">
  <b>İşletmeler için geliştirilmiş modern, hızlı ve yönetilebilir stok ve satış otomasyon yazılımı.</b>
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
- [💡 Gelecek Geliştirmeler](#-gelecek-geliştirmeler-roadmap)
- [🤝 Katkıda Bulunma](#-katkıda-bulunma)

---

## 🎯 PROJE HAKKINDA

**Stok Kontrol Sistemi**, küçük ve orta ölçekli işletmelerin (KOBİ) ürün stoklarını, satışlarını, müşterilerini ve kullanıcılarını tek bir noktadan yönetebilmeleri amacıyla geliştirilmiş kapsamlı bir web uygulamasıdır. Proje **ASP.NET Core Razor Pages** kullanılarak geliştirilmiştir.

Bu sistem sayesinde işletmeler:

- 📊 **Anlık stok takibi** yapabilir,
- ⚠️ **Kritik stok uyarısı** alabilir,
- 👥 **Müşteri ve personel yönetimi** gerçekleştirebilir.

Proje şu anda hızlı test edilebilmesi amacıyla **In-Memory (Bellek İçi Statik Listeler)** yaklaşımı ile geliştirilmiştir. Dinamik Dashboard'u sayesinde kritik stok uyarılarını, toplam ürün ve kullanıcı istatistiklerini en yüksek verimlilikle takip etmenizi sağlar.

> **Not:** Uygulama şu anda geçici olarak bellek içi (In-Memory / Static Lists) veritabanı ile çalışmaktadır. Kurulum sonrasında herhangi bir SQL/Veritabanı konfigürasyonu yapmanıza gerek kalmadan doğrudan test edebilirsiniz.

---

## ✨ DETAYLI ÖZELLİKLER

Sistem, işletme akışını kolaylaştıran 5 temel modülden oluşur:

### 🛒 1. Ürün Yönetimi Modülü
- 📌 **Yeni Ürün Kaydı:** Ürün kodu, adı, kategori ve miktar bilgilerinin sisteme eklenmesi.
- 🗑️ **Ürün Çıkışı:** Sistemden ürün kaydı silme işlemleri.
- 📋 **Ürün Listeleme:** Tüm ürünlerin dinamik tablolar üzerinde listelenmesi.
- ⚠️ **Kritik Stok Uyarısı:** Stok adedi 10 ve altında olan ürünler için otomatik uyarı sistemi.

### 👥 2. Kullanıcı & Personel Yönetimi Modülü
- 👨‍💻 **Personel Ekleme:** Sistemi kullanacak personellerin sisteme tanımlanması.
- 📊 **Personel Takibi:** İşletmede görev alan tüm kullanıcıların görüntülenmesi.

### 🤝 3. Müşteri Yönetimi Modülü
- 📝 **Müşteri Kaydı:** İşletmenin hizmet verdiği müşteri bilgilerinin (Ad, Soyad vb.) tutulması.
- 📞 **Müşteri Listesi:** Kayıtlı müşterilerin hızlıca filtrelenmesi ve görüntülenmesi.

### 💰 4. Satış İşlemleri Modülü
- 📈 **Satış Gerçekleştirme:** Müşterilere yapılan satışların kaydı ve takibi.
- 📉 **Stok Düşümü:** Satış işlemi yapıldığında ilgili ürünün stoğunun dinamik olarak güncellenmesi.

### 📊 5. Dinamik Kontrol Paneli (Dashboard)
- 👁️ **Anlık İstatistikler:** Toplam ürün adedi, kritik stok sayısı ve sistemdeki kullanıcıların anlık takibi.

---

## 🛠 KULLANILAN TEKNOLOJİLER

Projenin altyapısında sektör standartlarına uygun, modern teknolojiler kullanılmıştır:

| Kategori | Teknoloji / Araç | Detay |
|---|---|---|
| ⚙️ **Backend** | `C#` & `.NET SDK` | Güçlü, güvenli ve performanslı sunucu tarafı. |
| 🌐 **Framework** | `ASP.NET Core Razor Pages` | Sayfa tabanlı mimari ile temiz kod yapısı. |
| 🗄️ **Veri Yönetimi** | `In-Memory Static Lists` | Kurulum gerektirmeyen, bellek içi geçici veritabanı. |
| 🎨 **Frontend** | `HTML5`, `CSS3`, `Bootstrap` | Mobil uyumlu (Responsive) ve kullanıcı dostu arayüz tasarımı. |
| 🧩 **Scripting** | `C# (Code-Behind)` | Sunucu taraflı dinamik sayfa içi etkileşimler. |

---

## 💻 SİSTEM GEREKSİNİMLERİ

Projeyi sorunsuz çalıştırabilmeniz için geliştirme ortamınızda bulunması gerekenler:

- 🟩 **.NET 7.0 / 8.0 veya 9.0 SDK**
- 💻 **IDE:** Visual Studio 2022 (Tavsiye edilen) veya Visual Studio Code.

> *Not: Veritabanı kurulumuna gerek yoktur.*

---

## 🚀 KURULUM ADIMLARI

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla takip ediniz:

### Adım 1: Projeyi Klonlayın

```bash
git clone https://github.com/KullaniciAdi/StokKontrolSistemi.git
cd StokKontrolSistemi-master/odevrzrpg
```

### Adım 2: Bağımlılıkları Yükleyin

Projeyi derlemek için terminalde aşağıdaki komutu çalıştırın:

```bash
dotnet build
```

### Adım 3: Projeyi Çalıştırın

Tüm ayarlar tamam! Projeyi başlatmak için:

```bash
dotnet run
```

Tarayıcınızdan konsolda belirtilen `http://localhost:5000` veya `https://localhost:5001` (ya da uygulamanın yönlendirdiği port) adresine giderek uygulamaya erişebilirsiniz.

---

## 🗂️ PROJE MİMARİSİ (Razor Pages Yapısı)

Proje dizin yapısı, anlaşılabilirlik ve sürdürülebilirlik açısından Razor Pages standartlarına sadık kalınarak oluşturulmuştur:

```text
📂 StokKontrolSistemi-master
└── 📂 odevrzrpg
    ├── 📁 Pages/             # Uygulama Sayfaları ve Code-Behind (.cshtml & .cshtml.cs)
    │   ├── 📁 Account/       # (Hesap işlemleri)
    │   ├── 📁 Kullanici/     # (Kullanıcı liste/ekleme sayfaları)
    │   ├── 📁 Musteriler/    # (Müşteri ekranları)
    │   ├── 📁 Satislar/      # (Satış yönetim ekranları)
    │   ├── 📁 UrunYonetimi/  # (Ürün bazlı ekranlar)
    │   └── 📄 Index.cshtml   # Ana Dashboard (İstatistikler)
    ├── 📁 wwwroot/           # Stil (CSS), Script (JS) ve dış kütüphaneler (Bootstrap vb.)
    ├── 📄 appsettings.json   # Global uygulama ayarları
    └── 📄 Program.cs         # Servis kayıtları, Middleware ve uygulama başlatıcısı
```

---

## 💡 Gelecek Geliştirmeler (Roadmap)

- [ ] 🗄️ **Gerçek Veritabanı Entegrasyonu:** Entity Framework Core ile SQL Server / PostgreSQL bağlantısının sağlanması.
- [ ] 🔐 **Yetkilendirme:** Kimlik doğrulama (Identity) ve Role-Based Access Control (Admin/Personel) sisteminin eklenmesi.
- [ ] 📊 **Gelişmiş Raporlama:** Excel ve PDF formatında aylık satış/stok raporu dışa aktarımı.


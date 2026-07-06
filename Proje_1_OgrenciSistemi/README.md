# 🎓 Öğrenci Sistemi

**ASP.NET Core MVC Tabanlı Okul ve Öğrenci Yönetim Sistemi**

Modern, hızlı ve yönetilebilir bir eğitim kurumu otomasyonu.

---

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Temel Özellikler](#-temel-özellikler)
- [Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [Gereksinimler](#-gereksinimler)
- [Kurulum Adımları](#-kurulum-adımları)
- [Proje Yapısı](#-proje-yapısı)

---

## 📖 Proje Hakkında

**Öğrenci Sistemi**, bir eğitim kurumundaki temel süreçleri dijital ortama taşıyan, eğitim yöneticilerinin ve personelin işlerini kolaylaştırmak amacıyla tasarlanmış bir web uygulamasıdır. ASP.NET Core MVC mimarisiyle geliştirilen bu proje, veritabanı işlemleri için Entity Framework Core'un gücünden yararlanır.

Basit ve anlaşılır arayüzü sayesinde okul, öğrenci, öğretmen ve ders ilişkilerini kolayca yönetebilirsiniz.

---

## ✨ Temel Özellikler

Sistem, eğitim kurumunun temel yapıtaşlarını yönetmek için 4 ana modülden oluşmaktadır:

| İkon | Modül | Açıklama |
|:---:|---|---|
| 📚 | **Öğrenci Yönetimi** | Öğrencilerin sisteme kaydı, kişisel bilgilerinin güncellenmesi ve takibi. |
| 💼 | **Öğretmen Yönetimi** | Öğretim kadrosunun sisteme eklenmesi, branş ve iletişim bilgilerinin yönetimi. |
| 🏢 | **Bölüm Yönetimi** | Okul bünyesindeki farklı bölümlerin (Sayısal, Sözel, Bilişim vb.) oluşturulması. |
| 📝 | **Ders Yönetimi** | Dönemlik olarak açılan derslerin tanımlanması ve ilgili bölümlere atanması. |

> Tüm modüller veri ekleme (**Create**), okuma (**Read**), güncelleme (**Update**) ve silme (**Delete**) — CRUD işlemlerini tam olarak destekler.

---

## 🛠 Kullanılan Teknolojiler

Projenin geliştirilmesinde güncel yazılım standartları ve teknolojiler tercih edilmiştir:

- **Backend & Çerçeve:** ASP.NET Core MVC (C#)
- **Veritabanı Erişimi (ORM):** Entity Framework Core (Code-First Yaklaşımı)
- **Veritabanı:** SQL Server (Geliştirme ortamı için LocalDB varsayılan olarak ayarlıdır)
- **Arayüz (Frontend):** HTML5, CSS3, Bootstrap (Varsayılan MVC şablonu)

---

## ⚙️ Gereksinimler

Projeyi yerel ortamınızda çalıştırabilmek için bilgisayarınızda aşağıdaki araçların kurulu olması gerekmektedir:

- .NET SDK (Sürümünüze uygun)
- SQL Server Express / LocalDB
- Kod Editörü (Örn: Visual Studio 2022, Visual Studio Code veya Rider)

---

## 🚀 Kurulum Adımları

Projeyi saniyeler içinde ayağa kaldırmak için aşağıdaki adımları sırasıyla uygulayın:

### 1. Projeyi Klonlayın

Projeyi bilgisayarınıza indirin ve komut satırını kullanarak proje dizinine (`OgrenciSistemi.slnx` veya `.csproj` dosyasının bulunduğu klasöre) gidin.

### 2. Veritabanını Hazırlayın

Proje, veritabanını oluşturmak için Entity Framework Core'un Migration (Göç) özelliğini kullanır. Bağlantı dizesi `appsettings.json` dosyasında ayarlanmıştır (Varsayılan veritabanı adı: `okul`).

**Terminal (CLI) Üzerinden:**

```bash
# Proje dizininde (OgrenciSistemi klasörü) aşağıdaki komutu çalıştırın:
dotnet ef database update
```

**Visual Studio (Package Manager Console) Üzerinden:**

```powershell
Update-Database
```

> Bu işlem `(localdb)\MSSQLLocalDB` üzerinde veritabanını otomatik olarak oluşturacak ve tabloları ekleyecektir.

### 3. Projeyi Başlatın

Tüm hazırlıklar tamamlandı! Artık projeyi çalıştırabilirsiniz:

```bash
dotnet run
```

Konsolda beliren URL'ye (genellikle `http://localhost:5000` veya `https://localhost:5001`) tıklayarak tarayıcınızda sistemi görüntüleyebilirsiniz.

---

## 📂 Proje Yapısı

```text
OgrenciSistemi/
├── Controllers/       # Gelen istekleri (request) karşılayan ve yönlendiren denetleyiciler.
├── Models/            # Veritabanı tablolarına karşılık gelen C# sınıfları (Ogrenci, Ders vb.)
├── Views/             # Kullanıcıya sunulan arayüz sayfaları (.cshtml)
├── wwwroot/           # Statik dosyalar (CSS, JS, Resimler)
├── appsettings.json   # Veritabanı bağlantı cümlesi ve proje ayarları
└── Program.cs         # Uygulamanın başlangıç noktası ve servis yapılandırmaları
```

---

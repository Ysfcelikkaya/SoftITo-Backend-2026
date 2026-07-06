# 📚 Kütüphane Sistemi (Library Management System)

📖 **Kütüphane Sistemi**, ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilmiş, kitap, yazar, kategori ve kullanıcı yönetimini sağlayan modern ve katmanlı mimariye sahip bir otomasyon projesidir.

---

## ✨ Özellikler

- 📚 **Kitap Yönetimi**: Sisteme yeni kitap ekleme, güncelleme, silme ve listeleme.
- ✍️ **Yazar ve Kategori Yönetimi**: Kitaplara ait yazar ve kategori bilgilerinin detaylı takibi ve CRUD (Ekle/Oku/Güncelle/Sil) işlemleri.
- 👥 **Kullanıcı İşlemleri**: Kullanıcı (Account) kayıt, giriş ve oturum yönetimi.
- 📊 **Detaylı Raporlama**:
  - 📄 **PDF Çıktısı**: *QuestPDF* entegrasyonu ile veritabanındaki verilerin PDF formatında detaylı raporlanması.
  - 📈 **Excel Çıktısı**: *EPPlus* kullanılarak kitap ve istatistik verilerinin Excel formatında dışa aktarımı.
- 🏗️ **N-Tier (Katmanlı) Mimari**:
  - `Kutuphane.Data`: Veritabanı bağlamı (Context) ve migration işlemleri.
  - `Kutuphane.Model`: Veritabanı tablolarına karşılık gelen nesne modelleri (Entity).
  - `KutuphaneSistemi`: Web arayüzü (UI), Controller katmanı ve iş mantığı.

---

## 🛠️ Kullanılan Teknolojiler

- **Backend**: C#, ASP.NET Core MVC (.NET 10.0)
- **Veritabanı**: Microsoft SQL Server
- **ORM**: Entity Framework Core 10.0.9 (Code-First Yaklaşımı)
- **Raporlama Kütüphaneleri**:
  - `QuestPDF` (PDF oluşturma)
  - `EPPlus` (Excel tabloları oluşturma)
- **Frontend/Arayüz**: HTML5, CSS3, (Görünüm motoru olarak Razor Views)

---

## 🚀 Kurulum ve Çalıştırma

Projeyi bilgisayarınızda yerel ortamda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

### 1. Gereksinimler
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- SQL Server (LocalDB veya tam sürüm)
- Visual Studio 2022 veya Visual Studio Code

### 2. Projeyi Klonlayın
```bash
git clone <repo-url>
```

### 3. Veritabanı Bağlantısını Ayarlayın
`KutuphaneSistemi/appsettings.json` dosyası içerisindeki `ConnectionStrings` bölümünü, kendi yerel SQL Server instance'ınıza göre güncelleyin.

### 4. Migration'ları Uygulayın (Veritabanını Oluşturun)
Proje dizininde (Solution düzeyinde) terminal açarak veritabanını oluşturun:
```bash
dotnet ef database update --project Kutuphane.Data --startup-project KutuphaneSistemi
```
*(Not: Visual Studio kullanıyorsanız Package Manager Console üzerinden `Update-Database` komutunu çalıştırabilirsiniz.)*

### 5. Projeyi Başlatın
Uygulamayı derleyip çalıştırmak için:
```bash
cd KutuphaneSistemi
dotnet run
```
Ardından tarayıcınızdan `http://localhost:<port>` adresine giderek sistemi kullanmaya başlayabilirsiniz.

---

## 📂 Proje Yapısı

```text
📦 KutuphaneSistemi
 ┣ 📂 Kutuphane.Data       # Data Access katmanı (EF Core işlemleri ve DbContext)
 ┣ 📂 Kutuphane.Model      # Domain/Model katmanı (Kitap, Yazar, Kategori class'ları)
 ┣ 📂 KutuphaneSistemi     # Presentation katmanı (MVC Controllers, Views, wwwroot)
 ┗ 📜 KutuphaneSistemi.slnx# Visual Studio Solution dosyası
```

---

## 🤝 Katkıda Bulunma

Projeye katkı sağlamak isterseniz:
1. Bu projeyi **Fork**'layın.
2. Yeni bir dal (branch) oluşturun: `git checkout -b feature/YeniOzellik`
3. Yaptığınız değişiklikleri commit'leyin: `git commit -m 'Yeni özellik: Raporlama ekranı eklendi'`
4. Dalınızı gönderin: `git push origin feature/YeniOzellik`
5. Bir **Pull Request (PR)** açarak inceleme talebinde bulunun.

---

💡 *Bu proje, modern web geliştirme pratiklerini ve ASP.NET Core MVC mimarisini örneklemek amacıyla geliştirilmiştir.*

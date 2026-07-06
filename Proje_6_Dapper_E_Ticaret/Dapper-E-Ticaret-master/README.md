# 🛒 Dapper E-Ticaret Yönetim Sistemi

Bu proje, **ASP.NET Core MVC** ve hızlı, hafif bir mikro ORM aracı olan **Dapper** kullanılarak geliştirilmiş kapsamlı bir e-ticaret yönetim panelidir. Proje; kategori, ürün, müşteri ve sipariş yönetiminin yanı sıra **PDF ve Excel** formatında dinamik raporlama yeteneklerine sahiptir.

---

## 🚀 Teknolojiler ve Araçlar

Projenin geliştirilmesinde aşağıdaki modern teknolojiler kullanılmıştır:

*   🌐 **Framework:** .NET 10.0 / ASP.NET Core MVC
*   ⚡ **ORM:** Dapper (v2.1.79)
*   💾 **Veritabanı:** Microsoft SQL Server
*   📊 **Excel Raporlama:** EPPlus (v8.6.1)
*   📄 **PDF Raporlama:** QuestPDF (v2026.6.0)
*   🎨 **Önyüz (Frontend):** Razor Views, HTML5, CSS3, Bootstrap

---

## ⚙️ Temel Özellikler

*   🔐 **Kimlik Doğrulama:** Session (oturum) tabanlı güvenli kullanıcı girişi (`AuthController`).
*   🗂️ **Kategori Yönetimi:** Ürünlerin kategorize edilmesi ve yönetilmesi (`CategoryController`).
*   📦 **Ürün Yönetimi:** Yeni ürün ekleme, listeleme, güncelleme ve stok takibi (`ProductController`).
*   👥 **Müşteri Yönetimi:** Müşteri veritabanının kontrolü ve düzenlenmesi (`CustomerController`).
*   🛒 **Sipariş Yönetimi:** Sipariş süreçlerinin işlenmesi ve takibi (`OrderController`).
*   📈 **Dışa Aktarım ve Raporlama:** Satış ve sipariş verilerinin detaylı bir şekilde **Excel** veya **PDF** olarak raporlanması (`ReportController`).

---

## 📂 Proje Yapısı

Proje, MVC (Model-View-Controller) mimarisine uygun olarak tasarlanmıştır:

```text
📦 odevdpper
 ┣ 📂 Controllers   # HTTP isteklerini karşılayan iş mantığı (Auth, Category, Product vb.)
 ┣ 📂 Models        # Veritabanı varlıkları (Category.cs, Product.cs, Order.cs vb.)
 ┣ 📂 Data          # Dapper Context ayarları ve veritabanı bağlantısı
 ┣ 📂 Views         # Kullanıcıya sunulan Razor arayüz dosyaları
 ┣ 📂 wwwroot       # Statik web dosyaları (CSS, JavaScript, İmajlar)
 ┣ 📜 Program.cs    # Uygulamanın başlangıç ve servis konfigürasyon noktası
 ┗ 📜 appsettings.json # Veritabanı ve ortam ayarları
```

---

## 🛠️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

### 1. Gereksinimler
*   [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
*   Microsoft SQL Server
*   Visual Studio 2022 veya Visual Studio Code

### 2. Projeyi İndirme
Terminal üzerinden projeyi bilgisayarınıza klonlayın (veya ZIP olarak indirin):
```bash
git clone <proje-repo-url>
cd Dapper-E-Ticaret-master/odevdpper
```

### 3. Veritabanı Bağlantısı
Projeyi çalıştırmadan önce `appsettings.json` dosyasını açarak SQL Server bağlantı dizenizi (Connection String) kendi veritabanı bilgilerinize göre güncelleyin.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 4. Projeyi Derleme ve Başlatma
Terminal veya Komut İstemcisi üzerinden aşağıdaki komutları sırasıyla çalıştırın:

```bash
# Bağımlılıkları yükleyin
dotnet restore

# Projeyi derleyin ve çalıştırın
dotnet run
```
*Uygulama varsayılan olarak `https://localhost:7XXX` veya `http://localhost:5XXX` adresinde çalışacaktır.*

---

## 📊 Raporlama Hakkında

Proje içerisindeki `ReportController` sayesinde yöneticiler kritik verileri dışarı aktarabilir:
*   **EPPlus:** Tablo halindeki verilerin Excel formatında (`.xlsx`) oluşturulmasını sağlar.
*   **QuestPDF:** Ücretsiz ve açık kaynaklı bir kütüphane olan QuestPDF ile fatura ve sipariş dökümlerinin yüksek kaliteli PDF formatında üretilmesini sağlar. (Lisans: *Community*)

---

## 🤝 Katkıda Bulunma

1. Bu depoyu çatallayın (Fork).
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/YeniOzellik`).
3. Değişikliklerinizi kaydedin (`git commit -m 'Harika bir özellik eklendi'`).
4. Dalınızı gönderin (`git push origin feature/YeniOzellik`).
5. Bir Çekme İsteği (Pull Request) oluşturun.

---
⭐ *Projeyi faydalı bulduysanız yıldız vermeyi unutmayın!*

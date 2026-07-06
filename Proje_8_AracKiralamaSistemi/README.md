# 🚗 Araç Kiralama Sistemi (Car Rental System)

![.NET Core](https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

## 📖 Proje Hakkında
Bu proje, kullanıcıların araç kiralama işlemlerini kolayca ve hızlı bir şekilde gerçekleştirebileceği, yenilikçi ve modern bir web uygulamasıdır. Sistem, birbirinden bağımsız iki temel yapı taşı olan **Web API** ve **MVC (Model-View-Controller)** projeleri şeklinde .NET 8 kullanılarak geliştirilmiştir. 

## ✨ Öne Çıkan Özellikler
* 🔍 **Detaylı Araç Listeleme**: Sistemdeki tüm araçları, özellikleri ve güncel durumlarıyla görüntüleyebilme.
* 📅 **Kiralama ve Rezervasyon**: Belirli tarih aralıkları için kolayca araç kiralayabilme altyapısı.
* ⚡ **Yüksek Performans**: Backend tarafında **Dapper (Mikro ORM)** kullanılarak veritabanı işlemlerinde maksimum hız ve verimlilik.
* 💻 **Kullanıcı Dostu Arayüz**: .NET MVC kullanılarak geliştirilmiş, akıcı bir kullanıcı deneyimi.
* 📚 **Canlı API Dokümantasyonu**: Swagger arayüzü ile API servislerinin anlık testi ve dokümantasyonu.

## 🛠️ Kullanılan Teknolojiler ve Stack

### ⚙️ Backend (AracKiralamaApi)
* **Framework:** .NET 8.0 Web API
* **Veritabanı:** Microsoft SQL Server (LocalDB)
* **Veritabanı Erişimi (ORM):** Dapper
* **Dokümantasyon:** Swashbuckle (Swagger UI)

### 🖥️ Frontend (AracKiralamaMvc)
* **Framework:** .NET 8.0 MVC (Model-View-Controller)
* **İstemci İşlemleri:** Newtonsoft.Json (API'den gelen JSON verilerinin işlenmesi)
* **ORM (Opsiyonel/İleri Dönük):** Entity Framework Core (Altyapıda hazır bulundurulmaktadır)

## 📂 Proje Klasör Yapısı

```text
📁 AracKiralama-main/
│
├── 📁 AracKiralamaApi/      # Backend API Projesi
│   ├── 📁 Controllers/      # API Endpoint'leri
│   ├── 📁 Models/           # Veri Modelleri
│   ├── 📁 Data/             # Dapper Veritabanı Bağlantı ve İşlemleri
│   └── 📄 appsettings.json  # Veritabanı Connection String Ayarları
│
└── 📁 AracKiralamaMvc/      # Frontend Web Projesi
    ├── 📁 Controllers/      # MVC Kontrolcüleri (API Tüketimi vb.)
    ├── 📁 Views/            # Kullanıcı Arayüzü (HTML/CSS/Razor)
    └── 📁 Models/           # View Modelleri
```

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler
* [**.NET 8.0 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0)
* **SQL Server** (veya Visual Studio ile gelen LocalDB)
* **Visual Studio 2022** (Önerilen) veya **Visual Studio Code**

### Adım Adım Kurulum

1. **Projeyi Bilgisayarınıza İndirin:**
   Projeyi Git üzerinden klonlayın veya ZIP olarak indirip klasöre çıkartın.

2. **Veritabanı Bağlantısını Ayarlayın:**
   `AracKiralamaApi/AracKiralamaApi/appsettings.json` dosyasını açın ve `ConnectionStrings` altındaki `Default` bağlantı ayarının sisteminize (SQL Server) uygun olduğundan emin olun.
   *(Varsayılan olarak LocalDB ayarlıdır: `Server=(localdb)\MSSQLLocalDB;Database=AracKiralama;TrustServerCertificate=true;`)*

3. **API'yi Başlatın:**
   Öncelikle **AracKiralamaApi** projesini derleyip çalıştırın. Tarayıcınızda otomatik olarak API dokümantasyonu olan `Swagger UI` ekranı açılacaktır.

4. **Web Arayüzünü (MVC) Başlatın:**
   API projesi arka planda çalışmaya devam ederken, **AracKiralamaMvc** projesini çalıştırın. Web uygulaması tarayıcınızda açılacak ve sistem kullanıma hazır olacaktır.

## 🤝 Katkıda Bulunma
Bu projeye katkıda bulunmak isterseniz:
1. Projeyi *Fork* edin.
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/YeniOzellik`).
3. Değişikliklerinizi *Commit* edin (`git commit -m 'Yeni özellik eklendi'`).
4. Dalınızı *Push* edin (`git push origin feature/YeniOzellik`).
5. Bir *Pull Request* başlatın.

## 📄 Lisans
Bu proje geliştirilmeye açık olup, eğitim ve referans amaçlı hazırlanmıştır. Özgürce kullanabilir ve kendinize göre özelleştirebilirsiniz.

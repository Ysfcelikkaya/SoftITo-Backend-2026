<div align="center">
  <h1>🏠 Emlak Yönetim Sistemi (Real Estate Management System)</h1>
  <p>ASP.NET Core MVC ve Entity Framework Core ile geliştirilmiş kapsamlı bir gayrimenkul yönetim platformu.</p>

  <!-- Badges -->
  <img src="https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet" alt="ASP.NET Core MVC" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity_Framework-Core-0078D7?style=for-the-badge&logo=dotnet" alt="EF Core" />
  <img src="https://img.shields.io/badge/Architecture-N--Tier-FF6F00?style=for-the-badge" alt="N-Tier Architecture" />
</div>

<br/>

## 📖 Proje Hakkında

**Emlak Yönetim Sistemi**, gayrimenkul danışmanlarının ve kullanıcıların emlak alım-satım ve kiralama süreçlerini dijital ortamda yönetmelerini sağlayan modern bir web uygulamasıdır. Kullanıcı dostu arayüzü ve güçlü altyapısı sayesinde ilan yönetimi, randevu takibi ve favori ilanları kaydetme gibi işlemleri hızlı ve güvenilir bir şekilde gerçekleştirmenizi sağlar.

## ✨ Öne Çıkan Özellikler

*   🔑 **Kullanıcı & Rol Yönetimi:** Müşteri ve Yönetici (Admin) olmak üzere farklı yetki seviyelerine sahip gelişmiş kullanıcı rolleri.
*   🏢 **Detaylı İlan Yönetimi:** Satılık, kiralık vb. farklı emlak tipleri için görsel destekli, detaylı ilan oluşturma, düzenleme ve silme.
*   📅 **Randevu Sistemi:** Kullanıcıların ilgilendikleri gayrimenkuller için sistem üzerinden takvim entegreli randevu talep edebilmesi.
*   ❤️ **Favoriler:** Ziyaretçilerin beğendikleri ilanları kendi listelerine ekleyerek (favorileme) daha sonra kolayca ulaşabilmesi.
*   🛠️ **Yönetim Paneli (Admin):** Yöneticilerin sistemdeki tüm ilanları, onay bekleyenleri, kullanıcıları ve randevuları merkezi olarak kontrol edebileceği arayüz.

## 🏗️ Mimari ve Teknolojiler

Proje, sürdürülebilir, test edilebilir ve genişletilebilir bir yapı kurmak adına modern yazılım mimarisi prensipleriyle (S.O.L.I.D) geliştirilmiştir.

*   **Çerçeve (Framework):** ASP.NET Core MVC
*   **Katmanlı Mimari (N-Tier Architecture):**
    *   🌐 `EmlakProjectORM` (Sunum ve Arayüz Katmanı / Web)
    *   🧱 `EmlakProjectORM.Models` (Domain Varlıkları / Entities)
    *   💾 `EmlakProjectORM.Data` (Veri Erişim Katmanı / Data Access)
*   **Tasarım Şablonları (Design Patterns):** 
    *   **Repository Pattern:** Veritabanı işlemlerini soyutlayarak tekrar kullanılabilir ve test edilebilir bir yapı sunar.
    *   **Unit of Work Pattern:** Veritabanı transaction işlemlerini tek bir merkezden yöneterek veri tutarlılığını garanti altına alır.
*   **ORM:** Entity Framework Core (Code-First yaklaşımı)
*   **Veritabanı:** MS SQL Server

## 📂 Proje Dizin Yapısı

```bash
📦 EmlakYonetimSistemi
 ┣ 📂 EmlakProjectORM         # MVC Projesi (Controllers, Views, wwwroot, Program.cs)
 ┣ 📂 EmlakProjectORM.Models  # Veritabanı Sınıfları (AppUser, Property, Appointment vb.)
 ┗ 📂 EmlakProjectORM.Data    # Veritabanı Context'i, Repository ve UoW Sınıfları
```

## 🚀 Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda (yerel ortamınızda) çalıştırmak için aşağıdaki adımları izleyin:

### 1. Projeyi İndirin
```bash
git clone https://github.com/kullaniciadi/EmlakYonetimSistemi.git
cd EmlakYonetimSistemi
```

### 2. Veritabanı Bağlantısını Ayarlayın
`EmlakProjectORM` projesi içerisindeki `appsettings.json` veya `appsettings.Development.json` dosyasını açarak `DefaultConnection` connection string'ini kendi yerel SQL Server ayarlarınıza göre güncelleyin.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmlakYonetimDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Veritabanını Oluşturun (Migrations)
Visual Studio üzerinde "Package Manager Console"u (PMC) açıp, Default Project olarak `EmlakProjectORM.Data`'yı seçerek şu komutu çalıştırın:
```powershell
Update-Database
```
Veya .NET CLI kullanıyorsanız terminalden şu komutu girin:
```bash
dotnet ef database update --project EmlakProjectORM.Data --startup-project EmlakProjectORM
```

### 4. Projeyi Başlatın
Visual Studio üzerinden projeyi `F5` ile başlatabilirsiniz. Terminal kullanıyorsanız:
```bash
cd EmlakProjectORM
dotnet run
```
Proje genellikle `https://localhost:5001` veya `http://localhost:5000` adresinde ayağa kalkacaktır.

## 🤝 Katkıda Bulunma

Bu proje geliştirmeye açıktır! Katkıda bulunmak isterseniz lütfen aşağıdaki adımları izleyin:
1. Bu depoyu (repository) fork'layın.
2. Yeni bir branch oluşturun (`git checkout -b feature/YeniOzellik`).
3. Değişikliklerinizi commit'leyin (`git commit -m 'Yeni harika bir özellik eklendi'`).
4. Branch'inizi push'layın (`git push origin feature/YeniOzellik`).
5. Bir Pull Request (PR) oluşturun.

## 📄 Lisans

Bu proje açık kaynaklıdır ve eğitim/geliştirme amacıyla paylaşılmıştır. İstediğiniz gibi kullanabilir ve geliştirebilirsiniz.

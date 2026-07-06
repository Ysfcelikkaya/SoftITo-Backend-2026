<div align="center">
  <h1>🏨 Otel Yönetim Sistemi (Hotel Management System)</h1>
  <p>
    <b>Modern, Hızlı ve Kullanışlı Bir ASP.NET Core MVC Otel Otomasyonu</b>
  </p>
  <br>
</div>

## 🌟 Proje Hakkında

**Otel Yönetim Sistemi**, otellerin oda, müşteri ve rezervasyon süreçlerini dijital ortamda yönetebilmesi için geliştirilmiş kapsamlı bir web uygulamasıdır. **ASP.NET Core MVC** (.NET 10) ve **Entity Framework Core** teknolojileri kullanılarak modern web standartlarına uygun, hızlı ve ölçeklenebilir bir yapıda tasarlanmıştır.

Kullanıcı dostu arayüzü sayesinde otel personelleri kolaylıkla odaların durumunu takip edebilir, yeni rezervasyonlar oluşturabilir ve müşteri kayıtlarını yönetebilir.

---

## ✨ Temel Özellikler

🔑 **Kullanıcı Doğrulama (Giriş / Kayıt Ol)**
- Personele özel giriş ve kayıt ekranları.
- Kolay ve güvenli oturum yönetimi.

🛏️ **Oda Yönetimi (Room Management)**
- Yeni oda ekleme, güncelleme ve silme işlemleri.
- Oda tiplerini belirleme (Suit, Tek Kişilik vb.).
- Günlük oda ücreti (Fiyat) belirleme.
- Odaların müsaitlik durumunu (Dolu/Boş) anlık olarak takip etme.

📅 **Rezervasyon Yönetimi (Reservation Management)**
- Belirli tarihler (Giriş-Çıkış) arasında müşteri için oda rezerve etme.
- Rezervasyon süresine ve oda fiyatına göre **Toplam Ücret** hesaplama.
- Çakışan rezervasyonları kontrol edebilme imkanı.

👥 **Müşteri / Kullanıcı Yönetimi (User Management)**
- Müşteri kayıtlarını oluşturma (Ad Soyad, E-Posta, Telefon Numarası).
- Müşterileri listeleme, güncelleme ve sistemden silme.

---

## 🛠️ Kullanılan Teknolojiler

Bu proje geliştirilirken sektör standardı olan güncel ve güçlü teknolojilerden faydalanılmıştır:

- **Backend:** C#, .NET 10, ASP.NET Core MVC
- **ORM:** Entity Framework Core 10
- **Veritabanı:** Microsoft SQL Server
- **Frontend:** HTML5, CSS3, Bootstrap 5, jQuery
- **Geliştirme Ortamı:** Visual Studio / Visual Studio Code

---

## 🚀 Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları sırasıyla izleyebilirsiniz:

### 1️⃣ Gereksinimler
- Bilgisayarınızda **.NET 10 SDK** yüklü olmalıdır.
- **SQL Server** (LocalDB veya tam sürüm) kurulu olmalıdır.
- Visual Studio 2022 veya güncel bir IDE.

### 2️⃣ Veritabanı Ayarları
`OtelProjesi` klasörü altındaki `appsettings.json` dosyasını açarak **SQL Server bağlantı dizenizi (Connection String)** kendi bilgisayarınıza göre düzenleyin:
```json
"ConnectionStrings": {
  "Default": "Server=YOUR_SERVER_NAME;Database=OtelSistemiDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```

### 3️⃣ Veritabanını Oluşturma (Migrations)
Proje dizininde (Terminal / Package Manager Console üzerinden) aşağıdaki komutları çalıştırarak veritabanı tablolarını oluşturun:

```bash
dotnet ef database update
```
*(veya Visual Studio'da Package Manager Console'dan `Update-Database` komutunu çalıştırın.)*

### 4️⃣ Projeyi Başlatma
Terminal ekranında aşağıdaki komutu yazarak projeyi ayağa kaldırabilirsiniz:
```bash
dotnet run
```
Proje genellikle `https://localhost:5001` veya benzer bir adreste çalışmaya başlayacaktır. Tarayıcınızdan bu adrese giderek sistemi kullanmaya başlayabilirsiniz!

---

## 📸 Ekran Görüntüleri ve Kullanım

*(Buraya projenizin ekran görüntülerini ekleyebilirsiniz.)*
- **Giriş Ekranı:** `![Giriş Ekranı](resim_linki)`
- **Oda Listesi:** `![Oda Listesi](resim_linki)`
- **Rezervasyon Paneli:** `![Rezervasyon](resim_linki)`

---

## 🤝 Katkıda Bulunma (Contributing)

1. Bu depoyu (repository) forklayın.
2. Yeni bir dal (branch) oluşturun: `git checkout -b ozellik/YeniOzellik`
3. Değişikliklerinizi commit edin: `git commit -m 'Yeni özellik eklendi'`
4. Dalınıza push yapın: `git push origin ozellik/YeniOzellik`
5. Bir Pull Request açın!

---

## 📜 Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakabilirsiniz. Herhangi bir ticari veya kişisel amaçla özgürce kullanıp geliştirebilirsiniz.

<div align="center">
  <br>
  <i>Bu proje sevgiyle ❤️ ve kodla 💻 geliştirilmiştir.</i>
</div>

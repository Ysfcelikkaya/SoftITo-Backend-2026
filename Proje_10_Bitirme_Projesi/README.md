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

---

## 📸 EKRAN GÖRÜNTÜLERİ

### 🌐 MVC Ön Yüz (Kullanıcı Arayüzü)

**1. Ana Karşılama Ekranı**
![Ana Sayfa](Screenshots/mvc1.png)
*Hastaların sisteme giriş yapabileceği, kayıt olabileceği ve e-randevu ekranlarına yönlendirildiği modern ana sayfa.*

**2. Kullanıcı Kayıt Ekranı**
![Kayıt Ekranı](Screenshots/mvc3.png)
*Sisteme ilk defa giriş yapacak hastalar için hazırlanmış kullanıcı dostu kayıt olma sayfası.*

**3. Şifre Yenileme Ekranı**
![Şifremi Unuttum](Screenshots/mvc2.png)
*Kullanıcıların unuttukları şifreleri güvenli bir şekilde sıfırlayabildikleri şifre yenileme sayfası.*

**4. Yönetim Paneli (Admin Dashboard)**
![Dashboard](Screenshots/mvc4_dashboard.png)
*Hastane yöneticileri ve doktorlar için tasarlanmış; istatistiklerin, randevuların ve gelirlerin takip edildiği kapsamlı kontrol paneli.*

**5. Semptom Kontrol Botu (Akıllı Yönlendirme)**
![Semptom Botu](Screenshots/mvc5_chatbot.png)
*Hastaların şikayetlerini dinleyip onları doğru polikliniğe (Örn: Göz Hastalıkları) yönlendiren yenilikçi asistan modülü.*

**6. Muayene ve Reçete Ekranı (Doktor Paneli)**
![Muayene Kaydı](Screenshots/mvc6_muayene.png)
*Doktorların hastalar için tanı koyduğu, reçete yazdığı ve tahlil sonuçlarını sisteme girdiği kapsamlı muayene kayıt ekranı.*

**7. Yeni Fatura Kesme İşlemi**
![Fatura Kesme](Screenshots/mvc7_fatura.png)
*Hastaların ayakta (randevulu) veya yatarak (oda yatışlı) tedavileri için detaylı faturalandırma ve ödeme yönetim ekranı.*

**8. Yeni Doktor ve Poliklinik Tanımlama**
![Doktor Ekleme](Screenshots/mvc8_doktor.png)
*Sisteme yeni uzman hekimlerin unvan, poliklinik ve hesap bilgileriyle birlikte eklendiği yetkilendirme sayfası.*

**9. Randevularım Listesi**
![Randevular](Screenshots/mvc9_randevularim.png)
*Geçmiş ve aktif randevuların durumlarının takip edilip iptal/tamamlama işlemlerinin yapıldığı liste.*

**10. Yeni Randevu Alma Ekranı**
![Yeni Randevu](Screenshots/mvc10_yenirandevu.png)
*Poliklinik ve doktora göre saat/tarih seçilerek anında randevu oluşturulan panel.*

**11. Detaylı Muayene Raporu**
![Muayene Raporu](Screenshots/mvc11_muayenerapor.png)
*Hastanın aldığı tanı, ilaçlar, laboratuvar sonuçları ve doktor notlarının bulunduğu PDF/çıktı alınabilir rapor.*

**12. Faturalar ve Ödemeler Listesi**
![Faturalar](Screenshots/mvc12_faturalistesi.png)
*Geçmiş faturaların, tutarların ve ödeme durumlarının (Ödendi/Ödenmedi) listelendiği ekran.*

**13. Hasta Listesi ve Yönetimi**
![Hasta Listesi](Screenshots/mvc13_hastalistesi.png)
*Kayıtlı hastaların filtrelenebildiği, excel/pdf olarak indirilebildiği yönetim paneli listesi.*

**14. Hasta Profil Tanımlama Ekranı**
![Hasta Kayıt](Screenshots/mvc14_hastakayit.png)
*Yeni hastaların T.C. Kimlik, kan grubu ve iletişim bilgileriyle sisteme kaydedildiği detaylı form.*

**15. Dinamik PDF Rapor Çıktısı**
![PDF Rapor](Screenshots/mvc15_pdfrapor.png)
*Sistem üzerinden anlık olarak oluşturulan kurumsal PDF dökümleri (Hasta raporu, fatura vb).*

**16. Sistem Kullanıcıları ve Yetkilendirme**
![Kullanıcı Listesi](Screenshots/mvc16_kullanicilar.png)
*Yönetici, Doktor ve Hasta rollerine sahip tüm kullanıcıların yönetildiği merkezi liste.*

**17. Hastane Doktorları Listesi**
![Doktor Listesi](Screenshots/mvc17_doktorlar.png)
*Sistemdeki tüm uzman doktorların ve polikliniklerinin görüntülendiği yönetim paneli sayfası.*

**18. Yeni Kullanıcı Hesabı Açma**
![Yeni Kullanıcı](Screenshots/mvc18_yenikullanici.png)
*Sisteme yetkili (Admin, Doktor) veya standart kullanıcı (Hasta) hesaplarının tanımlandığı modal ekranı.*

**19. Poliklinikler Listesi**
![Poliklinikler](Screenshots/mvc19_poliklinikler.png)
*Hastanede bulunan tüm tıbbi birimlerin (Kardiyoloji, Göz vb.) yönetildiği sayfa.*

**20. Yeni Poliklinik Ekleme Modalı**
![Yeni Poliklinik](Screenshots/mvc20_yenipoliklinik.png)
*Sisteme yeni bir hastane bölümünün adı ve açıklamasıyla birlikte kaydedilmesi.*

**21. Yatan Hasta Odaları Listesi**
![Odalar](Screenshots/mvc21_odalar.png)
*Standart, VIP ve Yoğun Bakım (ICU) odalarının "Dolu/Boş" durumlarının takip edildiği yönetim ekranı.*

**22. Yeni Oda Tanımlama Modalı**
![Yeni Oda](Screenshots/mvc22_yenioda.png)
*Belirli bir polikliniğe bağlı yeni odaların kapasite ve tip özellikleriyle sisteme eklenmesi.*

**23. Oda Durumu Düzenleme**
![Oda Düzenle](Screenshots/mvc23_odaduzenle.png)
*Hastane personelinin yatan hastalar için odanın "Dolu mu?" durumunu anlık olarak değiştirebildiği ekran.*

### 🔌 API / Swagger (Servis Uç Noktaları)
<p align="center">
  <img src="Screenshots/api.png" width="48%" />
  <img src="Screenshots/api2.png" width="48%" />
</p>

### ⚡ Dapper Entegrasyonu
![Dapper Kullanımı](Screenshots/dapper.png)

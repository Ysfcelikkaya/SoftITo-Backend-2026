<div align="center">

# ğŸ¥ HASTANE YÃ–NETÄ°M SÄ°STEMÄ° ğŸ©º

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET_Core-Web_API-blue?style=for-the-badge&logo=blazor&logoColor=white)]()
[![C#](https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]()

<p align="center">
  <b>Modern, Ã¶lÃ§eklenebilir ve gÃ¼venli hastane ve saÄŸlÄ±k kurumu otomasyon yazÄ±lÄ±mÄ±.</b><br>
  <i>SoftITo 2026 Backend Bitirme Projesi</i>
</p>

</div>

---

## ğŸ“‹ Ä°Ã‡Ä°NDEKÄ°LER

- [ğŸ¯ Proje HakkÄ±nda](#-proje-hakkÄ±nda)
- [âœ¨ DetaylÄ± Ã–zellikler](#-detaylÄ±-Ã¶zellikler)
- [ğŸ›  KullanÄ±lan Teknolojiler](#-kullanÄ±lan-teknolojiler)
- [ğŸ’» Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [ğŸš€ Kurulum AdÄ±mlarÄ±](#-kurulum-adÄ±mlarÄ±)
- [ğŸ—‚ï¸ Proje Mimarisi](#ï¸-proje-mimarisi)

---

## ğŸ¯ PROJE HAKKINDA

**Hastane YÃ¶netim Sistemi**, hastane operasyonlarÄ±nÄ± (hasta kayÄ±t, doktor atama, randevu vb.) dijitalleÅŸtirmek amacÄ±yla geliÅŸtirilmiÅŸ uÃ§tan uca bir yazÄ±lÄ±m Ã§Ã¶zÃ¼mÃ¼dÃ¼r. Arka planda yÃ¼ksek performanslÄ± bir **RESTful Web API** koÅŸarken, Ã¶n tarafta **ASP.NET Core MVC** kullanÄ±larak kullanÄ±cÄ± dostu bir arayÃ¼z tasarlanmÄ±ÅŸtÄ±r.

Bu sistem sayesinde saÄŸlÄ±k kurumlarÄ±:

- ğŸ¥ **Hasta ve doktor bilgilerini** tek bir merkezden yÃ¶netebilir,
- ğŸ” **JWT tabanlÄ± kimlik doÄŸrulama** ile gÃ¼venli eriÅŸim saÄŸlayabilir,
- âš¡ **YÃ¼ksek performanslÄ± altyapÄ±** sayesinde iÅŸlemleri kesintisiz gerÃ§ekleÅŸtirebilir.

Proje, kurumsal mimari standartlarÄ±na ve temiz kod (Clean Code) prensiplerine uygun olarak geliÅŸtirilmiÅŸ olup, kritik sorgularda performansÄ± artÄ±rmak iÃ§in Stored Procedure ve Micro-ORM araÃ§larÄ± iÃ§ermektedir.

> **Not:** Bu proje, **SoftITo 2026 Backend Bitirme Projesi** kapsamÄ±nda tasarlanmÄ±ÅŸ ve geliÅŸtirilmiÅŸtir.

---

## âœ¨ DETAYLI Ã–ZELLÄ°KLER

Sistem, saÄŸlÄ±k kurumu iÅŸleyiÅŸini kolaylaÅŸtÄ±ran temel modÃ¼llerden oluÅŸur:

### ğŸ‘¥ 1. Hasta & Doktor YÃ¶netimi
- ğŸ“ **Hasta KaydÄ±:** Sisteme yeni hasta bilgilerinin eklenmesi ve dÃ¼zenlenmesi.
- ğŸ‘¨â€âš•ï¸ **Doktor YÃ¶netimi:** Ä°lgili branÅŸlara doktor atanmasÄ± ve takibi.

### ğŸ” 2. GÃ¼venlik & Yetkilendirme
- ğŸ›¡ï¸ **JWT Entegrasyonu:** GÃ¼venli oturum yÃ¶netimi ve bulut tabanlÄ± kimlik doÄŸrulama.
- ğŸ”‘ **Azure SDK:** Bulut hizmetleriyle entegre gÃ¼venlik Ã§Ã¶zÃ¼mleri.

### âš¡ 3. Performans Optimizasyonu
- ğŸš€ **Stored Procedures:** Kritik veritabanÄ± iÅŸlemlerinde (CRUD) yanÄ±t sÃ¼relerinin maksimize edilmesi.
- ğŸ”„ **Micro-ORM:** Ä°htiyaÃ§ duyulan noktalarda Dapper kullanÄ±larak yÃ¼ksek hÄ±zlÄ± veri Ã§ekimi.

### ğŸŒ 4. UÃ§tan Uca HaberleÅŸme
- ğŸ”Œ **API Ä°stemcisi:** MVC arayÃ¼zÃ¼nÃ¼n `HttpClient` kullanarak Web API'den kesintisiz veri alÄ±p vermesi.
- ğŸ“„ **DÃ¶kÃ¼mantasyon:** TÃ¼m servis uÃ§ noktalarÄ±nÄ±n **Swagger (OpenAPI)** ile test edilebilir formata getirilmesi.

---

## ğŸ›  KULLANILAN TEKNOLOJÄ°LER

Projenin altyapÄ±sÄ±nda sektÃ¶r standartlarÄ±na uygun, modern teknolojiler kullanÄ±lmÄ±ÅŸtÄ±r:

| Kategori | Teknoloji / AraÃ§ | Detay |
|---|---|---|
| âš™ï¸ **Backend** | `C# 12`, `.NET 8.0` | GÃ¼Ã§lÃ¼, gÃ¼venli ve performanslÄ± sunucu tarafÄ±. |
| ğŸŒ **API & ArayÃ¼z** | `ASP.NET Core Web API`, `MVC` | RESTful servisler ve kullanÄ±cÄ± dostu arayÃ¼z. |
| ğŸ—„ï¸ **Veri YÃ¶netimi** | `MS SQL Server`, `EF Core`, `Dapper` | Ä°liÅŸkisel veritabanÄ± ve ORM yaklaÅŸÄ±mlarÄ±. |
| ğŸ”’ **GÃ¼venlik** | `JWT (JSON Web Token)`, `Azure SDK` | Modern kimlik doÄŸrulama standartlarÄ±. |
| ğŸ§© **AraÃ§lar** | `Swagger`, `HttpClient`, `Git` | API dÃ¶kÃ¼mantasyonu ve versiyonlama. |

---

## ğŸ’» SÄ°STEM GEREKSÄ°NÄ°MLERÄ°

Projeyi sorunsuz Ã§alÄ±ÅŸtÄ±rabilmeniz iÃ§in geliÅŸtirme ortamÄ±nÄ±zda bulunmasÄ± gerekenler:

- ğŸŸ© **.NET 8.0 SDK**
- ğŸ—„ï¸ **MS SQL Server** (LocalDB veya standart kurulum)
- ğŸ’» **IDE:** Visual Studio 2022 (Tavsiye edilen) veya Visual Studio Code.

---

## ğŸš€ KURULUM ADIMLARI

Projeyi kendi bilgisayarÄ±nÄ±zda Ã§alÄ±ÅŸtÄ±rmak iÃ§in aÅŸaÄŸÄ±daki adÄ±mlarÄ± sÄ±rasÄ±yla takip ediniz:

### AdÄ±m 1: Projeyi KlonlayÄ±n

```bash
git clone https://github.com/Ysfcelikkaya/Bitirme_Projesi.git
cd Bitirme_Projesi/HospitalApp
```

### AdÄ±m 2: VeritabanÄ± BaÄŸlantÄ±sÄ±nÄ± AyarlayÄ±n
`appsettings.json` dosyalarÄ±ndaki `ConnectionStrings:Default` bÃ¶lÃ¼mÃ¼nÃ¼n yerel SQL Server ayarlarÄ±nÄ±za uygun olduÄŸundan emin olun.

### AdÄ±m 3: BaÄŸÄ±mlÄ±lÄ±klarÄ± YÃ¼kleyin ve Derleyin

Projeyi derlemek iÃ§in terminalde aÅŸaÄŸÄ±daki komutu Ã§alÄ±ÅŸtÄ±rÄ±n:

```bash
dotnet build
```

### AdÄ±m 4: Projeyi Ã‡alÄ±ÅŸtÄ±rÄ±n

Ã–nce API projesini, ardÄ±ndan MVC projesini Ã§alÄ±ÅŸtÄ±rÄ±n:

```bash
# API projesi iÃ§in
cd HospitalAppApi/HospitalAppApi
dotnet run

# Yeni bir terminalde MVC projesi iÃ§in
cd ../../HospitalAppMvc/HospitalAppMvc
dotnet run
```

TarayÄ±cÄ±nÄ±z Ã¼zerinden MVC uygulamasÄ±na veya Swagger dÃ¶kÃ¼mantasyon sayfasÄ±na (API portu Ã¼zerinden) ulaÅŸabilirsiniz.

---

## ğŸ—‚ï¸ PROJE MÄ°MARÄ°SÄ° (Ã‡ok KatmanlÄ± YapÄ±)

Proje dizin yapÄ±sÄ±, anlaÅŸÄ±labilirlik ve sÃ¼rdÃ¼rÃ¼lebilirlik aÃ§Ä±sÄ±ndan Ã‡ok KatmanlÄ± (N-Tier) standartlarÄ±na uygun olarak tasarlanmÄ±ÅŸtÄ±r:

```text
ğŸ“‚ HospitalApp
â”œâ”€â”€ ğŸ“ HospitalAppApi/    # RESTful servislerin barÄ±ndÄ±rÄ±ldÄ±ÄŸÄ± backend katmanÄ±
â”œâ”€â”€ ğŸ“ HospitalAppMvc/    # Web API ile haberleÅŸen son kullanÄ±cÄ± arayÃ¼z katmanÄ±
â””â”€â”€ ğŸ“ HospitalAppDppr/   # Dapper (Micro-ORM) ile veri eriÅŸimi yapÄ±lan katman
```

---

## ğŸ“¸ EKRAN GÃ–RÃœNTÃœLERÄ°

### ğŸŒ MVC Ã–n YÃ¼z (KullanÄ±cÄ± ArayÃ¼zÃ¼)

**1. Ana KarÅŸÄ±lama EkranÄ±**
![Ana Sayfa](Screenshots/mvc1.png)
*HastalarÄ±n sisteme giriÅŸ yapabileceÄŸi, kayÄ±t olabileceÄŸi ve e-randevu ekranlarÄ±na yÃ¶nlendirildiÄŸi modern ana sayfa.*

**2. KullanÄ±cÄ± KayÄ±t EkranÄ±**
![KayÄ±t EkranÄ±](Screenshots/mvc3.png)
*Sisteme ilk defa giriÅŸ yapacak hastalar iÃ§in hazÄ±rlanmÄ±ÅŸ kullanÄ±cÄ± dostu kayÄ±t olma sayfasÄ±.*

**3. Åifre Yenileme EkranÄ±**
![Åifremi Unuttum](Screenshots/mvc2.png)
*KullanÄ±cÄ±larÄ±n unuttuklarÄ± ÅŸifreleri gÃ¼venli bir ÅŸekilde sÄ±fÄ±rlayabildikleri ÅŸifre yenileme sayfasÄ±.*

**4. YÃ¶netim Paneli (Admin Dashboard)**
![Dashboard](Screenshots/mvc4_dashboard.png)
*Hastane yÃ¶neticileri ve doktorlar iÃ§in tasarlanmÄ±ÅŸ; istatistiklerin, randevularÄ±n ve gelirlerin takip edildiÄŸi kapsamlÄ± kontrol paneli.*

**5. Semptom Kontrol Botu (AkÄ±llÄ± YÃ¶nlendirme)**
![Semptom Botu](Screenshots/mvc5_chatbot.png)
*HastalarÄ±n ÅŸikayetlerini dinleyip onlarÄ± doÄŸru polikliniÄŸe (Ã–rn: GÃ¶z HastalÄ±klarÄ±) yÃ¶nlendiren yenilikÃ§i asistan modÃ¼lÃ¼.*

**6. Muayene ve ReÃ§ete EkranÄ± (Doktor Paneli)**
![Muayene KaydÄ±](Screenshots/mvc6_muayene.png)
*DoktorlarÄ±n hastalar iÃ§in tanÄ± koyduÄŸu, reÃ§ete yazdÄ±ÄŸÄ± ve tahlil sonuÃ§larÄ±nÄ± sisteme girdiÄŸi kapsamlÄ± muayene kayÄ±t ekranÄ±.*

**7. Yeni Fatura Kesme Ä°ÅŸlemi**
![Fatura Kesme](Screenshots/mvc7_fatura.png)
*HastalarÄ±n ayakta (randevulu) veya yatarak (oda yatÄ±ÅŸlÄ±) tedavileri iÃ§in detaylÄ± faturalandÄ±rma ve Ã¶deme yÃ¶netim ekranÄ±.*

**8. Yeni Doktor ve Poliklinik TanÄ±mlama**
![Doktor Ekleme](Screenshots/mvc8_doktor.png)
*Sisteme yeni uzman hekimlerin unvan, poliklinik ve hesap bilgileriyle birlikte eklendiÄŸi yetkilendirme sayfasÄ±.*

**9. RandevularÄ±m Listesi**
![Randevular](Screenshots/mvc9_randevularim.png)
*GeÃ§miÅŸ ve aktif randevularÄ±n durumlarÄ±nÄ±n takip edilip iptal/tamamlama iÅŸlemlerinin yapÄ±ldÄ±ÄŸÄ± liste.*

**10. Yeni Randevu Alma EkranÄ±**
![Yeni Randevu](Screenshots/mvc10_yenirandevu.png)
*Poliklinik ve doktora gÃ¶re saat/tarih seÃ§ilerek anÄ±nda randevu oluÅŸturulan panel.*

**11. DetaylÄ± Muayene Raporu**
![Muayene Raporu](Screenshots/mvc11_muayenerapor.png)
*HastanÄ±n aldÄ±ÄŸÄ± tanÄ±, ilaÃ§lar, laboratuvar sonuÃ§larÄ± ve doktor notlarÄ±nÄ±n bulunduÄŸu PDF/Ã§Ä±ktÄ± alÄ±nabilir rapor.*

**12. Faturalar ve Ã–demeler Listesi**
![Faturalar](Screenshots/mvc12_faturalistesi.png)
*GeÃ§miÅŸ faturalarÄ±n, tutarlarÄ±n ve Ã¶deme durumlarÄ±nÄ±n (Ã–dendi/Ã–denmedi) listelendiÄŸi ekran.*

**13. Hasta Listesi ve YÃ¶netimi**
![Hasta Listesi](Screenshots/mvc13_hastalistesi.png)
*KayÄ±tlÄ± hastalarÄ±n filtrelenebildiÄŸi, excel/pdf olarak indirilebildiÄŸi yÃ¶netim paneli listesi.*

**14. Hasta Profil TanÄ±mlama EkranÄ±**
![Hasta KayÄ±t](Screenshots/mvc14_hastakayit.png)
*Yeni hastalarÄ±n T.C. Kimlik, kan grubu ve iletiÅŸim bilgileriyle sisteme kaydedildiÄŸi detaylÄ± form.*

**15. Dinamik PDF Rapor Ã‡Ä±ktÄ±sÄ±**
![PDF Rapor](Screenshots/mvc15_pdfrapor.png)
*Sistem Ã¼zerinden anlÄ±k olarak oluÅŸturulan kurumsal PDF dÃ¶kÃ¼mleri (Hasta raporu, fatura vb).*

**16. Sistem KullanÄ±cÄ±larÄ± ve Yetkilendirme**
![KullanÄ±cÄ± Listesi](Screenshots/mvc16_kullanicilar.png)
*YÃ¶netici, Doktor ve Hasta rollerine sahip tÃ¼m kullanÄ±cÄ±larÄ±n yÃ¶netildiÄŸi merkezi liste.*

**17. Hastane DoktorlarÄ± Listesi**
![Doktor Listesi](Screenshots/mvc17_doktorlar.png)
*Sistemdeki tÃ¼m uzman doktorlarÄ±n ve polikliniklerinin gÃ¶rÃ¼ntÃ¼lendiÄŸi yÃ¶netim paneli sayfasÄ±.*

**18. Yeni KullanÄ±cÄ± HesabÄ± AÃ§ma**
![Yeni KullanÄ±cÄ±](Screenshots/mvc18_yenikullanici.png)
*Sisteme yetkili (Admin, Doktor) veya standart kullanÄ±cÄ± (Hasta) hesaplarÄ±nÄ±n tanÄ±mlandÄ±ÄŸÄ± modal ekranÄ±.*

**19. Poliklinikler Listesi**
![Poliklinikler](Screenshots/mvc19_poliklinikler.png)
*Hastanede bulunan tÃ¼m tÄ±bbi birimlerin (Kardiyoloji, GÃ¶z vb.) yÃ¶netildiÄŸi sayfa.*

**20. Yeni Poliklinik Ekleme ModalÄ±**
![Yeni Poliklinik](Screenshots/mvc20_yenipoliklinik.png)
*Sisteme yeni bir hastane bÃ¶lÃ¼mÃ¼nÃ¼n adÄ± ve aÃ§Ä±klamasÄ±yla birlikte kaydedilmesi.*

**21. Yatan Hasta OdalarÄ± Listesi**
![Odalar](Screenshots/mvc21_odalar.png)
*Standart, VIP ve YoÄŸun BakÄ±m (ICU) odalarÄ±nÄ±n "Dolu/BoÅŸ" durumlarÄ±nÄ±n takip edildiÄŸi yÃ¶netim ekranÄ±.*

**22. Yeni Oda TanÄ±mlama ModalÄ±**
![Yeni Oda](Screenshots/mvc22_yenioda.png)
*Belirli bir polikliniÄŸe baÄŸlÄ± yeni odalarÄ±n kapasite ve tip Ã¶zellikleriyle sisteme eklenmesi.*

**23. Oda Durumu DÃ¼zenleme**
![Oda DÃ¼zenle](Screenshots/mvc23_odaduzenle.png)
*Hastane personelinin yatan hastalar iÃ§in odanÄ±n "Dolu mu?" durumunu anlÄ±k olarak deÄŸiÅŸtirebildiÄŸi ekran.*

**24. Yatan Hastalar (YatÄ±ÅŸlar) Listesi**
![Yatan Hastalar](Screenshots/mvc24_yatan_hastalar.png)
*Yatan hastalarÄ±n oda numaralarÄ±, yatÄ±ÅŸ tarihleri ve taburcu durumlarÄ±nÄ±n yÃ¶netildiÄŸi sayfa.*

**25. Yeni Hasta YatÄ±ÅŸÄ± ModalÄ±**
![Hasta YatÄ±ÅŸÄ±](Screenshots/mvc25_yeni_yatis.png)
*Poliklinik randevusu sonrasÄ± hastanÄ±n hastaneye yatÄ±ÅŸÄ±nÄ±n boÅŸ odalara gÃ¶re yapÄ±ldÄ±ÄŸÄ± tahsis ekranÄ±.*

**26. Fatura ve Ã–deme Durumu Takibi**
![Fatura Durumu](Screenshots/mvc26_fatura_odeme_durumu.png)
*Vezne personelinin tÃ¼m faturalarÄ± "Ã–dendi" veya "Ã–denmedi" durumlarÄ±na gÃ¶re filtreleyip takip ettiÄŸi liste.*

**27. Online Ã–deme ve Tahsilat**
![Fatura Ã–dendi](Screenshots/mvc27_fatura_odendi.png)
*HastalarÄ±n kredi kartÄ± ile fatura Ã¶demesi yaptÄ±ktan sonra anÄ±nda sistemde "Ã–dendi" durumuna geÃ§iÅŸi.*

**28. Kurumsal Fatura PDF Ã‡Ä±ktÄ±sÄ±**
![Fatura PDF](Screenshots/mvc28_fatura_pdf.png)
*Maliye ve yasal sÃ¼reÃ§lere uygun, hastane logolu "Tahsil Edildi" kaÅŸeli PDF fatura dÃ¶kÃ¼mÃ¼.*

**29. Hasta Paneli: RandevularÄ±m**
![Hasta Randevular](Screenshots/mvc29_hasta_randevularim.png)
*HastanÄ±n sisteme giriÅŸ yaptÄ±ÄŸÄ±nda kendi aktif ve geÃ§miÅŸ randevularÄ±nÄ± gÃ¶rebildiÄŸi kiÅŸisel profil sayfasÄ±.*

**30. Hasta Paneli: Yeni Randevu Al**
![Hasta Yeni Randevu](Screenshots/mvc30_hasta_yeni_randevu.png)
*HastalarÄ±n poliklinik ve uygun doktora gÃ¶re kendi kendilerine dijital olarak randevu alabildiÄŸi takvim paneli.*

**31. Hasta Paneli: Muayene RaporlarÄ±m**
![Hasta Raporlar](Screenshots/mvc31_hasta_raporlarim.png)
*HastanÄ±n kendi laboratuvar (kan/rÃ¶ntgen) sonuÃ§larÄ±na, teÅŸhislerine ve reÃ§etelerine online eriÅŸim ekranÄ±.*

**32. TÄ±bbi Muayene PDF Raporu**
![TÄ±bbi Rapor PDF](Screenshots/mvc32_tibbi_rapor_pdf.png)
*HastanÄ±n iÅŸyeri veya diÄŸer kurumlar iÃ§in indirebildiÄŸi, doktor imzalÄ± resmi tÄ±bbi muayene raporu.*

**33. Hasta Paneli: FaturalarÄ±m**
![Hasta Faturalar](Screenshots/mvc33_hasta_faturalarim.png)
*HastanÄ±n aldÄ±ÄŸÄ± saÄŸlÄ±k hizmetlerinin masraflarÄ±nÄ± ve gÃ¼ncel borÃ§ durumunu gÃ¶rebildiÄŸi finans ekranÄ±.*

### ğŸ”Œ API / Swagger (Servis UÃ§ NoktalarÄ±)
<p align="center">
  <img src="Screenshots/api.png" width="48%" />
  <img src="Screenshots/api2.png" width="48%" />
</p>

### âš¡ Dapper Entegrasyonu
![Dapper KullanÄ±mÄ±](Screenshots/dapper.png)

 

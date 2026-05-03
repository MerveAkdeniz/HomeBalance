<h1 align="center">🏠 HomeBalance API</h1>

<div align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity%20Framework-0078D7?style=for-the-badge&logo=.net&logoColor=white" alt="Entity Framework" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Clean%20Architecture-FF9900?style=for-the-badge&logo=architecture&logoColor=white" alt="Clean Architecture" />
</div>

<br/>

<p align="center">
  <b>Ev arkadaşları ve ortak yaşam alanları için geliştirilmiş, harcama ve borç takibini otomatikleştiren yüksek performanslı RESTful API projesi.</b>
</p>

---

## 🎯 Projenin Amacı

Ortak evlerde veya gruplarda yaşanan *"Kim ne ödedi?"*, *"Kim kime ne kadar borçlu?"* gibi karmaşık hesaplama süreçlerini ortadan kaldırmayı hedefler. Gelişmiş **Balance Engine (Borç Hesaplama Motoru)** sayesinde, çoklu ve karmaşık para transferlerini analiz ederek en sade ödeme planını çıkarır.

## ✨ Öne Çıkan Özellikler

*   👥 **Kullanıcı ve Grup Yönetimi:** Kullanıcılar oluşturulabilir ve birden fazla paylaşımlı gruba dahil olabilir.
*   💸 **Harcama Takibi:** Gruplara özel harcamalar kaydedilebilir, harcamayı kimin yaptığı izlenebilir.
*   ⚖️ **Akıllı Borç Hesaplama (Balance Engine):** Karmaşık borç döngülerini çözümleyerek kimin kime tam olarak ne kadar ödemesi gerektiğini net bir şekilde hesaplar.
*   🛒 **Ortak İhtiyaç Listesi:** Ev eksikleri ve alışveriş listesinin (ShoppingItem) kolay yönetimi.
*   🛡️ **Veri Güvenliği ve Doğrulama:** DTO'lar (Data Transfer Objects) ve Data Annotations/Validation ile güvenli, kontrollü veri akışı.
*   📖 **Otomatik Dokümantasyon:** Swagger (OpenAPI) entegrasyonu ile tüm API uç noktalarının (endpoint) interaktif dokümantasyonu ve test imkanı.

## 📐 Mimari ve Tasarım Desenleri

Bu proje, kodun sürdürülebilirliğini, bağımsızlığını ve test edilebilirliğini en üst düzeye çıkarmak amacıyla **Clean Architecture (Temiz Mimari)** prensiplerine sıkı sıkıya bağlı kalınarak 4 temel katmanda geliştirilmiştir:

1.  **Domain Layer:** Projenin kalbi. Temel Entity'ler ve arayüzler (Hiçbir dış kütüphaneye bağımlılık barındırmaz).
2.  **Application Layer:** İş kuralları (Business Logic), DTO'lar ve Validation işlemleri.
3.  **Infrastructure Layer:** Veritabanı bağlantıları, Entity Framework Core yapılandırmaları, veritabanı entegrasyonu ve SQL Server işlemleri.
4.  **API Layer:** Gelen HTTP isteklerini karşılayan Controller'lar, Dependency Injection ayarları ve Swagger yapılandırması.

## 🛠️ Kullanılan Teknolojiler

*   **Platform:** ASP.NET Core Web API (.NET 8)
*   **ORM:** Entity Framework Core
*   **Veritabanı:** Microsoft SQL Server
*   **Dokümantasyon:** Swagger / OpenAPI
*   **Mimari Yaklaşım:** Clean Architecture, N-Tier Architecture
*   **Test:** xUnit (Opsiyonel test entegrasyonları için hazır altyapı)

---

## 🚀 Kurulum ve Çalıştırma

Projeyi yerel ortamınızda ayağa kaldırmak için aşağıdaki adımları izleyin:

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/MerveAkdeniz/HomeBalance.API.git
cd HomeBalance.API
```

### 2. Veritabanı Bağlantısını Ayarlayın
API katmanındaki `appsettings.json` dosyasını açın ve SQL Server bağlantı dizenizi (Connection String) sisteminize uygun şekilde ekleyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=HomeBalanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Migration İşlemleri ve Veritabanı Oluşturma
Package Manager Console (PMC) üzerinden veya .NET CLI ile veritabanını ayağa kaldırın:
```bash
# Package Manager Console Kullanıyorsanız:
Add-Migration InitialCreate -StartupProject HomeBalance.API
Update-Database
```

### 4. Projeyi Çalıştırın
```bash
dotnet run --project HomeBalance.API
```
Proje çalıştıktan sonra tarayıcınızdan `https://localhost:<port>/swagger` adresine giderek API'yi arayüz üzerinden test edebilirsiniz.

---

## 🔌 Örnek Uç Noktalar (Endpoints)

| HTTP Metodu | Endpoint | Açıklama |
| :--- | :--- | :--- |
| `POST` | `/api/Users` | Yeni kullanıcı kaydı oluşturur |
| `POST` | `/api/Groups` | Yeni bir ev/grup ortamı oluşturur |
| `POST` | `/api/Expenses` | İlgili gruba yeni bir harcama faturası ekler |
| `GET` | `/api/Balances/{groupId}` | **Grup içi detaylı borç durumunu hesaplar (Balance Engine)** |

<details>
<summary><b>Örnek JSON İsteklerini (Payload) Görmek İçin Tıklayın</b></summary>

**Kullanıcı Oluşturma (POST /api/Users)**
```json
{
  "name": "Merve",
  "email": "merve@gmail.com",
  "password": "123"
}
```

**Harcama Ekleme (POST /api/Expenses)**
```json
{
  "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "paidByUserId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "amount": 150.00,
  "description": "Market"
}
```
</details>

---

## 👩‍💻 Geliştirici

**Merve Akdeniz**  
*Bilişim Sistemleri Mühendisi*  
[LinkedIn](https://www.linkedin.com/in/merveakdeniz) | [GitHub](https://github.com/MerveAkdeniz)

---
*Bu proje, modern yazılım geliştirme standartları göz önünde bulundurularak, gerçek dünya problemlerine ölçeklenebilir çözümler üretmek amacıyla geliştirilmiştir.*

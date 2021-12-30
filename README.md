# Trendyol Web Url ve Deep Link Çevirici Uygulaması
Case çalışmasında istenen uygulama için yazılım dili olarak .net core (v3.1), veri tabanı olarak postgresql ve web servis olarakda asp.net web api tercih edilerek geliştirme yapılmıştır. Proje mimarisi için open source şablonların için bir bilgi olmadığından tüm mimariyi kendim hazırladım. 

Öncelikle mimari geliştirildi tüm interface, class, enum, metod imzaları vb. tamamlandı. Metod içerisinde business logic sona bırakılarak test metodları hazırlandı. Özetlemek gerekirse geliştirme sürecinde TDD dikkat edildi.

Geliştirmeler öncelikle test metodları sonra servisi lokalde çalıştırarak ve son olarakda docker compose ile çalıştırıldıktan sonra test edilmiştir. Lokal ve docker compose ile sadece swagger üzerinden kullanılmıştır. Birim tesler çalıştıktan sonra tüm tablo truncate edilmiştir.

## Hızlı kurulum için bağımlılıklar
- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/downloads)


## Hızlı Kurulum
- `git clone https://github.com/DevelopmentHiring/TrendyolCase-FatihGurdal`

-  `cd TrendyolCase-FatihGurdal`

- `docker-compose up`

-	http://localhost:8000 ile swagger karşılanır.


## Kullanılan Teknoloji ve Kütüphaneler
**Framework:** .NET Core 3.1 ile Web Api

**Database:** Postgre SQL

**ORM:** [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore "EntityFrameworkCore") & Mapping

**Validation:** [FluentValidation AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore/ "FluentValidation AspNetCore")

**Unit Test:** XUnit & [Shouldly](https://www.nuget.org/packages/Shouldly/ "Shouldly")

**Dokümantasyon:** [Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/ "Swagger")

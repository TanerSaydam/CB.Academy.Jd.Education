# Test Driven Development Eğitim İçeriği ve Ders Programı

## 15.11.2024
- [x] Test süerince DevOps
- [x] Integration Test Tekrarı
- [x] Test Container ve Mvc.Testing Tekrarı

## 14.11.2024
- [X] TDD nedir?
- [X] TDD ile proje yazmaya başlayalım

## 13.11.2024
- [x] Integration test nedir?
- [x] İlk Integration testimizi yazalım
- [x] Integration Test isimlendirme kuralları
- [x] Test setup
- [x] Test cleanup
- [x] WebApplication Factory
- [x] Testing status codes
- [x] Testing text responses
- [x] Testing JSON responses
- [x] Creating realistic test data
- [x] Cleaning up the test data
- [x] Creating a test container for our database

## 12.11.2024
- [x] Parameterizing Tests
- [x] Ignoring Tests
- [x] Object Test
- [x] Enumerables Test
- [x] Private ve Internal Metot Testi
- [x] AutoFixture (https://code-maze.com/csharp-test-data-generation-with-autofixture)
- [x] Bogus
- [x] NSubstitute
- [x] Moq vs NSubstitute
- [x] Gerçek hayat projesi oluşturup test yazalım

## 11.11.2024
- [x] Test Nedir?
- [x] Test türleri nelerdir?
- [x] Test piramidi
- [x] Test proje kalıpları
- [x] İlk testimizi yazalım
- [x] Solution Structure
- [x] Unit Test isimlendirme kuralları
- [x] Arrange, Act, Assert
- [x] Execution Model
- [x] Test Setup ve Teardown
- [x] Fluent Assertions
- [x] String Test
- [x] Number Test
- [x] Date Test
- [x] Throw Exception Test

## Test Driven Development

### Not: 
Docker compose çalıştırma kodu
```
docker compose up -d
```

SSL sertifikası oluşturmna
```
dotnet dev-certs https --trust
dotnet dev-certs https -ep cert.pfx -p Test1234!
```

coverage
```
dotnet add package coverlet.msbuild
dotnet test --collect:"XPlat Code Coverage"
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"../coverage.cobertura.xml" -targetdir:"../CoverletReport"
```
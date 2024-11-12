# Test Driven Development Eğitim İçeriği ve Ders Programı

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

## Unit Test
- [ ] Parameterizing Tests
- [ ] Ignoring Tests
- [ ] Object Test
- [ ] Enumerables Test
- [ ] Private ve Internal Metot Testi
- [ ] NSubstitute
- [ ] Moq vs NSubstitute
- [ ] Gerçek hayat projesi oluşturup test yazalım
- [ ] AutoFixture (https://code-maze.com/csharp-test-data-generation-with-autofixture)
- [ ] Bogus

## Integration Test
- [ ] Integration test nedir?
- [ ] İlk Integration testimizi yazalım
- [ ] Integration Test isimlendirme kuralları
- [ ] Test setup
- [ ] Test cleanup
- [ ] WebApplication Factory
- [ ] Testing status codes
- [ ] Testing text responses
- [ ] Testing JSON responses
- [ ] Testing response headers
- [ ] Creating realistic test data
- [ ] Cleaning up the test data
- [ ] Sharing a single application for multiple test classes
- [ ] Create WebApplication Factory
- [ ] Creating a test container for our database
- [ ] WireMock
- [ ] Creating a mocked API server with WireMock
- [ ] Create a resource
- [ ] Getting a resource
- [ ] Getting all resources
- [ ] Updating a resource
- [ ] Deleting a resource
- [ ] API Dependency is unavailable
- [ ] Dealing with requests requiring auth
- [ ] Dealing with background services

## Test Driven Development

### Not: 
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
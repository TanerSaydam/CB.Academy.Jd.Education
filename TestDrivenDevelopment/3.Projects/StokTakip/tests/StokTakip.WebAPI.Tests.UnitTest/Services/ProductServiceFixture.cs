using AutoMapper;
using GenericRepository;
using NSubstitute;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest.Services;

public sealed class ProductServiceFixture
{
    public IProductRepository productRepository = Substitute.For<IProductRepository>();
    public IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    public IMapper mapper = Substitute.For<IMapper>();
    public ProductService productService;
    public ProductServiceFixture()
    {
        productService = new(productRepository, unitOfWork, mapper);
    }
}
using BlaShop.CoreBusiness.Models;
using BlaShop.UseCases.Interfaces.DataStore;

namespace BlaShop.UseCases.SearchProductScreen;
public class SearchProduct : ISearchProduct
{
    private readonly IProductRepository _productRepository;

    public SearchProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> Execute(string? filter = null) => _productRepository.GetProducts(filter);
}

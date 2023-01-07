using BlaShop.CoreBusiness.Models;
using BlaShop.UseCases.Interfaces.DataStore;

namespace BlaShop.UseCases.SearchProductScreen;

public class ViewProduct : IViewProduct
{
    private readonly IProductRepository _productRepository;

    public ViewProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product Execute(int id)
    {
        return _productRepository.GetProduct(id);
    }
}

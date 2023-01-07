using BlaShop.CoreBusiness.Models;
using BlaShop.UseCases.Interfaces.DataStore;

namespace BlaShop.DataStore;

public class ProductRepository : IProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products= new List<Product> { 
            new Product { Id = 1, Brand="BrandTestOne", Name="NameTestOne", ImageLink="ImageLinkTestOne", Price=11.30 },
            new Product { Id = 2, Brand="BrandTestTwo", Name="NameTestTwo", ImageLink="ImageLinkTestTwo", Price=8.65 },
            new Product { Id = 3, Brand="BrandTestThree", Name="NameTestThree", ImageLink="ImageLinkTestThree", Price=56.99 },
        };
    }

    public Product GetProduct(int id) => _products.FirstOrDefault(x => x.Id == id) ?? new Product();

    public IEnumerable<Product> GetProducts(string? filter = null)
    {
        if(String.IsNullOrWhiteSpace(filter)) return _products;

        return _products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
    }
}

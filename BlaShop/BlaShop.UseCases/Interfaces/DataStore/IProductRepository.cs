using BlaShop.CoreBusiness.Models;

namespace BlaShop.UseCases.Interfaces.DataStore;
public interface IProductRepository
{
    IEnumerable<Product> GetProducts(string? filter = null);

    Product GetProduct(int id);
}

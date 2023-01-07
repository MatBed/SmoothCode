using BlaShop.CoreBusiness.Models;

namespace BlaShop.UseCases.SearchProductScreen;
public interface ISearchProduct
{
    IEnumerable<Product> Execute(string? filter = null);
}
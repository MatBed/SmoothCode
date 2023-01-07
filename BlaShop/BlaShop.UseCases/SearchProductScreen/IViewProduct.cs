using BlaShop.CoreBusiness.Models;

namespace BlaShop.UseCases.SearchProductScreen;
public interface IViewProduct
{
    Product Execute(int id);
}
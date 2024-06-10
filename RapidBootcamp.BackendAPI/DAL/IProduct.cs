using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IProduct : ICrud<Product>
    {
        IEnumerable<Product> GetByProductName(string productName);
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetByCategoryName(string categoryName);
        IEnumerable<Product> GetProductsWithCategory();
    }
}

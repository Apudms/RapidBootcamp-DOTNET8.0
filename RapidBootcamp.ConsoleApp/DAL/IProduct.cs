using RapidBootcamp.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.DAL
{
    public interface IProduct : ICrudDal<Product>
    {
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetByCategoryName(string categoryName);
        IEnumerable<Product> GetProductsWithCategory();
    }
}

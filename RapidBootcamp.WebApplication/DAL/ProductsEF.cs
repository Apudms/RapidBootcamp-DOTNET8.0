using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class ProductsEF : IProduct
    {
        private readonly AppDbContext _dbContext;

        public ProductsEF(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        #region Add
        public Product Add(Product entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            try
            {
                var result = _dbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
                if (result != null)
                {
                    _dbContext.Products.Remove(result);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Product not found!");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region Get All
        public IEnumerable<Product> GetAll()
        {
            var result = _dbContext.Products.Include(c => c.Category).ToList();
            //var result = (from p in _dbContext.Products
            //              select p).ToList();
            return result;
        }
        #endregion

        #region Get By ID
        public Product GetById(int id)
        {
            var result = _dbContext.Products.Include(c => c.Category).Where(p => p.ProductId == id).FirstOrDefault();
            if(result == null)
            {
                throw new ArgumentException("Product not found!");
            }
            return result;
        }
        #endregion

        #region Get By Name
        public IEnumerable<Product> GetByProductName(string productName)
        {
            var result = _dbContext.Products.Include(c => c.Category).Where(p => p.ProductName.Contains(productName)).ToList();
            return result;
        }
        #endregion

        #region Update
        public Product Update(Product entity)
        {
            try
            {
                var updateProduct = GetById(entity.ProductId);
                if (updateProduct != null)
                {
                    updateProduct.ProductName = entity.ProductName;
                    updateProduct.Stock = entity.Stock;
                    updateProduct.Price = entity.Price;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Product not found!");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}

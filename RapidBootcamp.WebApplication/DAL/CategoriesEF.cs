using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesEF : ICategory
    {
        private readonly AppDbContext _dbContext;

        public CategoriesEF(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        #region Add
        public Category Add(Category entity)
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
                var result = _dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
                if (result != null)
                {
                    _dbContext.Categories.Remove(result);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Category Not Found!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        #endregion

        #region Get All
        public IEnumerable<Category> GetAll()
        {
            // Menggunakan Lambda
            //var result = _dbContext.Categories.ToList();
            //return result;

            // Menggunakan LINQ
            var result = from c in _dbContext.Categories
                         select c;
            return result.ToList();
        }
        #endregion

        #region Get By Name
        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            //var results = _dbContext.Categories.Where(c =>c.CategoryName.Contains(categoryName)).ToList();
            //return results;

            var results = (from c in _dbContext.Categories
                          where c.CategoryName.Contains(categoryName)
                          select c).ToList();

            return results;
        }
        #endregion

        #region Get By ID
        public Category GetById(int id)
        {
            // Menggunakan Lambda
            //var result = _dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            //if (result == null)
            //{
            //    throw new ArgumentException("Category Not Found");
            //}
            //return result;

            // Menggunakan LINQ
            var result = (from c in _dbContext.Categories
                          where c.CategoryId == id
                          select c).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Category Not Found!");
            }
            return result;
        }
        #endregion

        #region Update
        public Category Update(Category entity)
        {
            try
            {
                var updateCategory = GetById(entity.CategoryId);
                if (updateCategory != null)
                {
                    updateCategory.CategoryName = entity.CategoryName;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Category Not Found!");
                }
                return updateCategory;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}

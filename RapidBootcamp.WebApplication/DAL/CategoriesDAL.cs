using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesDAL : ICategory
    {
        private readonly IConfiguration _configuration;
        public CategoriesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Get Connection
        private string GetConStr()
        {
            return _configuration.GetConnectionString("ConnStr");
        }
        #endregion

        #region Add Category
        public Category Add(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"INSERT INTO Categories(CategoryName) 
                                    VALUES(@CategoryName); SELECT @@IDENTITY";

                    var param = new { CategoryName = entity.CategoryName };
                    //int result = conn.Execute(query, param);
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CategoryId = newId;
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
        #endregion

        #region Lupa nge-return, makanya error
        //public Category Add(Category entity)
        //{
        //    using (SqlConnection conn = new SqlConnection(GetConStr()))
        //    {
        //        try
        //        {
        //            string query = @"INSERT INTO Categories(CategoryName) 
        //                                VALUES(@CategoryName); SELECT @@IDENTITY";

        //            var param = new { CategoryName = entity.CategoryName };
        //            //int result = conn.Execute(query, param);
        //            int newId = conn.ExecuteScalar<int>(query, param);
        //            entity.CategoryId = newId;
        //        }
        //        catch (SqlConnection sqlEx)
        //        {
        //            throw new ArgumentException(sqlEx.Message);
        //        }
        //    }
        //}
        #endregion

        #region Delete Category
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"DELETE FROM Categories
                                 WHERE CategoryId = @CategoryId";

                var param = new{CategoryId = id};
                conn.Execute(query, param);
            }                
        }
        #endregion

        #region Get All Category
        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Categories
                                 ORDER BY CategoryName ASC";

                var categories = conn.Query<Category>(query);
                return categories;
            }
        }
        #endregion

        #region Get By Category Name
        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Categories
                                 WHERE CategoryName LIKE @CategoryName";

                var param = new { CategoryName = "%" + categoryName + "%" };
                var category = conn.Query<Category>(query, param);
                if (category == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return category;
            }
        }
        #endregion

        #region Get By ID
        public Category GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Categories
                                 WHERE CategoryId = @CategoryId";

                var param = new { CategoryId = id };
                var category = conn.QueryFirstOrDefault<Category>(query, param);
                if (category == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return category;
            }
        }
        #endregion

        #region Update Category
        public Category Update(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"UPDATE Categories
                                     SET CategoryName = @CategoryName
                                     WHERE CategoryId = @CategoryId";

                    var param = new { CategoryName = entity.CategoryName, CategoryId = entity.CategoryId };
                    conn.Execute(query, param);
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }
        #endregion
    }
}

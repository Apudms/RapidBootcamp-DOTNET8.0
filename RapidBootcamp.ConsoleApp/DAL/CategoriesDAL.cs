using RapidBootcamp.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.DAL
{
    //public class CategoriesDAL : ICrudDal<Category>
    public class CategoriesDAL : ICategory
    {
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public CategoriesDAL() 
        {
            //_connectionString = "Server=SQLEXPRESS;Database=RapidDb;User=sa;Password=1123456;Trusted_Connection=True;";
            _connectionString = "Server=RAPID;Database=RapidDb;Trusted_Connection=True;";
            _connection = new SqlConnection(_connectionString);
        }

        public Category Add(Category entity)
        {
            try
            {
                string query = @"INSERT INTO Categories(CategoryName)
                                 VALUES(@CategoryName); SELECT @@Identity";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                _connection.Open();
                
                int result = _command.ExecuteNonQuery();
                if (result == 1)
                {
                    return entity;
                }
                else
                {
                    throw new ArgumentException("Datak gagal disimpan");
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException($"Message Error: {sqlEx.Message}");
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public void Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM Categories
                                 WHERE CategoryId = @CategoryId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", id);
                _connection.Open();

                int result = _command.ExecuteNonQuery(); 
                if (result != 1)
                {
                    throw new ArgumentException("Data gagal dihapus! Pastikan data yang dipilih sesuai.");
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection?.Close();
                _command?.Dispose();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                List<Category> categories = new List<Category>();
                string query = @"SELECT * FROM Categories
                                 ORDER BY CategoryName ASC";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows) 
                {
                    while (_reader.Read()) 
                    {
                        //Category category = new Category();
                        //category.CategoryId = Convert.ToInt32(_reader["CategoryId"]);
                        //category.CategoryName = _reader["CategoryName"].ToString();
                        //categories.Add(category);

                        categories.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            CategoryName = _reader["CategoryName"].ToString()
                        });
                    }
                }
                _reader.Close();

                return categories;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException($"Error: {sqlEx.Message}");
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public Category GetById(int id)
        {
            try
            {
                Category category = new Category();
                string query = @"SELECT * FROM Categories
                                 WHERE CategoryId = @CategoryId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", id);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        category.CategoryId = Convert.ToInt32(_reader["CategoryID"]);
                        category.CategoryName = _reader["CategoryName"].ToString();
                    }
                }
                _reader.Close();
                return category;
            }
            catch (Exception sqlEx)
            {
                throw new ArgumentException($"Error: {sqlEx.Message}");
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public Category Update(Category entity)
        {
            try
            {
                Category category = new Category();
                string query = @"UPDATE Categories 
                                 SET CategoryName = @CategoryName 
                                 WHERE CategoryId = @CategoryId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _connection.Open();

                int result = _command.ExecuteNonQuery();
                if (result == 1)
                {
                    return entity;
                }
                else
                {
                    throw new ArgumentException("Data gagal di update, Mohon periksa kembali.");
                }
            }
            catch (Exception sqlEx)
            {
                throw new ArgumentException($"Error: {sqlEx.Message}");
            }
            finally
            {
                _connection?.Close();
                _command?.Dispose();
            }
        }

        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            try
            {
                Category category = new Category();
                string query = @"SELECT * FROM Categories
                                 WHERE CategoryName LIKE @CategoryName";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", "%" + categoryName + "%");
                _connection.Open();
                _reader = _command.ExecuteReader();

                List<Category> categories = new List<Category>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(_reader["CategoryID"]),
                            CategoryName = _reader["CategoryName"].ToString()
                        });
                    }
                }
                _reader.Close();
                return categories;
            }
            catch (Exception sqlEx)
            {
                throw new ArgumentException($"Error: {sqlEx.Message}");
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }
    }
}

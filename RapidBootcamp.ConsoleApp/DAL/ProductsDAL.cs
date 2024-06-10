using RapidBootcamp.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.DAL
{
    public class ProductsDAL : IProduct
    {
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public ProductsDAL()
        {
            _connectionString = "Server=RAPID;Database=RapidDb;Trusted_Connection=True;";
            _connection = new SqlConnection(_connectionString);
        }

        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM Products
                                 WHERE ProductId = @ProductId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("ProductId", id);
                _connection.Open();

                int result = _command.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ArgumentException("Data gagal dihapus!");
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"SELECT * FROM Products
                                 ORDER BY ProductName ASC";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Price = Convert.ToDecimal(_reader["Price"])
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Dara produk kosong");
                }

                _reader.Close();
                return products;
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

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"SELECT P.*, C.* FROM Products P
                                INNER JOIN Categories C
                                ON P.CategoryId = C.CategoryId";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();

                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Category = new Category
                            {
                                CategoryName = _reader["CategoryName"].ToString(),
                            },
                            ProductName = _reader["ProductName"].ToString(),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Price = Convert.ToDecimal(_reader["Price"])
                        });
                    }
                }
                _reader.Close();
                return products;
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

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

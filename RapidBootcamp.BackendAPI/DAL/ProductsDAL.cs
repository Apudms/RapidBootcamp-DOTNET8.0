using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class ProductsDAL : IProduct
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        #region Get Connection
        public ProductsDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Connstr");
            _connection = new SqlConnection(_connectionString);
        }
        #endregion

        #region Get All
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
        #endregion

        #region Get By ID
        public Product GetById(int id)
        {
            try
            {
                Product product = new Product();
                string query = @"SELECT * FROM Products
                                 WHERE ProductId = @ProductId
                                 ORDER BY ProductId ASC";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductId", id);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    product.ProductId = Convert.ToInt32(_reader["ProductId"]);
                    product.CategoryId = Convert.ToInt32(_reader["CategoryId"]);
                    product.ProductName = _reader["ProductName"].ToString();
                    product.Stock = Convert.ToInt32(_reader["Stock"]);
                    product.Price = Convert.ToDecimal(_reader["Price"]);
                    product.Category = new Category
                    {
                        CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                        CategoryName = (_reader["CategoryName"].ToString())
                    };
                }
                else
                {
                    throw new ArgumentException($"{id}");
                }
                _reader.Close();
                return product;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }
        #endregion

        #region Get By Name
        public IEnumerable<Product> GetByProductName(string productName)
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"SELECT * FROM ViewProductCategory
                                 WHERE ProductName LIKE @ProductName";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while(_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                            Category = new Category
                            {
                                CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                                CategoryName = (_reader["CategoryName"].ToString())
                            }
                        });
                    }
                }
                else
                {
                    throw new ArgumentException($"{productName}");
                }
                _reader.Close();
                return products;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }
        #endregion

        #region Get By Category ID
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            try
            {
                string query = @"SELECT * FROM Products
                                 WHERE CategoryId = @CategoryId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", categoryId);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<Product> products = new List<Product>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                        });
                    }
                }
                _reader.Close ();
                return products;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException (sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }
        #endregion

        #region Get By Category Name
        public IEnumerable<Product> GetByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get By Product with Category
        public IEnumerable<Product> GetProductsWithCategory()
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"SELECT * FROM ViewProductCategory
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
                _connection.Close();
                _command.Dispose();
            }
        }
        #endregion

        #region Add Product
        public Product Add(Product entity)
        {
            try
            {
                string query = @"INSERT INTO Products(CategoryId, ProductName, Stock, Price)
                                 VALUES(@CategoryId, @Stock, @Price); SELECT @@Identity";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                _command.Parameters.AddWithValue("@Stock", entity.Stock);
                _command.Parameters.AddWithValue("@Price", entity.Price);
                _connection.Open();
                entity.ProductId = Convert.ToInt32(_command.ExecuteScalar());
                return entity;
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
        #endregion

        #region Update Product
        public Product Update(Product entity)
        {
            try
            {
                string query = @"UPDATE Products SET ProductName = @ProductName,
                                 CategoryId = @CategoryId, Stock = @Stock,
                                 Price = @Price WHERE ProductId = @ProductId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _command.Parameters.AddWithValue("@Stock", entity.Stock);
                _command.Parameters.AddWithValue("@Price", entity.Price);
                _command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                _connection.Open();

                int result = _command.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ArgumentException("Data gagal diubah");
                }
                return entity;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }
        #endregion

        #region Delete Product
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
        #endregion
    }
}

using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;
using System.Transactions;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderDetailsDAL : IOrderDetail
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderDetailsDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnStr");
            _connection = new SqlConnection(_connectionString);
        }

        public OrderDetail Add(OrderDetail entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    string query = @"INSERT INTO OrderDetails(
                                        OrderHeaderId, 
                                        ProductId, 
                                        Quantity, 
                                        Price
                                     ) 
                                     VALUES(
                                        @OrderHeaderId, 
                                        @ProductId, 
                                        @Quantity, 
                                        @Price
                                     );
                                     SELECT @@identity";

                    _command = new SqlCommand(query, _connection);
                    _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                    _command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    _command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    _command.Parameters.AddWithValue("@Price", entity.Price);
                    _connection.Open();

                    int id = Convert.ToInt32(_command.ExecuteScalar());
                    entity.OrderDetailId = id;

                    // Update stock di Product
                    string queryUpdate = @"UPDATE Products SET Stock = Stock - @Quantity
                                           WHERE ProductId = @ProductId";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, _connection);
                    cmdUpdate.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    cmdUpdate.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    cmdUpdate.ExecuteNonQuery();
                    scope.Complete();
                    return entity;

                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
                catch (TransactionException tranEx)
                {
                    throw new ArgumentException(tranEx.Message);
                }
                finally
                {
                    _command.Dispose();
                    _connection.Close();
                    scope.Dispose();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId)
        {
            try
            {
                string query = @"SELECT * FROM ViewOrderDetail 
                                 WHERE OrderHeaderId=@OrderHeaderId
                                 ORDER BY ProductName ASC";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailId = Convert.ToInt32(_reader["OrderDetailId"]);
                        orderDetail.OrderHeaderId = _reader["OrderHeaderId"].ToString();
                        orderDetail.ProductId = Convert.ToInt32(_reader["ProductId"]);
                        orderDetail.Product = new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString()
                        };
                        orderDetail.Quantity = Convert.ToInt32(_reader["Quantity"]);
                        orderDetail.Price = Convert.ToDecimal(_reader["Price"]);
                        orderDetails.Add(orderDetail);
                    }
                }
                _reader.Close();
                return orderDetails;
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

        public decimal GetTotalAmount(string orderHeaderId)
        {
            try
            {
                string query = @"SELECT SUM(Price*Quantity) FROM OrderDetails 
                                 WHERE OrderHeaderId = @OrderHeaderId";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                _connection.Open();

                decimal totalAmount = Convert.ToDecimal(_command.ExecuteScalar());
                return totalAmount;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
        }

        public OrderDetail Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}

using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeadersDAL : IOrderHeader
    {
        private readonly IConfiguration _config;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderHeadersDAL(IConfiguration config) 
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnStr");
            _connection = new SqlConnection(_connectionString);
        }

        public OrderHeader Add(OrderHeader entity)
        {
            try
            {
                string query = @"INSERT INTO OrderHeaders(OrderHeaderId, CustomerId, ShippingId)
                                 VALUES(@OrderHeaderId, @CustomerId, @ShippingId);
                                 SELECT @@Identity";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                _command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                _command.Parameters.AddWithValue("@ShippingId", entity.ShippingId);
                _connection.Open();
                _command.ExecuteNonQuery();
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            try
            {
                List<OrderHeader> orderHeaders = new List<OrderHeader>();
                // Data Customer dibuat lengkap dari View DB
                string query = @"SELECT * FROM View_OrderHeader 
                                 ORDER BY OrderHeaderId DESC";

                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        orderHeaders.Add(new OrderHeader
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                            Customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(_reader["CustomerId"]),
                                CustomerName = _reader["CustomerName"].ToString(),
                                Address = _reader["Address"].ToString(),
                                City = _reader["City"].ToString(),
                                Email = _reader["Email"].ToString(),
                                PhoneNumber = _reader["PhoneNumber"].ToString(),
                            },
                            ShippingId = Convert.ToInt32(_reader["ShippingId"]),
                            ShippedBy = new Shipping
                            {
                                ShippingId = Convert.ToInt32(_reader["ShippingId"]),
                                ShippingName = _reader["ShippingName"].ToString()
                            },
                            OrderDate = Convert.ToDateTime(_reader["OrderDate"]),
                        });
                    }
                }
                _reader.Close();
                return orderHeaders;
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

        public OrderHeader GetById(int id)
        {
            try
            {
                OrderHeader orderHeader = new OrderHeader();
                string query = @"SELECT * FROM OrderHeaders
                                 WHERE OrderHeaderId = @OrderHeaderId
                                 ORDER BY OrderHeaderId ASC";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", id);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    orderHeader.OrderHeaderId = _reader["OrderHeaderId"].ToString();
                    orderHeader.CustomerId = Convert.ToInt32(_reader["CustomerId"]);
                    orderHeader.ShippingId = Convert.ToInt32(_reader["ShippingId"]);
                    orderHeader.OrderDate = Convert.ToDateTime(_reader["OrderDate"]);
                }
                else
                {
                    throw new ArgumentException($"Order Header dengan ID: {id} tidak ditemukan!");
                }
                _reader.Close();
                return orderHeader;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Dispose();
            }
        }

        public string GetOrderLastHeaderId()
        {
            string query = @"SELECT TOP 1 OrderHeaderId FROM OrderHeaders 
                             ORDER BY OrderHeaderId DESC";
            try
            {
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                var lastOrderHeaderId = _command.ExecuteScalar().ToString();
                if (lastOrderHeaderId == null)
                {
                    throw new ArgumentException("OrderHeaderId not found!");
                }
                return lastOrderHeaderId;
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

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}

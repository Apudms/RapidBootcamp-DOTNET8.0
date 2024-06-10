using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeaderDAL : IOrderHeaders
    {
        private readonly IConfiguration _config;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderHeaderDAL(IConfiguration config) 
        {
            _config = config;
            _connectionString = _config.GetConnectionString("ConnStr");
            _connection = new SqlConnection(_connectionString);
        }
        public OrderHeader Add(OrderHeader entity)
        {
            try
            {
                //List<OrderHeader> orderHeaders = new List<OrderHeader>();
                string query = @"INSERT INTO OrderHeaders(OrderHeaderId, CustomerId, TransactionDate, WalletId)
                                 VALUES(@OrderHeaderId, @CustomerId, @TransactionDate, @WalletId);
                                 SELECT @@Identity";

                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                _command.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                _command.Parameters.AddWithValue("@TransactionDate", entity.TransactionDate);
                _command.Parameters.AddWithValue("@WalletId", entity.WalletId);
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
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}

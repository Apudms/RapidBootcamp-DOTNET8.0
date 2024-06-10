using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersDAL : ICustomer
    {
        private IConfiguration _configuration;

        public CustomersDAL(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        #region Get Connection
        private string GetConStr()
        {
            return _configuration.GetConnectionString("ConnStr");
        }
        #endregion

        #region Add Customer
        public Customer Add(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"INSERT INTO Customers(CustomerName, CustomerAddress,
                                    CustomerCity, CustomerEmail, CustomerPhoneNumber) 
                                    VALUES(@CustomerName, @CustomerAddress, 
                                    @CustomerCity, @CustomerEmail, @CustomerPhoneNumber); 
                                    SELECT @@IDENTITY";

                    var param = new { 
                        CustomerName = entity.CustomerName,
                        CustomerAddress = entity.CustomerAddress,
                        CustomerCity = entity.CustomerCity,
                        CustomerEmail = entity.CustomerEmail,
                        CustomerPhoneNumber = entity.CustomerPhoneNumber
                    };

                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CustomerId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }
        #endregion

        #region Delete Customer
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"DELETE FROM Customers
                                 WHERE CustomerId = @CustomerId";

                var param = new { CustomerId = id };
                conn.Execute(query, param);
            }
        }
        #endregion

        #region Get All Customer
        public IEnumerable<Customer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                 ORDER BY CustomerName ASC";

                var customers = conn.Query<Customer>(query);
                return customers;
            }
        }
        #endregion

        #region Get Customer By City
        public IEnumerable<Customer> GetByCustomerCity(string customerCity)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                 WHERE CustomerCity LIKE @CustomerCity";

                var param = new { CustomerCity = "%" + customerCity + "%" };
                var customer = conn.Query<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return customer;
            }
        }
        #endregion

        #region Get Customer By Email
        public IEnumerable<Customer> GetByCustomerEmail(string customerEmail)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                 WHERE CustomerEmail LIKE @CustomerEmail";

                var param = new { CustomerEmail = "%" + customerEmail + "%" };
                var customer = conn.Query<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return customer;
            }
        }
        #endregion

        #region Get Customer By Name
        public IEnumerable<Customer> GetByCustomerName(string customerName)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                 WHERE CustomerName LIKE @CustomerName";

                var param = new { CustomerName = "%" + customerName + "%" };
                var customer = conn.Query<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return customer;
            }
        }
        #endregion

        #region Get Customer By ID
        public Customer GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                string query = @"SELECT * FROM Customers
                                 WHERE CustomerId = @CustomerId";

                var param = new { CustomerId = id };
                var customer = conn.QueryFirstOrDefault<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data tidak ditemukan");
                }
                return customer;
            }
        }
        #endregion

        #region Update Customer
        public Customer Update(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConStr()))
            {
                try
                {
                    string query = @"UPDATE Customers
                                     SET CustomerName = @CustomerName,
                                     CustomerAddress = @CustomerAddress,
                                     CustomerCity = @CustomerCity,
                                     CustomerEmail = @CustomerEmail,
                                     CustomerPhoneNumber = @CustomerPhoneNumber
                                     WHERE CustomerId = @CustomerId";

                    var param = new { 
                        CustomerName = entity.CustomerName,
                        CustomerAddress = entity.CustomerAddress,
                        CustomerCity = entity.CustomerCity,
                        CustomerEmail = entity.CustomerEmail,
                        CustomerPhoneNumber = entity.CustomerPhoneNumber, 
                        CustomerId = entity.CustomerId 
                    };
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

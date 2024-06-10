using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersEF : ICustomer
    {
        private readonly AppDbContext _dbContext;

        public CustomersEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public Customer Add(Customer entity)
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
                var result = _dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                if (result != null)
                {
                    _dbContext.Customers.Remove(result);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Customer not found!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        #endregion

        #region Get All
        public IEnumerable<Customer> GetAll()
        {
            var result = _dbContext.Customers.ToList();
            return result;
        }
        #endregion

        #region Get By City
        public IEnumerable<Customer> GetByCustomerCity(string customerCity)
        {
            var results = _dbContext.Customers.Where(c => c.CustomerCity.Contains(customerCity)).ToList();
            return results;
        }
        #endregion

        #region Get By Email
        public IEnumerable<Customer> GetByCustomerEmail(string customerEmail)
        {
            var results = _dbContext.Customers.Where(c => c.CustomerEmail.Contains(customerEmail)).ToList();
            return results;
        }
        #endregion

        #region Get By Name
        public IEnumerable<Customer> GetByCustomerName(string customerName)
        {
            var results = _dbContext.Customers.Where(c => c.CustomerName.Contains(customerName)).ToList();
            return results;
        }
        #endregion

        #region Get By ID
        public Customer GetById(int id)
        {
            var result = _dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Customer Not Found");
            }
            return result;
        }
        #endregion

        #region Update
        public Customer Update(Customer entity)
        {
            try
            {
                var updateCust = GetById(entity.CustomerId);
                if (updateCust != null)
                {
                    updateCust.CustomerName = entity.CustomerName;
                    updateCust.CustomerAddress = entity.CustomerAddress;
                    updateCust.CustomerCity = entity.CustomerCity;
                    updateCust.CustomerEmail = entity.CustomerEmail;
                    updateCust.CustomerPhoneNumber = entity.CustomerPhoneNumber;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Customer Not Found!");
                }
                return updateCust;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}

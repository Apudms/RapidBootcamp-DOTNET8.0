using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface ICustomer : ICrud<Customer>
    {
        IEnumerable<Customer> GetByCustomerName(string customerName);
        IEnumerable<Customer> GetByCustomerCity(string customerCity);
        IEnumerable<Customer> GetByCustomerEmail(string customerEmail);
    }
}

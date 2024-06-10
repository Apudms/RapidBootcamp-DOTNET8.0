namespace RapidBootcamp.BackendAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string CustomerCity { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;

        public IEnumerable<OrderHeader>? OrderHeaders { get; set; }

    }
}

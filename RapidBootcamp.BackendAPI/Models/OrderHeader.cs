namespace RapidBootcamp.BackendAPI.Models
{
    public class OrderHeader
    {
        public string OrderHeaderId { get; set; } = null!;
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public DateTime? OrderDate { get; set; }

        public Customer? Customer { get; set; }
        public Shipping? ShippedBy { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}

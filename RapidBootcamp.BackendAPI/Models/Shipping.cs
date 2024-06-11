namespace RapidBootcamp.BackendAPI.Models
{
    public class Shipping
    {
        public int ShippingId { get; set; }
        public string ShippingName { get; set; } = null!;

        public IEnumerable<OrderHeader>? OrderHeaders { get; set; }
    }
}

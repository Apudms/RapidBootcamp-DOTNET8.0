namespace RapidBootcamp.BackendAPI.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string OrderHeaderId { get; set; } = null!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderHeader? OrderHeader { get; set; }
        public Product? Product { get; set; }
    }
}

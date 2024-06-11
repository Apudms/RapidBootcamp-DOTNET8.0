namespace RapidBootcamp.BackendAPI.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; } = null!;
        public string OrderHeaderId { get; set; } = null!;
        public int WalletId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public OrderHeader? OrderHeader { get; set; }
        public Wallet? Wallet { get; set; }
    }
}

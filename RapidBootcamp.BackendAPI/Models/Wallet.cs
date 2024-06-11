using System.Transactions;

namespace RapidBootcamp.BackendAPI.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int CustomerId { get; set; }
        public string WalletName { get; set; } = null!;
        public decimal Credit { get; set; }

        public Customer? Customer { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}

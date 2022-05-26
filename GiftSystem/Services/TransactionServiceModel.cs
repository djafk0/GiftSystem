namespace GiftSystem.Services
{
    public class TransactionServiceModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string RecipientName { get; set; }

        public string SenderName { get; set; }

        public DateTime Date { get; set; }

        public bool IsPositive { get; set; }
    }
}

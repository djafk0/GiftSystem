namespace GiftSystem.Services
{
    using GiftSystem.DAL;
    using GiftSystem.Data.Models;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository repo;

        public TransactionService(ITransactionRepository repo)
            => this.repo = repo;

        public void SendMoney()
        {
            var transaction = new Transaction()
            {
                Amount = 20,
                Description = "asd",
                RecepientName = " asd",
                SenderName = "Asd"
            };

            this.repo.CreateTransaction(transaction);

            this.repo.Save();
        }
    }
}

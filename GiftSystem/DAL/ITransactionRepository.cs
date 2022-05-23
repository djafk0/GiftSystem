namespace GiftSystem.DAL
{
    using GiftSystem.Data.Models;

    public interface ITransactionRepository : IDisposable
    {
        IEnumerable<Transaction> GetTransactions();

        Transaction GetTransactionById(int transactionId);

        void CreateTransaction(Transaction transaction);

        void Save();
    }
}

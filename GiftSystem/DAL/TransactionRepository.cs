namespace GiftSystem.DAL
{
    using System.Collections.Generic;
    using GiftSystem.Data;
    using GiftSystem.Data.Models;

    public class TransactionRepository : ITransactionRepository
    {
        private GiftSystemDbContext context;

        private bool disposed = false;

        public TransactionRepository(GiftSystemDbContext context)
            => this.context = context;

        public IEnumerable<Transaction> GetTransactions()
        {
            return this.context.Transactions.ToList();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return this.context.Transactions.Find(transactionId);
        }

        public void CreateTransaction(Transaction transaction)
        {
            this.context.Add(transaction);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}

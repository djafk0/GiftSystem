namespace GiftSystem.Services
{
    using GiftSystem.DAL;
    using GiftSystem.Data.Models;
    using GiftSystem.Models;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactions;
        private readonly IUserRepository users;

        public TransactionService(ITransactionRepository transactions, IUserRepository users)
        {
            this.transactions = transactions;
            this.users = users;
        }

        public IEnumerable<TransactionServiceModel> AllTransacations(string userId)
        {
            var currentUserName = this.users.GetUserById(userId).Name;

            var transactions = this.transactions.GetTransactions()
                   .Where(t => t.SenderName == currentUserName ||
                       t.RecepientName == currentUserName)
                   .Select(t => new TransactionServiceModel
                   {
                       Id = t.Id,
                       Amount = t.Amount,
                       Description = t.Description,
                       SenderName = t.SenderName,
                       RecepientName = t.RecepientName,
                       Date = t.Date
                   })
                   .OrderByDescending(t => t.Id)
                   .ToList();

            return transactions;
        }

        public bool SendGift(TransactionFormModel model, string userId)
        {
            var user = this.users.GetUserById(userId);

            if (user.Credits < model.Amount)
            {
                return false;
            }

            var recepient = this.users.GetUserByPhoneNumber(model.PhoneNumber);

            recepient.Credits += model.Amount;

            user.Credits -= model.Amount;

            var transaction = new Transaction
            {
                Amount = model.Amount,
                Description = model.Description,
                RecepientName = recepient.Name,
                SenderName = user.Name,
                Date = DateTime.UtcNow,
            };

            this.transactions.CreateTransaction(transaction);

            this.transactions.Save();

            return true;
        }
    }
}

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
            
            var transactions = this.transactions
                    .GetTransactions()
                    .Select(t => new TransactionServiceModel
                    {
                        Id = t.Id,
                        Amount = t.Amount,
                        Description = t.Description,
                        SenderName = t.SenderName,
                        RecipientName = t.RecipientName,
                        Date = t.Date,
                        IsPositive = t.RecipientName == currentUserName
                    })
                    .OrderByDescending(t => t.Id)
                    .ToList();

            return transactions;
        }

        public IEnumerable<TransactionServiceModel> AllTransacationsByUser(string userId)
        {
            var currentUserName = this.users.GetUserById(userId).Name;

            var transactions = AllTransacations(userId)
                .Where(t => t.SenderName == currentUserName ||
                    t.RecipientName == currentUserName)
                .ToList();

            foreach (var transaction in transactions)
            {
                transaction.SenderName = currentUserName == transaction.SenderName 
                    ? string.Empty : transaction.SenderName;

                transaction.RecipientName = currentUserName == transaction.RecipientName
                    ? string.Empty : transaction.RecipientName;
            }

            return transactions;
        }

        public bool SendGift(TransactionFormModel model, string userId)
        {
            var currentUser = this.users.GetUserById(userId);

            var recipient = this.users.GetUserByPhoneNumber(model.PhoneNumber);

            if (currentUser.Credits < model.Amount || currentUser == recipient || recipient == null)
            {
                return false;
            }

            recipient.Credits += model.Amount;

            currentUser.Credits -= model.Amount;

            var transaction = new Transaction
            {
                Amount = model.Amount,
                Description = model.Description,
                RecipientName = recipient.Name,
                SenderName = currentUser.Name,
                Date = DateTime.UtcNow.ToLocalTime(),
            };

            this.transactions.CreateTransaction(transaction);

            this.transactions.Save();

            return true;
        }
    }
}

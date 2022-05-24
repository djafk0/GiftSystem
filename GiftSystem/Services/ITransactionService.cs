namespace GiftSystem.Services
{
    using GiftSystem.Models;

    public interface ITransactionService
    {
        IEnumerable<TransactionServiceModel> AllTransacationsByUser(string userId);

        IEnumerable<TransactionServiceModel> AllTransacations(string userId);

        bool SendGift(TransactionFormModel transaction, string userId);
    }
}

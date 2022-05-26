namespace GiftSystem.Areas.Admin.Controllers
{
    using GiftSystem.Infrastructure;
    using GiftSystem.Services;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdminController
    {
        private readonly ITransactionService transactions;
        private readonly IUserService users;

        public DashboardController(ITransactionService transactions, IUserService users)
        {
            this.transactions = transactions;
            this.users = users;
        }

        public IActionResult Transactions()
        {
            var userId = this.User.Id();

            var transactions = this.transactions.AllTransacations(userId);

            return View(transactions);
        }

        public IActionResult Users(string id = null)
        {
            var users = this.users.GetUsers(id);

            if (id != null)
            {
                return Json(users.FirstOrDefault());
            }

            return View(users);
        }
    }
}

namespace GiftSystem.Areas.Admin.Controllers
{
    using System.Security.Claims;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var transactions = this.transactions.AllTransacations(userId);

            return View(transactions);
        }

        public IActionResult Users()
        {
            var users = this.users.GetUsers();

            return View(users);
        }
    }
}

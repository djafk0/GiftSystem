namespace GiftSystem.Areas.Admin.Controllers
{
    using GiftSystem.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class DashboardController : AdminController
    {
        private readonly ITransactionService transactions;

        public DashboardController(ITransactionService transactions)
            => this.transactions = transactions;

        public IActionResult All()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var transactions = this.transactions.AllTransacations(userId);

            return View(transactions);
        }
    }
}

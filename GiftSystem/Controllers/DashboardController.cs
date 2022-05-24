namespace GiftSystem.Controllers
{
    using GiftSystem.Services;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : Controller
    {
        private readonly ITransactionService transactions;

        public DashboardController(ITransactionService transactions)
            => this.transactions = transactions;

        public IActionResult Give()
        {
            this.transactions.SendMoney();

            return RedirectToAction("Index", "Home");
        }
    }
}

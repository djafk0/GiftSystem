namespace GiftSystem.Controllers
{
    using GiftSystem.Infrastructure;
    using GiftSystem.Models;
    using GiftSystem.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ITransactionService transactions;

        public DashboardController(ITransactionService transactions)
            => this.transactions = transactions;

        public IActionResult All()
        {
            var userId = this.User.Id();

            var transactions = this.transactions.AllTransacationsByUser(userId);

            return View(transactions);
        }

        [HttpPost]
        public IActionResult Send(TransactionFormModel transaction)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = this.User.Id();

            var isSent = this.transactions.SendGift(transaction, userId);

            if (!isSent)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

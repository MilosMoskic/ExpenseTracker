using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseTracker.Interfaces;
using ExpenseTracker.ServInterfaces;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;

        public TransactionController(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var titleWithCategory = _transactionService.ListAllTransactions();
            return View(titleWithCategory);
        }

        public IActionResult AddOrEdit(int id=0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new Transaction());
            else
                return View(_transactionService.FindTransactionById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,CategoryId,Amount,Note,Date,AppUserID")] Transaction transaction)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (transaction.TransactionId == 0) 
            {
                transaction.AppUserID = userId;
                _transactionService.CreateTransaction(transaction);
            }
            else
            {
                transaction.AppUserID = userId;
                _transactionService.UpdateTransaction(transaction);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_transactionService.TransactionExists(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transaction = _transactionService.FindTransactionById(id);
            if (_transactionService.TransactionExists(id) != null)
            {
                _transactionService.DeleteTransaction(transaction);
            }
            
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _categoryService.ListAllCategories();
            Category DefaultCategory = new Category() { CategoryId = 0, Title = "Choose a category" };
            CategoryCollection.Add(DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }
    }
}

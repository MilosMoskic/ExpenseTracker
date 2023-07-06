using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseTracker.Interfaces;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TransactionController(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var titleWithCategory = _transactionRepository.ListAllTransactions();
            return View(titleWithCategory);
        }

        public IActionResult AddOrEdit(int id=0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new Transaction());
            else
                return View(_transactionRepository.FindTransaction(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,CategoryId,Amount,Note,Date,AppUserID")] Transaction transaction)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (transaction.TransactionId == 0) 
            {
                transaction.AppUserID = userId;
                _transactionRepository.CreateTransaction(transaction);
            }
            else
            {
                transaction.AppUserID = userId;
                _transactionRepository.UpdateTransaction(transaction);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_transactionRepository.TransactionExists(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transaction = _transactionRepository.FindTransaction(id);
            if (_transactionRepository.TransactionExists(id) != null)
            {
                _transactionRepository.DeleteTransaction(transaction);
            }
            
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _categoryRepository.ListAllCategories();
            Category DefaultCategory = new Category() { CategoryId = 0, Title = "Choose a category" };
            CategoryCollection.Add(DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }
    }
}

using ExpenseTracker.Data;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AuthContext _context;

        public TransactionRepository(AuthContext context)
        {
            _context = context;
        }

        public int CalculateTotalIncome(string appUserId)
        {
            List<Transaction> SelectedTransactions = TransactionsForDashboard(appUserId);
            return SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
        }

        public int CalculateTotalExpense(string appUserId)
        {
            List<Transaction> SelectedTransactions = TransactionsForDashboard(appUserId);
            return SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
        }

        public bool CreateTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            return Save();
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            _context.Remove(transaction);
            return Save();
        }

        public Transaction FindTransaction(int id)
        {
            return _context.Transaction.Where(c => c.TransactionId == id).FirstOrDefault();
        }

        public ICollection<Transaction> ListAllTransactions()
        {
            return _context.Transaction.Include(t => t.Category).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExists(int id)
        {
            return _context.Transaction.Any(t => t.TransactionId == id);
        }

        public List<Transaction> TransactionsForDashboard(string appUserId)
        {
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;
            return _context.Transaction.Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate && y.AppUserID == appUserId)
                .ToList();
        }


        public bool UpdateTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            return Save();
        }
    }
}

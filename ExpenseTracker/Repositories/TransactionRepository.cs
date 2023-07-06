using ExpenseTracker.Data;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AuthContext _context;

        public TransactionRepository(AuthContext context)
        {
            _context = context;
        }
        public Transaction FindTransaction(int id)
        {
            return _context.Transaction.Where(c => c.TransactionId == id).FirstOrDefault();
        }

        public ICollection<Transaction> ListAllTransactions()
        {
            return _context.Transaction.OrderBy(c => c.Date).ToList();
        }
    }
}

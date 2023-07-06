using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    public interface ITransactionRepository
    {
        public Transaction FindTransaction(int id);
        public ICollection<Transaction> ListAllTransactions();
    }
}

using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction FindTransaction(int id);
        ICollection<Transaction> ListAllTransactions();
        bool TransactionExists(int id);
        bool CreateTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(Transaction transaction);
        bool Save();
    }
}

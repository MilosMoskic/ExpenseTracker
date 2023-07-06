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
        List<Transaction> TransactionsForDashboard(string appUserId);
        int CalculateTotalIncome(string appUserId);
        int CalculateTotalExpense(string appUserId);
        bool Save();
    }
}

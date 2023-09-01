using ExpenseTracker.Models;

namespace ExpenseTracker.ServInterfaces
{
    public interface ITransactionService
    {
        Transaction FindTransactionById(int id);
        ICollection<Transaction> ListAllTransactions();
        bool CreateTransaction(Transaction transaction);
        bool DeleteTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool TransactionExists(int id);
        int CalculateTotalIncome(string appUserId);
        int CalculateTotalExpense(string appUserId);
        List<Transaction> TransactionsForDashboard(string appUserId);
    }
}

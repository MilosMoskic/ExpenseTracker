using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using ExpenseTracker.ServInterfaces;

namespace ExpenseTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction FindTransactionById(int id)
        {
            return _transactionRepository.FindTransaction(id);
        }
        public ICollection<Transaction> ListAllTransactions()
        {
            return _transactionRepository.ListAllTransactions();
        }
        public bool CreateTransaction(Transaction transaction)
        {
            return _transactionRepository.CreateTransaction(transaction);
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            return _transactionRepository.DeleteTransaction(transaction);
        }
        public bool UpdateTransaction(Transaction transaction)
        {
            return _transactionRepository.UpdateTransaction(transaction);
        }
        public bool TransactionExists(int id)
        {
            return _transactionRepository.TransactionExists(id);
        }
        public int CalculateTotalIncome(string appUserId)
        {
            return _transactionRepository.CalculateTotalIncome(appUserId);
        }
        public int CalculateTotalExpense(string appUserId)
        {
            return _transactionRepository.CalculateTotalExpense(appUserId);
        }
        public List<Transaction> TransactionsForDashboard(string appUserId)
        {
            return _transactionRepository.TransactionsForDashboard(appUserId);
        }
    }
}

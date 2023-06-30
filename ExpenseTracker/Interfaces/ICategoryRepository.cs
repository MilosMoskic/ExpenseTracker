using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    public interface ICategoryRepository
    {
        public Category FindCategory(int id);
    }
}

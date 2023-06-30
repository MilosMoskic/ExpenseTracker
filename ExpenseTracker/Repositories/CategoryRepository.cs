using ExpenseTracker.Data;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AuthContext _context;

        public CategoryRepository(AuthContext context)
        {
            _context = context;
        }

        public Category FindCategory(int id)
        {
            return _context.Category.Where(c => c.CategoryId == id).FirstOrDefault();
        }
    }
}

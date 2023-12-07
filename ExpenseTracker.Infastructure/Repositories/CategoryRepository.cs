using ExpenseTracker.Context;
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

        public bool CategoryExists(int id)
        {
            return _context.Category.Any(c => c.CategoryId== id);
        }

        public bool CreateCageory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public Category FindCategory(int id)
        {
            return _context.Category.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public ICollection<Category> ListAllCategories()
        {
            return _context.Category.OrderBy(c => c.CategoryId).ToList();
        }

        public ICollection<Category> FilterCategoriesByIncome()
        {
            return _context.Category.Where(c => c.Type == "Income").ToList();
        }

        public ICollection<Category> FilterCategoriesByExpense()
        {
            return _context.Category.Where(c => c.Type == "Expense").ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}

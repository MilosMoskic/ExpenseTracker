using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    public interface ICategoryRepository
    {
        Category FindCategory(int id);
        ICollection<Category> ListAllCategories();
        bool CategoryExists(int id);
        bool CreateCageory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}

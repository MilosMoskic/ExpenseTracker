using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    public interface ICategoryRepository
    {
        Category FindCategory(int id);
        ICollection<Category> ListAllCategories();
        ICollection<Category> FilterCategoriesByIncome();
        ICollection<Category> FilterCategoriesByExpense();
        bool CategoryExists(int id);
        bool CreateCageory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}

using ExpenseTracker.Models;

namespace ExpenseTracker.ServInterfaces
{
    public interface ICategoryService
    {
        ICollection<Category> ListAllCategories();
        Category GetCategoryById(int id);
        bool CreateCategory(Category category);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category category);
        bool CategoryExists(int id);
    }
}
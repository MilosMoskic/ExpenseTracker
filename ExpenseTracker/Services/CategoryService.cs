using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using ExpenseTracker.ServInterfaces;

namespace ExpenseTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICollection<Category> ListAllCategories()
        {
            return _categoryRepository.ListAllCategories();
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.FindCategory(id);
        }
        public bool CreateCategory(Category category)
        {
            return _categoryRepository.CreateCageory(category);
        }
        public ICollection<Category> FilteredCategoriesByIncome()
        {
            return _categoryRepository.FilterCategoriesByIncome();
        }

        public ICollection<Category> FilteredCategoriesByExpense()
        {
            return _categoryRepository.FilterCategoriesByExpense();
        }
        public bool DeleteCategory(int id)
        {
            var categoryToDelete = _categoryRepository.FindCategory(id);
            return _categoryRepository.DeleteCategory(categoryToDelete);
        }
        public bool UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
        public bool CategoryExists(int id)
        {
            return _categoryRepository.CategoryExists(id);
        }
    }
}

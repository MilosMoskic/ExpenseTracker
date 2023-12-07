using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.ServInterfaces;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
              return View(_categoryService.ListAllCategories());
        }

        public IActionResult FilteredCategoriesByIncome()
        {
            return View(_categoryService.FilteredCategoriesByIncome());
        }

        public IActionResult FilteredCategoriesByExpense()
        {
            return View(_categoryService.FilteredCategoriesByExpense());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Category());
            else
                return View(_categoryService.GetCategoryById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                    _categoryService.CreateCategory(category);
                else
                    _categoryService.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_categoryService.CategoryExists(id) == false)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }

            if (_categoryService.CategoryExists(id) != false)
            {
                _categoryService.DeleteCategory(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

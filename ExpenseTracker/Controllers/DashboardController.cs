using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AuthContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(AuthContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            //Last 7 days
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Models.Transaction> SelectedTransactions = await _context.Transaction
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate && y.AppUserID == userId)
                .ToListAsync();

            //Total Income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //Total Expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //Balance
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0");

            return View();
        }
    }
}

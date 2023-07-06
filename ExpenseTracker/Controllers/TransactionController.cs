﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly AuthContext _context;

        public TransactionController(ITransactionRepository transactionRepository, AuthContext context)
        {
            _transactionRepository = transactionRepository;
            _context = context;
        }

        // GET: Transaction
        public IActionResult Index()
        {
            return View(_transactionRepository.ListAllTransactions());
        }

        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new Transaction());
            else
                return View(_transactionRepository.FindTransaction(id));
        }

        // POST: Transaction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,CategoryId,Amount,Note,Date,AppUserID")] Transaction transaction)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (transaction.TransactionId == 0) 
            {
                transaction.AppUserID = userId;
                _context.Add(transaction);
            }
            else
            {
                transaction.AppUserID = userId;
                _context.Update(transaction);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            PopulateCategories();
            return View(transaction);
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transaction == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _context.Category.ToList();
            Category DefaultCategory = new Category() { CategoryId = 0, Title = "Choose a category" };
            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }
    }
}

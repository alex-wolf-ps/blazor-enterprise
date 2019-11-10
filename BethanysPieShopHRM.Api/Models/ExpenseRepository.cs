using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class ExpenseRepository : IExpenseRepository
    {
        private AppDbContext _appDbContext;

        public ExpenseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _appDbContext.Expenses.Include(x => x.Currency);
        }

        public Expense GetExpenseById(int id)
        {
            return _appDbContext.Expenses.FirstOrDefault(x => x.ExpenseId == id);
        }

        public Expense AddExpense(Expense expense)
        {
            var addedEntity = _appDbContext.Expenses.Add(expense);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
    }
}

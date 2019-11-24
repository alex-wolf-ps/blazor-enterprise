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

        public Expense UpdateExpense(Expense expense)
        {
            var foundExpense = _appDbContext.Expenses.FirstOrDefault(e => e.ExpenseId == expense.ExpenseId);

            if (foundExpense != null)
            {
                foundExpense.Amount = expense.Amount;
                foundExpense.CoveredAmount = expense.CoveredAmount;
                foundExpense.CurrencyId = expense.CurrencyId;
                foundExpense.EmployeeId = expense.EmployeeId;
                foundExpense.Description = expense.Description;
                foundExpense.Title = expense.Title;
                foundExpense.Status = expense.Status;
                foundExpense.Date = expense.Date;
                foundExpense.ExpenseType = expense.ExpenseType;

                _appDbContext.SaveChanges();

                return foundExpense;
            }

            return null;
        }
    }
}

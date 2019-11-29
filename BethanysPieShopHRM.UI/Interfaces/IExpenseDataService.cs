using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{ 
    public interface IExpenseDataService
    {
        public Task<IEnumerable<Expense>> GetAllExpenses();
        public Task<Expense> GetExpenseById(int id);
        public Task<Expense> AddExpense(Expense editExpense);
        public Task UpdateExpense(Expense editExpense);
    }
}

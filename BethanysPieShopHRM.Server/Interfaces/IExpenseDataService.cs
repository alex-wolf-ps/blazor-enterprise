using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{ 
    public interface IExpenseDataService
    {
        public Task<IEnumerable<Expense>> GetAllExpenses();
        public Task<Expense> GetExpenseById(int id);
        public Task<IEnumerable<Currency>> GetAllCurrencies();
        public Task<Expense> EditExpense(Expense editExpense);
    }
}

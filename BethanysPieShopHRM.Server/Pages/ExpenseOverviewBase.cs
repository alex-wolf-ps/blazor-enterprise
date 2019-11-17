using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BethanysPieShopHRM.Server.Components;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Pages
{
    public class ExpenseOverviewBase: ComponentBase
    {
        [Inject]
        public IExpenseDataService ExpenseService { get; set; }

        public List<Expense> Expenses { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Expenses = (await ExpenseService.GetAllExpenses()).ToList();
        }
    }
}

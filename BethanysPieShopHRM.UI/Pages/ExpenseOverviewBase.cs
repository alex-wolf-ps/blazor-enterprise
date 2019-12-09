using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BethanysPieShopHRM.UI.Components;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Blazor.FlexGrid.DataAdapters;

namespace BethanysPieShopHRM.UI.Pages
{
    public class ExpenseOverviewBase: ComponentBase
    {
        [Inject]
        public IExpenseDataService ExpenseService { get; set; }

        public CollectionTableDataAdapter<Expense> Expenses { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var data = (await ExpenseService.GetAllExpenses()).ToList();
            Expenses = new CollectionTableDataAdapter<Expense>(data);
        }
    }
}

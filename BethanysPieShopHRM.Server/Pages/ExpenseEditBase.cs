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
    public class ExpenseEditBase : ComponentBase
    {
        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Expense Expense { get; set; } = new Expense();

        [Parameter]
        public int ExpenseId { get; set; }

        public bool Saved = false;

        public string Message { get; set; }


        protected async Task HandleValidSubmit()
        {
            await ExpenseService.EditExpense(Expense);
            Message = "Saved!";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}

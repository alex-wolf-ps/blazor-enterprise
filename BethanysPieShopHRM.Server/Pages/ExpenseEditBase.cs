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
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Expense Expense { get; set; } = new Expense();

        //needed to bind to select to value
        protected string CurrencyId = "1";
        protected string EmployeeId = "1";

        [Parameter]
        public int ExpenseId { get; set; }

        public bool Saved = false;

        public string Message { get; set; }

        public List<Currency> Currencies { get; set; } = new List<Currency>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();

            Currencies = (await ExpenseService.GetAllCurrencies()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            Expense.EmployeeId = int.Parse(EmployeeId);
            Expense.CurrencyId = int.Parse(CurrencyId);

            // Start with assumption it's approved since Manager is entering
            Expense.Status = ExpenseStatus.Approved;

            var employee = await EmployeeDataService.GetEmployeeDetails(Expense.EmployeeId);

            Expense.Amount *= Expense.Currency.USExchange;

            if (employee.IsOPEX)
            {
                switch (Expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                        Expense.Status = ExpenseStatus.Denied;
                        break;
                    case ExpenseType.Transportation:
                        Expense.Status = ExpenseStatus.Denied;
                        break;
                    case ExpenseType.Hotel:
                        Expense.Status = ExpenseStatus.Denied;
                        break;
                }

                if (Expense.Status != ExpenseStatus.Denied)
                {
                    Expense.CoveredAmount = Expense.Amount / 2;
                }
            }

            if (employee.IsFTE)
            {
                if (Expense.ExpenseType != ExpenseType.Training)
                {
                    Expense.Status = ExpenseStatus.Denied;
                }
            }

            if (Expense.ExpenseType == ExpenseType.Food && Expense.Amount > 100)
            {
                Expense.Status = ExpenseStatus.Pending;
            }

            if (Expense.Amount > 5000)
            {
                Expense.Status = ExpenseStatus.Pending;
            }

            if(Expense.Status != ExpenseStatus.Denied)
            {
                await ExpenseService.EditExpense(Expense);
                Message = "Saved!";
                Saved = true;
            } 
            else
            {
                Message = "Expense denied.";
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}

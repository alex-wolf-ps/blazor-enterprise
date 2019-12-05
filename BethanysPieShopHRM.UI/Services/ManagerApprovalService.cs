using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class ManagerApprovalService : IExpenseApprovalService
    {
        private readonly IEmployeeDataService _employeeService;

        public ManagerApprovalService(IEmployeeDataService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<ExpenseStatus> GetExpenseStatus(Expense expense)
        {
            var employee = await _employeeService.GetEmployeeDetails(expense.EmployeeId);

            // New sample approval scenarios
            if (employee.IsFTE)
            {
                if (expense.Amount < 250)
                {
                    switch (expense.ExpenseType)
                    {
                        case ExpenseType.Training:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Food:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Office:
                            return ExpenseStatus.Approved;
                    }
                }

                if (employee.JobCategory.JobCategoryName == "Sales" && expense.Amount < 500)
                {
                    switch (expense.ExpenseType)
                    {
                        case ExpenseType.Transportation:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Travel:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Hotel:
                            return ExpenseStatus.Approved;
                    }
                }
            }
            
            return ExpenseStatus.Pending;
        }
    }
}

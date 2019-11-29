using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class ExpenseApprovalService : IExpenseApprovalService
    {
        public ExpenseStatus GetExpenseStatus(Expense expense, Employee employee)
        {
            if (!employee.IsFTE)
            {
                switch (expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Hotel:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Travel:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Food:
                        return ExpenseStatus.Denied;
                }
            }
            else
            {
                if (expense.ExpenseType == ExpenseType.Food && expense.Amount > 250)
                {
                    return ExpenseStatus.Denied;
                }

                if (expense.Amount > 5000)
                {
                    return ExpenseStatus.Denied;
                }
            }

            if (employee.JobCategory.JobCategoryName == "Sales" && expense.ExpenseType == ExpenseType.Gift)
            {
                return ExpenseStatus.Denied;
            }

            if (employee.IsOPEX)
            {
                switch (expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Training:
                        return ExpenseStatus.Denied;
                }
            }

            return ExpenseStatus.Pending;
        }
    }
}

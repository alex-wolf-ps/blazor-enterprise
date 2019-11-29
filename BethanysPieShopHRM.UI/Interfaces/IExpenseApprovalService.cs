using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface IExpenseApprovalService
    {
        ExpenseStatus GetExpenseStatus(Expense expense, Employee employee);
    }
}
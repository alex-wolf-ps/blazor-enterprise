using BethanysPieShopHRM.Shared;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public interface IExpenseApprovalService
    {
        Task<ExpenseStatus> GetExpenseStatus(Expense expense);
    }
}
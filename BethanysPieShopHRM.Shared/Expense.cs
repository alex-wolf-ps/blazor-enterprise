using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EmployeeName { get; set; }
        public double Amount { get; set; }
        public double CoveredAmount { get; set; }
        public ExpenseType ExpenseType {get; set; }
        public ExpenseStatus Status { get; set; }
        public DateTime? Date { get; set; }
        public int CurrencyId { get; set; }
        public int EmployeeId { get; set; }

        public Currency Currency { get; set; }

        public Employee Employee { get; set; }
    }
}

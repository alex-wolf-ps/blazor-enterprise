using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }
        public double CoveredAmount { get; set; }

        [Required]
        public ExpenseType ExpenseType {get; set; }
        public ExpenseStatus Status { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Currency Currency { get; set; }

        public Employee Employee { get; set; }
    }
}

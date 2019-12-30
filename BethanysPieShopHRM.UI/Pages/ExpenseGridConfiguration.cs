using BethanysPieShopHRM.Shared;
using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Components.Configuration.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Pages
{
    public class ExpenseGridConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Title)
                .IsSortable();

            builder.Property(e => e.ExpenseType)
                .IsSortable();

            builder.Property(e => e.Amount)
                .IsSortable();

            builder.Property(e => e.EmployeeId).IsVisible(false);
            builder.Property(e => e.CurrencyId).IsVisible(false);
            builder.Property(e => e.Employee).IsVisible(false);
            builder.Property(e => e.Description).IsVisible(false);
            builder.Property(e => e.CoveredAmount).IsVisible(false);

            // Just use this unused column for our edit buttons
            builder.Property(e => e.Currency).HasCaption(" ");
        }
    }
}

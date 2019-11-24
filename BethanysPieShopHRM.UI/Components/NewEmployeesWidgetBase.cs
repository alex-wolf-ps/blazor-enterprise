using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Components
{
    public class NewEmployeesWidgetBase : ComponentBase
    {
        public List<Employee> NewEmployees { get; set; } = new List<Employee>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NewEmployees = (await EmployeeDataService.GetAllEmployees()).OrderBy(x => x.JoinedDate).Take(3).ToList();
        }
    }
}

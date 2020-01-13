using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class JobDetailBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }

        [Parameter]
        public int Id { get; set; }
       
        public Job Job { get; set; } = new Job();

        protected override async Task OnInitializedAsync()
        {
            Job = await JobDataService.GetJobById(Id);
        }
    }
}

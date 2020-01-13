using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BethanysPieShopHRM.UI.Components;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class JobEditBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Job Job { get; set; } = new Job();

        [Parameter]
        public int JobId { get; set; }
        public string Message { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            if(JobId != 0)
            {
                Job = await JobDataService.GetJobById(JobId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Job.Id== 0) // New 
            {
                await JobDataService.AddJob(Job);
            } 
            else
            {
                await JobDataService.UpdateJob(Job);
            }

            NavigationManager.NavigateTo("/jobs");
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/jobs");
        }
    }
}

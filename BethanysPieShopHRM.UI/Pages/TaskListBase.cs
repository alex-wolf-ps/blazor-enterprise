using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Pages
{
    public class TaskListBase : ComponentBase
    {
        [Inject]
        public ITaskDataService taskService { get; set; }

        [Inject]
        public NavigationManager navManager { get; set; }

        [Parameter]
        public int Count { get; set; }

        public List<HRTask> Tasks { get; set; } = new List<HRTask>();

        protected override async Task OnInitializedAsync()
        {
            Tasks = (await taskService.GetAllTasks()).ToList();

            if (Count != 0)
            {
                Tasks = Tasks.Take(Count).ToList();
            }
        }

        public void AddTask()
        {
            navManager.NavigateTo("taskedit");
        }

    }
}

using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class JobsDataService : IJobDataService
    {
        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return new List<Job>();
        }

        public async Task<Job> GetJobById(int jobId)
        {
            return new Job();
        }

        public async Task AddJob(Job newJob)
        {
        }

        public async Task UpdateJob(Job updatedJob)
        {
        }

        public async Task DeleteJob(int jobId)
        {
        }
    }
}

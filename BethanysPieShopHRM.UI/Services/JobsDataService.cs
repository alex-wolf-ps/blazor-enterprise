using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class JobsDataService : IJobsDataService
    {

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return null;
        }

        public async Task<Employee> GetJobDetails(int jobId)
        {
            return null;
        }

        public async Task<Employee> AddJob(Job newJob)
        {
            return null;
        }

        public async Task UpdateJob(Job job)
        {

        }

        public async Task DeleteJob(int jobId)
        {
        }
    }
}

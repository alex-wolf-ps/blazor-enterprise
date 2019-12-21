using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface IJobDataService
    {
        Task<Job> AddJob(Job newJob);
        Task DeleteJob(int jobId);
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobDetails(int jobId);
        Task UpdateJob(Job job);
    }
}
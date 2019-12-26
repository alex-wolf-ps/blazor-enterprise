using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface IJobDataService
    {
        Task AddJob(Job newJob);
        Task DeleteJob(int jobId);
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int jobId);
        Task UpdateJob(Job job);
    }
}
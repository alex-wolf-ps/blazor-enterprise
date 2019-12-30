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
        private HttpClient _client;

        public JobsDataService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _client.GetJsonAsync<Job[]>("jobs");
        }

        public async Task<Job> GetJobById(int jobId)
        {
            return await _client.GetJsonAsync<Job>($"jobs/{jobId}");
        }

        public async Task AddJob(Job newJob)
        {
            // Commented code can be used for final clip!

            //var dictionary = newJob.GetType().GetProperties()
            //    .ToDictionary(p => p.Name, p => p.GetValue(newJob).ToString());

            //var requestMessage = new HttpRequestMessage()
            //{
            //    Method = new HttpMethod("POST"),
            //    RequestUri = new Uri("https://localhost:5001/jobs"),
            //    Content = new FormUrlEncodedContent(dictionary)
            //};

            //requestMessage.Headers.Add("x-custom", "secretCode");

            await _client.PostJsonAsync("jobs", newJob);
        }

        public async Task UpdateJob(Job updatedJob)
        {
            await _client.PutJsonAsync("jobs", updatedJob);
        }

        public async Task DeleteJob(int jobId)
        {
        }
    }
}

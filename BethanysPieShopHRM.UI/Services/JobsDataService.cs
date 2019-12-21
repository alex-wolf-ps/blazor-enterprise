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
    public class JobsDataService : IJobDataService, IRecruitingAPI
    {
        private HttpClient _httpClient;

        public JobsDataService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {

            return await _httpClient.GetJsonAsync<Job[]>("jobs");
        }

        public async Task<Job> GetJobDetails(int jobId)
        {
            return null;
        }

        public async Task<Job> AddJob(Job newJob)
        {
            var dictionary = newJob.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(newJob).ToString());

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri("https://localhost:44323/jobs"),
                Content = new FormUrlEncodedContent(dictionary)
            };

            requestMessage.Headers.Add("x-custom", "secret code");

            var response = await _httpClient.SendAsync(requestMessage);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Job>(responseBody);
        }

        public async Task UpdateJob(Job job)
        {

        }

        public async Task DeleteJob(int jobId)
        {
        }
    }
}

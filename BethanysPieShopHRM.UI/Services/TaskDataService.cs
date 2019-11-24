using BethanysPieShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class TaskDataService : ITaskDataService
    {
        private readonly HttpClient _httpClient;

        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HRTask> AddTask(HRTask task)
        {
            var taskJson =
                new StringContent(JsonSerializer.Serialize(task), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/task", taskJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<HRTask>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<IEnumerable<HRTask>> GetAllTasks()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<HRTask>>
                (await _httpClient.GetStreamAsync($"api/Task"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<HRTask> GetTaskById(int taskId)
        {
            return await JsonSerializer.DeserializeAsync<HRTask>
                (await _httpClient.GetStreamAsync($"api/Task/{taskId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

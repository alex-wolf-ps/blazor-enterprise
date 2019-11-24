using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Data
{
    public class SurveyDataService : ISurveyDataService
    {
        private readonly HttpClient _httpClient;

        public SurveyDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Answer> AddAnswer(Answer answer)
        {
            var answerJson =
                new StringContent(JsonSerializer.Serialize(answer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/answer", answerJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Answer>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<Survey> AddSurvey(Survey survey)
        {
            var surveyJson =
                new StringContent(JsonSerializer.Serialize(survey), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/survey", surveyJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Survey>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveys()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Survey>>
                (await _httpClient.GetStreamAsync($"api/Survey"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Survey> GetSurveyById(int surveyId)
        {
            return await JsonSerializer.DeserializeAsync<Survey>
                (await _httpClient.GetStreamAsync($"api/Survey/{surveyId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

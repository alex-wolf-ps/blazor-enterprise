using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public class ExpenseDataService : IExpenseDataService
    {
        private readonly HttpClient _httpClient;

        public ExpenseDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Expense> AddExpense(Expense editExpense)
        {
            var expenseJson =
                new StringContent(JsonSerializer.Serialize(editExpense), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/expense", expenseJson);

            if (response.IsSuccessStatusCode)
            {
                await JsonSerializer.DeserializeAsync<Expense>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateExpense(Expense expense)
        {
            var expenseJson =
                new StringContent(JsonSerializer.Serialize(expense), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/expense", expenseJson);
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Expense>>
                (await _httpClient.GetStreamAsync($"api/expense"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Expense> GetExpenseById(int expenseId)
        {
            return await JsonSerializer.DeserializeAsync<Expense>
                (await _httpClient.GetStreamAsync($"api/expense/{expenseId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

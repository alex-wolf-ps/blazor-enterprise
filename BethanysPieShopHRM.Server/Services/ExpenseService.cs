using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _httpClient;

        public ExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

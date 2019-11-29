using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface ICurrencyDataService
    {
        Task<IEnumerable<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrencyById(int currencyId);
    }
}
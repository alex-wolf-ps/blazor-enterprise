using BethanysPieShopHRM.Shared;
using System.Collections.Generic;

namespace BethanysPieShopHRM.Api.Models
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencys();

        Currency GetCurrencyById(int id);

        Currency AddCurrency(Currency Currency);
    }
}
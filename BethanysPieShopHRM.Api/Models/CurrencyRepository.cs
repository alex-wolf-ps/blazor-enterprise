using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private AppDbContext _appDbContext;

        public CurrencyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Currency> GetAllCurrencys()
        {
            return _appDbContext.Currencies;
        }

        public Currency GetCurrencyById(int id)
        {
            return _appDbContext.Currencies.FirstOrDefault(x => x.CurrencyId == id);
        }

        public Currency AddCurrency(Currency Currency)
        {
            var addedEntity = _appDbContext.Currencies.Add(Currency);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
    }
}

using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyRepository _CurrencyRepository;

        public CurrencyController(ICurrencyRepository CurrencyRepository)
        {
            _CurrencyRepository = CurrencyRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCurrencys()
        {
            return Ok(_CurrencyRepository.GetAllCurrencys());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCurrencyById(int id)
        {
            return Ok(_CurrencyRepository.GetCurrencyById(id));
        }

        [HttpPost]
        public IActionResult CreateCurrency([FromBody] Currency Currency)
        {
            if (Currency == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCurrency = _CurrencyRepository.AddCurrency(Currency);

            return Created("Currency", createdCurrency);
        }
    }
}

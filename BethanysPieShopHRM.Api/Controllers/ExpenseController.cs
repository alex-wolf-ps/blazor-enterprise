using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _ExpenseRepository;

        public ExpenseController(IExpenseRepository ExpenseRepository)
        {
            _ExpenseRepository = ExpenseRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(_ExpenseRepository.GetAllExpenses());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetExpenseById(int id)
        {
            return Ok(_ExpenseRepository.GetExpenseById(id));
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] Expense Expense)
        {
            if (Expense == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdExpense = _ExpenseRepository.AddExpense(Expense);

            return Created("Expense", createdExpense);
        }
    }
}

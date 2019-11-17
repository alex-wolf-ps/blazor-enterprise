using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_taskRepository.GetAllTasks());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            return Ok(_taskRepository.GetTaskById(id));
        }



        // GET api/<controller>/5
        [HttpPost]
        public IActionResult Post(HRTask task)
        {
            if (task == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdExpense = _taskRepository.AddTask(task);

            return Created("Expense", createdExpense);
        }
    }
}

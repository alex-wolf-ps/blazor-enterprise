using BethanysPieShopHRM.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetJobCategories()
        {
            return Ok(_jobCategoryRepository.GetAllJobCategories());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetJobCategoryById(int id)
        {
            return Ok(_jobCategoryRepository.GetJobCategoryById(id));
        }
    }
}

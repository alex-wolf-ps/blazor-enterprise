using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyController(ISurveyRepository SurveyRepository)
        {
            _surveyRepository = SurveyRepository;
        }

        [HttpGet]
        public IActionResult GetSurveys()
        {
            return Ok(_surveyRepository.GetAllSurveys());
        }

        [HttpGet("{id}")]
        public IActionResult GetSurveyById(int id)
        {
            return Ok(_surveyRepository.GetSurveyById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Survey survey)
        {
            if (survey == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdExpense = _surveyRepository.AddSurvey(survey);

            return Created("Expense", createdExpense);
        }

        [Route("/api/answer")]
        [HttpPost]
        public IActionResult PostAnswer([FromBody]Answer answer)
        {
            if (answer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _surveyRepository.AddAnswer(answer);

            return Ok(answer);
        }
    }
}

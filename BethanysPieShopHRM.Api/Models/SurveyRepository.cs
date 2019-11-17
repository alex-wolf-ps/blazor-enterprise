using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly AppDbContext _appDbContext;

        public SurveyRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IEnumerable<Survey> GetAllSurveys()
        {
            return _appDbContext.Surveys;
        }

        public Survey GetSurveyById(int id)
        {
            return _appDbContext.Surveys.Include(x => x.Answers).FirstOrDefault(x => x.SurveyId == id);
        }

        public Survey AddSurvey(Survey survey)
        {
            var addedEntity = _appDbContext.Surveys.Add(survey);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void AddAnswer(Answer answer)
        {
            _appDbContext.Answers.Add(answer);
            _appDbContext.SaveChanges();
        }
    }
}

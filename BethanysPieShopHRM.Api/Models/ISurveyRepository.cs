using System.Collections.Generic;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public interface ISurveyRepository
    {
        void AddAnswer(Answer answer);
        Survey AddSurvey(Survey survey);
        IEnumerable<Survey> GetAllSurveys();
        Survey GetSurveyById(int id);
    }
}
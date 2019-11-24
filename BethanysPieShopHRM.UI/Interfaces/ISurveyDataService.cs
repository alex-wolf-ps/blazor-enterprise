using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public interface ISurveyDataService
    {
        Task<IEnumerable<Survey>> GetAllSurveys();
        Task<Survey> GetSurveyById(int surveyId);
        Task<Survey> AddSurvey(Survey survey);
        Task<Answer> AddAnswer(Answer answer);
    }
}

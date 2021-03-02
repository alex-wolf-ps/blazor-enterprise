using System.Collections.Generic;

namespace BethanysPieShopHRM.Shared
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Answer> Answers { get; set; }
    }
}

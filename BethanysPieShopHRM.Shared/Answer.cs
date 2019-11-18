using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Response { get; set; }
        public double Rating { get; set; }
        public int SurveyId { get; set; }

        public Survey Survey { get; set; }
    }
}

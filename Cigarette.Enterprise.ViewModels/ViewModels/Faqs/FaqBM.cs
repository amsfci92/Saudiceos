using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Faqs
{
    public class FaqBM
    {
        public int QuestionId { get; set; }
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        [AllowHtml]
        public string AnswerAr { get; set; }
        [AllowHtml]
        public string AnswerEn { get; set; }
        public bool IsActive { get; set; }
    }
}

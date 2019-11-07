using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA.ViewModels
{
    public class QuestionVm
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Category { get; set; }
        public AnswerVm Answers { get; set; }
    }
}

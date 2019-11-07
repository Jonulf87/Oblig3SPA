using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int Rating { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}

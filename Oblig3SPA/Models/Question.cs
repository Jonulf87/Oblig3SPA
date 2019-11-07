using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        NotAnswered = 0,
        Route = 1,
        Food = 2,
        Wifi = 3
    }
}

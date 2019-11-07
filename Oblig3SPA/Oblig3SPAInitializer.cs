using Oblig3SPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA
{
    public static class Oblig3SPAInitializer
    {
        public static void Initialize(Oblig3SPAContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Questions.Any())
            {
                return;
            }

            var questions = new Question[]
            {
                new Question {
                    QuestionText = "øjhjhkalksjdhflaksdjhflaksjhdf", Category = Category.Food, Answers = new List<Answer>() {
                        new Answer { AnswerText = "fuck off nabb", Rating = 4 }
                }}
            };

            context.AddRange(questions);

            context.SaveChanges();
        }
    }
}

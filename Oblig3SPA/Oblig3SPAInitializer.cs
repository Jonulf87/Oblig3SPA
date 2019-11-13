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
                    QuestionText = "Hvilken mat har dere?", Category = Category.Mat, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Kebab", Rating = 4 }
                }},
                new Question {
                    QuestionText = "Hvor mye koster maten?", Category = Category.Mat, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Masse", Rating = 45 }
                }},
                new Question {
                    QuestionText = "Hvor går toget mitt?", Category = Category.Reise, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Hjemover", Rating = 98 }
                }},
                new Question {
                    QuestionText = "Hvilket tog skal jeg ta?", Category = Category.Reise, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Det som skal hjem vel", Rating = 2 }
                }},
                new Question {
                    QuestionText = "Har dere WiFi?", Category = Category.Wifi, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Ja :)", Rating = 76 }
                }},
                new Question {
                    QuestionText = "Hvor raskt er internettet deres?", Category = Category.Wifi, Answers = new List<Answer>() {
                        new Answer { AnswerText = "dial-up", Rating = -45 },
                        new Answer { AnswerText = "La meg svare deg med et spørsmål; hvor mye er du villig til å betale for internett? Eneste begrensningen vår er penger.", Rating = 2764 }
                }}
            };

            context.AddRange(questions);

            context.SaveChanges();
        }
    }
}

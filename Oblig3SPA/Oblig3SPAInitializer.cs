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
                    QuestionText = "Er det mulig å kjøpe mat ombord på toget?", Category = Category.Mat, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Det er en kioskvogn samt automater hvor du kan kjøpe enkel type mat.", Rating = 24 },
                        new Answer { AnswerText = "Det er mulig å kjøpe mat flere steder om bord på toget.", Rating = 8 }
                }},
                new Question {
                    QuestionText = "Er det mulig å få halal-mat ombord på toget?", Category = Category.Mat, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Det serveres mye mat som ikke er kjøttbasert.", Rating = -8 },
                        new Answer { AnswerText = "Det serveres en bedre middag på de lengre turene som også er tilgjengelig med halalkjøtt.", Rating = 25 },
                        new Answer { AnswerText = "Kisokvarene er alle halal.", Rating = 13 }
                }},
                new Question {
                    QuestionText = "Hvordan bestiller jeg billett?", Category = Category.Reise, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Velg dato, hvor du reiser fra og hvor du skal reise til.", Rating = 3 },
                        new Answer { AnswerText = "Velg hvor du vil reise fra og hvor du vil reise til. Så velger du dato og klikker deg videre. Da vil du få mulighet til å velge hvilken avgang den valgte datoen du ønsker å reise på. Velg og bekreft.", Rating = 55 }
                }},
                new Question {
                    QuestionText = "Kan jeg refundere en kjøpt billett?", Category = Category.Reise, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Lol! Nei.", Rating = 542 }
                }},
                new Question {
                    QuestionText = "Er det WiFi ombord?", Category = Category.Wifi, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Ja.", Rating = 2 },
                        new Answer { AnswerText = "Ja, du må bare velge VyWifi og logg deg på. Helt gratis.", Rating = 18 }
                }},
                new Question {
                    QuestionText = "Hvor raskt er internettet deres?", Category = Category.Wifi, Answers = new List<Answer>() {
                        new Answer { AnswerText = "Vi har ikke verdens raskeste internett, men det er mer enn nok til å streame i SD.", Rating = -45 },
                        new Answer { AnswerText = "Gratis internett er begrenset til 500kBit/s. Du har mulighet til å betale et beløp på 20,- for å oppgradere til 5MBit/s.", Rating = 2764 }
                }}
            };

            context.AddRange(questions);

            context.SaveChanges();
        }
    }
}

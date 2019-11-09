using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oblig3SPA;
using Oblig3SPA.Models;
using Oblig3SPA.ViewModels;

namespace Oblig3SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly Oblig3SPAContext _context;

        public QuestionsController(Oblig3SPAContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<QuestionVm>>> GetQuestions(Category category)
        {
            return await _context.Questions
                .Where(a => a.Category == category)
                .Select(a => new QuestionVm
                {
                    Category = (int)a.Category,
                    Id = a.Id,
                    QuestionText = a.QuestionText,
                    Answers = a.Answers.Select(b => new AnswerVm
                    {
                        AnswerText = b.AnswerText,
                        Rating = b.Rating
                    }).SingleOrDefault()
                }).ToListAsync();
        }

        // GET: api/Questions
        [HttpGet("answer/{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerVm>>> GetAnswer(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .Select(a => new AnswerVm
                {
                    Id = a.Id,
                    AnswerText = a.AnswerText,
                    Rating = a.Rating
                }).OrderByDescending(a => a.Rating)
                .ToListAsync();
        }




        [HttpGet("categories")]
        public ActionResult<IEnumerable<CategoryVm>> GetCategories()
        {
            return Enum.GetValues(typeof(Category))
                .Cast<Category>()
                .Where(a => a != Category.NotAnswered)
                .Select(a => new CategoryVm
                {
                    Id = (int)a,
                    Name = a.ToString()
                }).ToList();
        }

        // PUT: api/Questions/5
        [HttpPut("voteup/{answerId}")]
        public async Task<IActionResult> VoteUpAnswer(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            if (answer == null)
            {
                return NotFound();
            }

            answer.Rating++;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("votedown/{answerId}")]
        public async Task<IActionResult> VoteDownAnswer(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            if (answer == null)
            {
                return NotFound();
            }

            answer.Rating--;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(QuestionVm questionVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var question = new Question
            {
                Category = Category.NotAnswered,
                QuestionText = questionVm.QuestionText
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return question;
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}

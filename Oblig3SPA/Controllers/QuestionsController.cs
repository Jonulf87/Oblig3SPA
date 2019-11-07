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
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<QuestionVm>>> GetQuestions(int categoryId)
        {
            return await _context.Questions
                .Where(a => (int)a.Category == categoryId)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
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

using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._16334.Data;
using WAD.BACKEND._16334.Models;

namespace WAD.BACKEND._16334.Repository
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly SurveyFormAppDbContext _context;

        public QuestionRepository(SurveyFormAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                                 .Include(q => q.Survey) 
                                 .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                                 .Include(q => q.Survey) 
                                 .FirstOrDefaultAsync(q => q.id == id);
        }

        public async Task AddQuestionAsync(Question question)
        {
            var survey = await _context.Surveys.FindAsync(question.SurveyId);
            if (survey == null)
            {
                throw new KeyNotFoundException("Survey with the specified ID does not exist.");
            }

            question.Survey = survey; 
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            var existingQuestion = await _context.Questions
                                                  .Include(q => q.Survey)
                                                  .FirstOrDefaultAsync(q => q.id == question.id);

            if (existingQuestion != null)
            {
                existingQuestion.Text = question.Text;
                existingQuestion.SurveyId = question.SurveyId;

                var survey = await _context.Surveys.FindAsync(question.SurveyId);
                if (survey == null)
                {
                    throw new KeyNotFoundException("Survey with the specified ID does not exist.");
                }

                existingQuestion.Survey = survey;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._16334.Data;
using WAD.BACKEND._16334.Models;

namespace WAD.BACKEND._16334.Repository
{
    public class SurveyRepository:ISurveyRepository
    {
        private readonly SurveyFormAppDbContext _context;

        public SurveyRepository(SurveyFormAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            return await _context.Surveys.FirstOrDefaultAsync(s => s.id == id);
        }

        public async Task AddSurveyAsync(Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSurveyAsync(Survey survey)
        {
            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using WAD.BACKEND._16334.Models;

namespace WAD.BACKEND._16334.Repository
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int id);
        Task AddSurveyAsync(Survey survey);
        Task UpdateSurveyAsync(Survey survey);
        Task DeleteSurveyAsync(int id);
    }
}

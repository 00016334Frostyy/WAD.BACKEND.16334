using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._16334.Models;

namespace WAD.BACKEND._16334.Data
{
    public class SurveyFormAppDbContext: DbContext
    {
        public SurveyFormAppDbContext(DbContextOptions<SurveyFormAppDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}

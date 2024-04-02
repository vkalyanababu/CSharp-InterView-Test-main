using Microsoft.AspNetCore.Mvc;
using SportScore.API.Models;
using SportScore.API.Models.Dtos;

namespace SportScore.API.Repositories
{
    public interface IHistoricalScoresRepository
    {
        public Task<HistoricalScore> CheckScoreAndSaveResultAsync(SportsDto sportsDto);
        public Task<HistoricalScore> RetrieveHistoricalScoresAsync(Guid guid);
        public Task<bool> DeleteHistoricalScoresAsync(Guid guid);
    }
}

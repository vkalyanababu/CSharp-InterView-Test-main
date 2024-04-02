using Microsoft.AspNetCore.Mvc;
using SportScore.API.Data;
using SportScore.API.Models;
using SportScore.API.Models.Dtos;
using SportsScorePredictor;

namespace SportScore.API.Repositories
{
    public class HistoricalScoresRepository : IHistoricalScoresRepository
    {
        private readonly InMemoryHistoricalScoresData _inMemoryHistoricalScoresData;
        private readonly AbstractGameStrategy _abstractGameStrategy;

        public HistoricalScoresRepository(InMemoryHistoricalScoresData inMemoryHistoricalScoresData, AbstractGameStrategy abstractGameStrategy)
        {
            _inMemoryHistoricalScoresData = inMemoryHistoricalScoresData;
            _abstractGameStrategy = abstractGameStrategy;
        }

        /// <summary>
        /// Mimicking asynchronous methods
        /// Asynchronous methods improve the performance by not blocking thread and utilizing multi-processor benefits
        /// </summary>
        /// <param name="sportsDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<HistoricalScore> CheckScoreAndSaveResultAsync(SportsDto sportsDto)
        {
            _abstractGameStrategy.NameOfTeam1 = sportsDto.NameOfTeam1;
            _abstractGameStrategy.NameOfTeam2 = sportsDto.NameOfTeam2;
            ScorePredictorContext scorePredictorContext = new ScorePredictorContext(_abstractGameStrategy);

            var expectedOutput = await Task.Run(() => scorePredictorContext.PredictWinner(sportsDto.InputData, sportsDto.WinningCount));
            var id = Guid.NewGuid();

            _inMemoryHistoricalScoresData.AddHistoricalScores(new HistoricalScore { Id = id, Score = expectedOutput });

            return await Task.Run(() => _inMemoryHistoricalScoresData.GetHistoricalScores(id));
        }

        /// <summary>
        /// Delete historical data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteHistoricalScoresAsync(Guid id) => await Task.Run(() => _inMemoryHistoricalScoresData.DeleteHistoricalScores(id));

        /// <summary>
        /// Get the historical data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HistoricalScore> RetrieveHistoricalScoresAsync(Guid id) => await Task.Run(() => _inMemoryHistoricalScoresData.GetHistoricalScores(id));
    }
}

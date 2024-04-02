using SportScore.API.Models;
using System;

namespace SportScore.API.Data
{
    /// <summary>
    /// To mimic database
    /// This can be replaced with Entity Framework Core for Persistance in DB
    /// </summary>
    public class InMemoryHistoricalScoresData
    {
        private static readonly List<HistoricalScore> historicalScoresList = new List<HistoricalScore>();
        
        public void AddHistoricalScores(HistoricalScore historicalScores)
        {
            historicalScoresList.Add(historicalScores);
        }

        public HistoricalScore GetHistoricalScores(Guid guid)
        {
            return historicalScoresList.FirstOrDefault(hd => hd.Id == guid);
        }

        public bool DeleteHistoricalScores(Guid guid)
        {
            var item = historicalScoresList.Where(hd => hd.Id == guid).FirstOrDefault();

            if (item == null)
                return false;

            if (item != null)
                historicalScoresList.Remove(item);

            return true;
        }

        public void UpdateHistoricalScores(HistoricalScore historicalScore)
        {
            var item = historicalScoresList.Where(hd => hd.Id == historicalScore.Id).FirstOrDefault();

            if (item == null)
                return;

            item.Score = historicalScore.Score;
        }
    }
}

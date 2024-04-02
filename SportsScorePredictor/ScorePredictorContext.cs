using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScorePredictor
{
    /// <summary>
    /// The 'Context' Client class for the 'Strategy'
    /// </summary>
    public class ScorePredictorContext
    {
        private readonly AbstractGameStrategy _abstractGameStrategy;
        public ScorePredictorContext(AbstractGameStrategy abstractGameStrategy) 
        {
            _abstractGameStrategy = abstractGameStrategy;
        }

        public string PredictWinner(string[] scores, int n)
        {
            return _abstractGameStrategy.PredictWinner(scores, n);
        }
    }
}

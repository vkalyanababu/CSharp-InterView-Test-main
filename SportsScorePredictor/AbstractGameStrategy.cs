using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScorePredictor
{
    /// <summary>
    /// The 'Strategy' interface
    /// </summary>
    public abstract class AbstractGameStrategy
    {
        public string NameOfTeam1 { get; set; } = "";
        public string NameOfTeam2 { get; set; } = "";


        /// <summary>
        /// This method can be overridden in derived classes if required to provide new implementation for each game
        /// </summary>
        /// <param name="scores"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual string PredictWinner(string[] scores, int n)
        {
            List<int[]> teamScores = new List<int[]>();
            string scoreSet = "";
            int team1Count = 0;
            foreach (var score in scores)
            {
                teamScores.Add(GetScores(score, n));
            }

            //Count the total winning of Team1 &
            //Construct the result string something like -> "Ravens beat Badgers (2-1) Scores: 15-7, 7-15, 15-7."
            for (int i = 0; i < scores.Length; i++)
            {
                int[] arr = teamScores[i];
                
                // check winning condition
                if (arr[1] == n && arr[0] < n - 1)
                {
                    team1Count++;                    
                }

                // TODO
                //if (Math.Abs(arr[0] - arr[1]) == 2)
                //{
                //    // condition of lost
                //    if (arr[1] > arr[0])
                //    {
                //        team1Count++;
                //    }
                //}

                scoreSet += arr[1] + "-" + arr[0] + ", ";
            }


            if (team1Count > scores.Length - team1Count)
                return $"{NameOfTeam1} beat {NameOfTeam1} ({team1Count}-{scores.Length - team1Count}) Scores: {scoreSet.Substring(0, scoreSet.LastIndexOf(','))}.";
            else
                return $"{NameOfTeam2} beat {NameOfTeam1} ({team1Count}-{scores.Length - team1Count} Scores: {scoreSet.Substring(0, scoreSet.LastIndexOf(','))}.";
        }

        private int[] GetScores(string score, int n)
        {
            int[] count = new int[2];
            int i;
            for (i = 0; i < score.Length; i++)
            {
                // increase count
                count[score[i] - '0']++;

                // check losing condition
                if (score[0] == n && score[1] < n - 1)
                {
                    return count;
                }

                // check winning condition
                if (count[1] == n && count[0] < n - 1)
                {
                    return count;
                }

                // check tie on n-1 point
                if (count[0] == n - 1 && count[1] == n - 1)
                {
                    count[0] = 0;
                    count[1] = 0;
                    break;
                }
            }

            for (i++; i < score.Length; i++)
            {
                // increase count
                count[score[i] - '0']++;

                // check for 2 point lead
                if (Math.Abs(count[0] - count[1]) == 2)
                {
                    return count;
                }
            }

            return count;
        }
    }
}

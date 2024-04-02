namespace SportsScorePredictor
{
    public static class ScorePredictor
    {
        public static string PredictWinner(string score, int n)
        {
            int[] count = new int[2];
            int i;
            for (i = 0; i < score.Length; i++)
            {
                // increase count
                count[score[i] - '0']++;

                // check losing
                // condition
                if (count[0] == n && count[1] < n - 1)
                {
                    return ("Team 1 lost");
                }

                // check winning condition
                if (count[1] == n && count[0] < n - 1)
                {
                    return ("Team 1 won");
                }

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
                    // condition of lost
                    if (count[0] > count[1])
                    {
                        return "Team 1 lost";
                    }

                    // condition of win
                    else
                    {
                        return "Team 1 won";
                    }
                }
            }

            return "Tie Winner";
        }
    }
}
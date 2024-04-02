using SportsScorePredictor;
using Xunit;

public class PredictionTests
{
    [Fact]
    public void PredictVolleyballWinner_ValidScores_0()
    {
        // Arrange
        VolleyballStrategy volleyballStrategy = new VolleyballStrategy();
        volleyballStrategy.NameOfTeam1 = "Badgers";
        volleyballStrategy.NameOfTeam2 = "Ravens";
        ScorePredictorContext scorePredictorContext = new ScorePredictorContext(volleyballStrategy);

        // Act
        var expectedOutput = scorePredictorContext
                                .PredictWinner(new string[] { 
                                          "1001010101111011101111",
                                          "0110101010000100010000",
                                          "1001010111111011101111" }, 15);

        // Assert
        Assert.Equal("Ravens beat Badgers (2-1) Scores: 15-7, 7-15, 15-7.", expectedOutput);
    }

    [Fact]
    public void PredictVolleyballWinner_ValidScores_1()
    {
        // Arrange
        VolleyballStrategy volleyballStrategy = new VolleyballStrategy();
        volleyballStrategy.NameOfTeam1 = "Badgers";
        volleyballStrategy.NameOfTeam2 = "Ravens";
        ScorePredictorContext scorePredictorContext = new ScorePredictorContext(volleyballStrategy);

        // Act
        var expectedOutput = scorePredictorContext
                                .PredictWinner(new string[] {
                                          "1001010101111011101111",
                                          "1111111111100100010000",
                                          "0000000001010011101111" }, 9);

        // Assert
        Assert.Equal("Ravens beat Badgers (2-1) Scores: 9-6, 9-0, 9-13.", expectedOutput);
    }
}
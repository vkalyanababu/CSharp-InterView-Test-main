namespace SportScore.API.Models.Dtos
{
    public class SportsDto
    {
        public string NameOfTeam1 { get; set; } = "";
        public string NameOfTeam2 { get; set; } = "";
        public string[] InputData { get; set; }
        public int WinningCount { get; set; }
    }
    public class VolleyballDto : SportsDto
    {

    }
    public class SquashlDto : SportsDto
    {

    }
}

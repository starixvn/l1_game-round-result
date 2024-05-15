namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class BallColorViewModel
    {
        public static string GetBallColor(int ball)
        {
            return ball % 2 == 0 ? "red-ball" : "blue-ball";
        }
    }
}
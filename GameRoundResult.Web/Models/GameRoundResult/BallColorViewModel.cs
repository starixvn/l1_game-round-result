using System.Collections.Generic;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class BallColorViewModel
    {
        public static string GetBallColor(int ball)
        {
            var temp = new List<string> { "red-ball", "red-ball", "green-ball", "green-ball" };
            return temp[(ball - 1) % 4];
        }
    }
}
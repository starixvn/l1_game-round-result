using System.Collections.Generic;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class BacBall1ColorViewModel
    {
        public static List<int> GreenBalls = new List<int> { 3, 4, 7, 8, 11, 12, 15, 16, 19, 20, 23, 24, 27, 28, 31, 32, 35, 36, 39, 40, 43, 44, 47, 48, 51, 52, 55, 56, 59, 60, 63, 64, 67, 68, 71, 72, 75 };

        public static string GetBallColor(int ball)
        {
            return GreenBalls.Contains(ball) ? "green-ball" : "red-ball";
        }
    }
}

using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.NextBall;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using System;
using System.Collections.Generic;


namespace GameRoundResult.Web._Shared
{
    public static class GameDrawTicketAccessorHelper
    {
        public static IEnumerable<RoundResultViewModel> GetRoundResult(GetRoundResultRequest request, IEnumerable<object> result)
        {
            switch (request.GameType)
            {
                case (GameType.BacBall1):
                    return GetDrawResultBacBall((IEnumerable<BacBall1Round>)result, request);

                case (GameType.BacBall2):
                    return GetDrawResultBacBall((IEnumerable<BacBall2Round>)result, request);

                case (GameType.NextBall1):
                    return GetDrawResultNextBall((IEnumerable<NextBall1Round>)result, request);

                case (GameType.NextBall2):
                    return GetDrawResultNextBall((IEnumerable<NextBall2Round>)result, request);

                default:
                    return new List<RoundResultViewModel>();
            }
        }

        private static IEnumerable<RoundResultViewModel> GetDrawResultNextBall(IEnumerable<NextBall1Round> result, GetRoundResultRequest request)
        {
            var roundResults = new List<RoundResultViewModel>();

            foreach (var gameDraw in result)
            {
                for (var i = gameDraw.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == gameDraw.Result[i].DrawId))
                    {
                        var roundResult = new NextBallRoundResultViewModel
                        {
                            DrawId = gameDraw.Result[i].DrawId,
                            Result = gameDraw.Result[i],
                            SettlementResult = gameDraw.SettlementResult[i],
                            Time = TimeZoneInfo.ConvertTimeFromUtc(gameDraw.Time, request.TimeZoneInfo),
                            TimeZone = request.TimeZoneInfo
                        };
                        roundResults.Add(roundResult);
                    }
                }
            }
            return roundResults;
        }

        private static IEnumerable<RoundResultViewModel> GetDrawResultBacBall(IEnumerable<BacBall1Round> result, GetRoundResultRequest request)
        {
            var roundResults = new List<RoundResultViewModel>();

            foreach (var gameDraw in result)
            {
                for (var i = gameDraw.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == gameDraw.Result[i].DrawId))
                    {
                        var roundResult = new BacBallRoundResultViewModel
                        {
                            DrawId = gameDraw.Result[i].DrawId,
                            Result = gameDraw.Result[i],
                            SettlementResult = gameDraw.SettlementResult[i],
                            Time = TimeZoneInfo.ConvertTimeFromUtc(gameDraw.Time, request.TimeZoneInfo),
                            TimeZone = request.TimeZoneInfo
                        };
                        roundResults.Add(roundResult);
                    }
                }
            }
            return roundResults;
        }
    }
}

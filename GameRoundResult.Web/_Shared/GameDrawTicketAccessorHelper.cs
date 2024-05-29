using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

                case (GameType.LuckyNext1):
                    return GetDrawResultLuckyNext((IEnumerable<LuckyNext1Round>)result, request);

                case (GameType.LuckyNext2):
                    return GetDrawResultLuckyNext((IEnumerable<LuckyNext2Round>)result, request);

                case (GameType.SeBall1):
                    return GetSeBallResult((IEnumerable<SeBall1Round>)result, request);

                case (GameType.LuckyThree):
                    return GetViewModel<LuckyThreeRound, LuckyThreeRoundResult, LuckyThreeSettlementResult, LuckyThreeRoundResultViewModel>((IEnumerable<LuckyThreeRound>)result, request);

                default:
                    return new List<RoundResultViewModel>();
            }
        }

        private static IEnumerable<RoundResultViewModel> GetDrawResultLuckyNext(IEnumerable<LuckyNext1Round> result, GetRoundResultRequest request)
        {
            var roundResults = new List<RoundResultViewModel>();

            foreach (var gameDraw in result)
            {
                for (var i = gameDraw.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == gameDraw.Result[i].DrawId))
                    {
                        var roundResult = new LuckyNextRoundResultViewModel
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

        private static IEnumerable<RoundResultViewModel> GetSeBallResult(IEnumerable<SeBall1Round> result, GetRoundResultRequest request)
        {
            var roundResults = new List<RoundResultViewModel>();

            foreach (var gameDraw in result)
            {
                for (var i = gameDraw.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == gameDraw.Result[i].DrawId))
                    {
                        var roundResult = new SeBallRoundResultViewModel
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

        private static IEnumerable<RoundResultViewModel> GetViewModel<TRound, TRoundResult, TSettlementResult, TViewModel>(IEnumerable<TRound> result, GetRoundResultRequest request)
            where TRound : GameDraw<TRoundResult, TSettlementResult>
            where TRoundResult : GameDrawResultBase
            where TSettlementResult : GameDrawBase
            where TViewModel : BaseDrawResultViewModel<TRoundResult, TSettlementResult>, new()
        {
            var roundResults = new List<RoundResultViewModel>();

            foreach (var gameDraw in result)
            {
                for (var i = gameDraw.Result.Count - 1; i >= 0; i--)
                {
                    if (request.RoundId == 0 || (request.RoundId == gameDraw.Result[i].DrawId))
                    {
                        var roundResult = new TViewModel
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
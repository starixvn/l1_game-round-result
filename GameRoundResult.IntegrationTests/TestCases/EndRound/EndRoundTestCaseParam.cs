using System;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class EndRoundTestCaseParam
    {
        public EndRoundTestCaseParam(
            GameType game,
            int playerId,
            int roundId,
            decimal totalAmount,
            decimal totalWin,
            decimal validBet,
            DateTimeOffset? endTime,
            string errorCode,
            string errorDescription)
        {
            Game = game;
            PlayerId = playerId;
            RoundId = roundId;
            TotalAmount = totalAmount;
            TotalWin = totalWin;
            ValidBet = validBet;
            EndTime = endTime;
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public GameType Game { get; }
        public int PlayerId { get; }
        public int RoundId { get; }
        public decimal TotalAmount { get; }
        public decimal TotalWin { get; }
        public decimal ValidBet { get; }
        public DateTimeOffset? EndTime { get; }
        public string ErrorCode { get; }
        public string ErrorDescription { get; }
    }
}
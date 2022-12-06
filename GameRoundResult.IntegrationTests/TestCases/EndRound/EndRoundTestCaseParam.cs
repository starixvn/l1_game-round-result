using System;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record EndRoundTestCaseParam(
             GameType Game,
             int PlayerId,
             int RoundId,
             decimal TotalAmount,
             decimal TotalWin,
             decimal ValidBet,
             DateTimeOffset? EndTime,
             string ErrorCode,
             string ErrorDescription);
}
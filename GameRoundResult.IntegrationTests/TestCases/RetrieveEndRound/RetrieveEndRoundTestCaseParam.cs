using System;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RetrieveEndRoundTestCaseParam(
             int GameId,
             string GameName,
             int PlayerId,
             int RoundId,
             string TestCase);
}
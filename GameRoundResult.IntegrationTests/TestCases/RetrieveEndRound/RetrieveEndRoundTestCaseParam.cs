using System;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RetrieveEndRoundTestCaseParam(
             GameType Game,
             int PlayerId,
             int RoundId,
             string TestCase);
}
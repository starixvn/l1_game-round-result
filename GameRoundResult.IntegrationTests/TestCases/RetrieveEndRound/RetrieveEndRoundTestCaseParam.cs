using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RetrieveEndRoundTestCaseParam(
             int GameId,
             string GameName,
             GameType GameType,
             int PlayerId,
             int RoundId,
             string TestCase);
}
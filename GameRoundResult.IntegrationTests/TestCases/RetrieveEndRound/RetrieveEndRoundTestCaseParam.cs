using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RetrieveEndRoundTestCaseParam(
             int GameId,
             string GameName,
             GameConfigsType GameType,
             int PlayerId,
             int RoundId,
             string TestCase);
}
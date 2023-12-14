using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RetrieveEndRoundTestCaseParam(
             int GameId,
             string GameName,
             GameConfigsType GameType,
             string PlayerId,
             int RoundId,
             string TestCase);
}
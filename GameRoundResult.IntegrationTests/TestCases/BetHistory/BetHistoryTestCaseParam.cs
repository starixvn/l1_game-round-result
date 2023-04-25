using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record BetHistoryTestCaseParam(int GameId, string GameName, GameConfigsType GameType, int PlayerId, long RoundId, string Language, string TestCase);
}
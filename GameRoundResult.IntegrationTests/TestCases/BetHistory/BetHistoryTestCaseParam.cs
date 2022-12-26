using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record BetHistoryTestCaseParam(GameType Game, int PlayerId, long RoundId, string Language, string TestCase);
}
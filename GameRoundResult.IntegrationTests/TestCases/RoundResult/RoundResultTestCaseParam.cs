using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RoundResultTestCaseParam(GameId Game, long RoundId, string Date, string Language, string TestCase);

    public record RoundResultSelectOptionsTestCaseParam(GameId Game, string GameName, string Language);
}
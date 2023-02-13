using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public record RoundResultTestCaseParam(GameType Game, long RoundId, string Date, string Language, string TestCase);

    public record RoundResultSelectOptionsTestCaseParam(GameType Game, string GameName, string Language);
}
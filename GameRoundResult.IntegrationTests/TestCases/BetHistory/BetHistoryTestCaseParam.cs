using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BetHistoryTestCaseParam
    {
        public BetHistoryTestCaseParam(GameType game, int playerId, long roundId, string language, string fileName)
        {
            Game = game;
            PlayerId = playerId;
            RoundId = roundId;
            Language = language;
            FileName = fileName;
        }

        public GameType Game { get; }
        public int PlayerId { get; }
        public long RoundId { get; }
        public string Language { get; }
        public string FileName { get; }
    }
}
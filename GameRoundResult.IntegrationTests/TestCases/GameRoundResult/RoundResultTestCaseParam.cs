using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class RoundResultTestCaseParam
    {
        public RoundResultTestCaseParam(GameType game, long roundId, string date, string language, string fileName)
        {
            Game = game;
            RoundId = roundId;
            Date = date;
            Language = language;
            FileName = fileName;
        }

        public GameType Game { get; set; }
        public long RoundId { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
        public string FileName { get; set; }
    }
}
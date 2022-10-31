using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class RoundResultModel
    {
        public RoundResultModel(GameType game, long roundId, string date, string fileName)
        {
            Game = game;
            RoundId = roundId;
            Date = date;
            FileName = fileName;
        }

        public GameType Game { get; set; }
        public long RoundId { get; set; }
        public string Date { get; set; }
        public string FileName { get; set; }
    }
}
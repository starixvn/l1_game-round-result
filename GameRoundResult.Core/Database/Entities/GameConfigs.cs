using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("game_configs")]
    public class GameConfigs
    {
        public byte Type { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool EnableFreeBet { get; set; }

        public string[] SiteExclusions { get; set; }

        public double SmartBotGroupRatio { get; set; }

        public int GameId { get; set; }

        public byte RandomMode { get; set; }

        public string RoundCollectionSuffix { get; set; }
    }
}
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("game_configs")]
    public class GameConfigEntity: Document
    {
        public int GameId { get; set; }

        public byte Type { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}

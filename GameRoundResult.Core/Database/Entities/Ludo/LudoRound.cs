using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.Ludo
{
    [CollectionName("ludo_rounds")]
    public class LudoRound : GameRound
    {
        public LudoResultEntity Result { get; set; }

        public LudoSettlementResultEntity SettlementResult { get; set; }
    }

    public class LudoResultEntity
    {
        public List<int> Dice { get; set; }

        public Dictionary<string, int> Action { get; set; }
    }

    public class ActionEntity
    {
        public string OldPosition { get; set; }
        public string NewPosition { get; set; }
        public string PlayerColor { get; set; }
    }

    public class LudoSettlementResultEntity
    {
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Kick { get; set; }
        public bool NoKick { get; set; }
        public bool Move { get; set; }
        public bool NoMove { get; set; }
        public bool Release { get; set; }
        public bool NoRelease { get; set; }
        public bool GoStable { get; set; }
        public bool NoStable { get; set; }
    }
}

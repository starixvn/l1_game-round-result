using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoPowerRound : GameRound
    {
        public KenoPowerResult Result { get; set; }
        public KenoPowerSettlementResult SettlementResult { get; set; }
    }

    public class KenoPowerResult
    {
        public IEnumerable<byte> Player { get; set; }
        public IEnumerable<byte> Banker { get; set; }
    }

    public class KenoPowerSettlementResult
    {
        public bool Player { get; set; }
        public bool Banker { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Red { get; set; }
        public bool Orange { get; set; }
        public bool Yellow { get; set; }
        public bool Green { get; set; }
        public bool Blue { get; set; }
        public bool Indigo { get; set; }
        public bool Violet { get; set; }
        public bool PlayerBig { get; set; }
        public bool PlayerSmall { get; set; }
        public bool BankerBig { get; set; }
        public bool BankerSmall { get; set; }
    }

    [CollectionName("kenopower1_phiens")]
    public class KenoPower1Round : KenoPowerRound
    {
    }

    [CollectionName("kenopower2_phiens")]
    public class KenoPower2Round : KenoPowerRound
    {
    }
}
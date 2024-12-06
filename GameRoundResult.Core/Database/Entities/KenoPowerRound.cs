using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoPowerRound : GameRound
    {
        public KenoPowerResult Result { get; set; }
        public KenoPowerSettlementResult SettlementResult { get; set; }
        public bool Settled { get; set; }
    }

    public class KenoPowerResult
    {
        public IEnumerable<byte> Blue { get; set; }
        public IEnumerable<byte> Red { get; set; }
    }

    public class KenoPowerSettlementResult
    {
        public bool Blue { get; set; }
        public bool Red { get; set; }
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool BlueBig { get; set; }
        public bool BlueSmall { get; set; }
        public bool RedBig { get; set; }
        public bool RedSmall { get; set; }
    }

    [CollectionName("kenopower1_phiens")]
    public class KenoPower1Round : KenoPowerRound
    {
    }

    [CollectionName("kenopower2_phiens")]
    public class KenoPower2Round : KenoPowerRound
    {
    }

    [CollectionName("kenopower_rounds")]
    public class SKKenoPowerRound : KenoPowerRound
    {
    }

    [CollectionName("kenopower2_rounds")]
    public class SKKenoPower2Round : KenoPowerRound
    {
    }
}
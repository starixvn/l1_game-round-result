using System.Collections.Generic;
using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoRound : GameRound
    {
        public IEnumerable<byte> Result { get; set; }

        public SettlementResult SettlementResult { get; set; }
    }

    [CollectionName("kenopromax_phiens")]
    public class KenoProMaxRound: KenoRound
    {

    }

    [CollectionName("kenomax_phiens")]
    public class KenoMaxRound : KenoRound
    {

    }

    [CollectionName("kenomax2_phiens")]
    public class KenoMax2Round : KenoRound
    {

    }

    [CollectionName("kenomini_phiens")]
    public class KenoMiniRound : KenoRound
    {

    }

    [CollectionName("kenomini2_phiens")]
    public class KenoMini2Round : KenoRound
    {

    }

    [CollectionName("kenoeast_phiens")]
    public class KenoEastRound : KenoRound
    {

    }

    [CollectionName("kenowest_phiens")]
    public class KenoWestRound : KenoRound
    {

    }

    [CollectionName("kenosouth_phiens")]
    public class KenoSouthRound : KenoRound
    {

    }

    [CollectionName("kenonorth_phiens")]
    public class KenoNorthRound : KenoRound
    {

    }


    public class SettlementResult
    {
        public bool Big { get; set; }
        public bool Small { get; set; }
        public bool Odd { get; set; }
        public bool Even { get; set; }
        public bool Gold { get; set; }
        public bool Wood { get; set; }
        public bool Water { get; set; }
        public bool Fire { get; set; }
        public bool Earth { get; set; }
    }
}
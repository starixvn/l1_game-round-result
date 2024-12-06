using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class RNGKenoBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }

    [CollectionName("kenomax_cuocs")]
    public class KenoMaxBet : RNGKenoBet
    {
    }

    [CollectionName("kenomax2_cuocs")]
    public class KenoMax2Bet : RNGKenoBet
    {
    }

    [CollectionName("kenomini_cuocs")]
    public class KenoMiniBet : RNGKenoBet
    {
    }

    [CollectionName("kenomini2_cuocs")]
    public class KenoMini2Bet : RNGKenoBet
    {
    }

    [CollectionName("kenoeast_cuocs")]
    public class KenoEastBet : RNGKenoBet
    {
    }

    [CollectionName("kenowest_cuocs")]
    public class KenoWestBet : RNGKenoBet
    {
    }

    [CollectionName("kenosouth_cuocs")]
    public class KenoSouthBet : RNGKenoBet
    {
    }

    [CollectionName("kenonorth_cuocs")]
    public class KenoNorthBet : RNGKenoBet
    {
    }

    [CollectionName("megakeno_bets")]
    public class MegaKenoBet : RNGKenoBet
    {
    }

    [CollectionName("megakeno2_bets")]
    public class MegaKeno2Bet : RNGKenoBet
    {
    }

    [CollectionName("megakeno_betlogs")]
    public class SKMegaKenoBetLog : RNGKenoBet
    {
    }

    [CollectionName("megakeno2_betlogs")]
    public class SKMegaKeno2BetLog : RNGKenoBet
    {
    }

    [CollectionName("kenomini_betlogs")]
    public class SKKenoMiniBetLog : RNGKenoBet
    {
    }

    [CollectionName("kenomini2_betlogs")]
    public class SKKenoMini2BetLog : RNGKenoBet
    {
    }

    [CollectionName("kenoeast_betlogs")]
    public class SKKenoEastBetLog : RNGKenoBet
    {
    }

    [CollectionName("kenowest_betlogs")]
    public class SKKenoWestBetLog : RNGKenoBet
    {
    }

    [CollectionName("kenosouth_betlogs")]
    public class SKKenoSouthBetLog : RNGKenoBet
    {
    }

    [CollectionName("kenonorth_betlogs")]
    public class SKKenoNorthBetLog : RNGKenoBet
    {
    }
}
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
}
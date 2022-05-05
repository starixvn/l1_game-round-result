using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class RNGKenoOnes : BaseBetEntity
    {
        public decimal Big { get; set; }

        public decimal Small { get; set; }

        public decimal Odd { get; set; }

        public decimal Even { get; set; }

        public decimal Gold { get; set; }

        public decimal Earth { get; set; }

        public decimal Fire { get; set; }

        public decimal Water { get; set; }

        public decimal Wood { get; set; }

        public decimal TotalAmount => Big + Small + Odd + Even + Gold + Earth + Fire + Water + Wood;
    }


    [CollectionName("kenomax_ones")]
    public class KenoMaxOne : RNGKenoOnes
    {

    }

    [CollectionName("kenomax2_ones")]
    public class KenoMax2One : RNGKenoOnes
    {

    }

    [CollectionName("kenomini_ones")]
    public class KenoMiniOne : RNGKenoOnes
    {

    }

    [CollectionName("kenomini2_ones")]
    public class KenoMini2One : RNGKenoOnes
    {

    }

    [CollectionName("kenoeast_ones")]
    public class KenoEastOne : RNGKenoOnes
    {

    }

    [CollectionName("kenowest_ones")]
    public class KenoWestOne : RNGKenoOnes
    {

    }

    [CollectionName("kenosouth_ones")]
    public class KenoSouthOne : RNGKenoOnes
    {

    }

    [CollectionName("kenonorth_ones")]
    public class KenoNorthOne : RNGKenoOnes
    {

    }
}
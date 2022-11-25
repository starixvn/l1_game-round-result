using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("currency_groups")]
    public class CurrencyGroup : Document
    {
        public bool? FractionalOddsFormat { get; set; }
    }
}
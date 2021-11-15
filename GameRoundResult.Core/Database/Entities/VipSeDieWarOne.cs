using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("vipsediewar_ones")]
    public class VipSeDieWarOne : BaseBetEntity
    {
        public decimal TotalAmount { get; set; }
    }
}
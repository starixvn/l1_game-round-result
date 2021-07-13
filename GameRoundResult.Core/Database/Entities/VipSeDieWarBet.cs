using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("vipsediewar_cuocs")]
    public class VipSeDieWarBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }
}
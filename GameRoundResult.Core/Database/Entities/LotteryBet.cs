using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("lottery_cuocs")]
    public class LotteryBet : BaseBetLogEntity
    {
        public LotteryChoices Choices { get; set; }
    }
}
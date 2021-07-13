using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    public class KenoSoccerBet : BaseBetLogEntity
    {
        public string Choice { get; set; }

        public decimal Amount { get; set; }
    }

    [CollectionName("mydinh_cuocs")]
    public class KenoSoccerMyDinhBet : KenoSoccerBet
    {
    }

    [CollectionName("hangday_cuocs")]
    public class KenoSoccerHangDayBet : KenoSoccerBet
    {
    }

    [CollectionName("thongnhat_cuocs")]
    public class KenoSoccerThongNhatBet : KenoSoccerBet
    {
    }
}
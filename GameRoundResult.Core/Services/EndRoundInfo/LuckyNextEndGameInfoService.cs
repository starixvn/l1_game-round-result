using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class LuckyNext1EndGameInfoService: BaseDrawEndGameInfoService<LuckyNext1Round, LuckyNext1Bet, LuckyNextRoundResult, LuckyNextSettlementResult>
    {
        public LuckyNext1EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }

    public class LuckyNext2EndGameInfoService : BaseDrawEndGameInfoService<LuckyNext2Round, LuckyNext2Bet, LuckyNextRoundResult, LuckyNextSettlementResult>
    {
        public LuckyNext2EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
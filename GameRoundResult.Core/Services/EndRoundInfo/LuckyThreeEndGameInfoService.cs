using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class LuckyThreeEndGameInfoService : BaseDrawEndGameInfoService<LuckyThreeRound, LuckyThreeBet, LuckyThreeRoundResult, LuckyThreeSettlementResult>
    {
        public LuckyThreeEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
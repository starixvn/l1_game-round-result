using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SicBallEndGameInfoService : BaseDrawEndGameInfoService<SicBallRound, SicBallBet, SicBallRoundResult, SicBallSettlementResult>
    {
        public SicBallEndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
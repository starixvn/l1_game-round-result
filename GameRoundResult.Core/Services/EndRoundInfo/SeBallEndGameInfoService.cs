using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services.EndRoundInfo;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SeBall1EndGameInfoService : BaseDrawEndGameInfoService<SeBall1Round, SeBall1Bet, SeBallRoundResult, SeBallSettlementResult>
    {
        public SeBall1EndGameInfoService(IMongoDatabase database) : base(database)
        {
        }
    }
}
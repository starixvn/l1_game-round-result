using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using MongoDB.Driver;

namespace GameRoundResult.Core.Services
{
    public class SlotGameEndGameInfoService : RoundOnlyEndGameInfoService<SlotGameRound>, IEndGameInfoService
    {
        private readonly IGameConfigsRepository gameConfigsRepository;
        private readonly IMongoDatabase database;

        public SlotGameEndGameInfoService(IMongoDatabase database, IGameConfigsRepository gameConfigsRepository) : base(database)
        {
            this.gameConfigsRepository = gameConfigsRepository;
            this.database = database;
        }

        public async Task<EndRoundInfoResult> GetAsync(RetrieveEndGameInfoRequest request)
        {
            var round = await GetRoundAsync(request);

            if (round == null)
            {
                return EndRoundInfoError.SB1001;
            }

            if (!round.Paid)
            {
                return EndRoundInfoError.SB1005;
            }

            return new EndRoundInfoResult
            {
                EndTime = round.EndTime,
                ValidBetAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalAmount = round.FreeSpin ? 0 : round.TotalAmount,
                TotalWin = round.BetWin
            };
        }

        protected override async Task<SlotGameRound> GetRoundAsync(RetrieveEndGameInfoRequest request)
        {
            var gameConfigs = await gameConfigsRepository.GetByIdAsync(request.GameTypeId);

            if (gameConfigs != null)
            {
                var collection = database.GetCollection<SlotGameRound>($"{gameConfigs.Name}{gameConfigs.RoundCollectionSuffix}");
                var expression = GetRoundFilterExpression(request);

                var roundEntity = await collection.Find(expression).FirstOrDefaultAsync();

                return roundEntity;
            }

            return null;
        }

        protected override Expression<Func<SlotGameRound, bool>> GetRoundFilterExpression(RetrieveEndGameInfoRequest request)
            => (round) => round.RoundId == request.GameRoundId
            && round.PlayerId == request.PlayerId
            && round.SiteId == request.SiteId
            && round.OperatorId == request.OperatorId;
    }
}
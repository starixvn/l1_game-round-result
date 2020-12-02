using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameRoundResultService
    {
        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<SeDieRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<FishPrawnCrabRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<BaccaratRound>)> GetBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMax2RoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMiniRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoMini2RoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoEastRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoWestRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoSouthRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<KenoRound>)> GetKenoNorthRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<RouletteRound>)> GetRouletteRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<VipSeDieRound>)> GetVipSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<SpecialSeDieRound>)> GetSpecialSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<VipFishPrawnCrabRound>)> GetVipFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize);

        Task<(long, IEnumerable<SicBoRound>)> GetSicBoRoundResultAsync(DateTime date, long roundId, int page, int pageSize);
        Task<(long, IEnumerable<VipSeDieWarRound>)> GetVipSeDieWarRoundResultAsync(DateTime date, long roundId, int page, int pageSize);
        Task<(long, IEnumerable<VipBaccaratRound>)> GetVipBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize);
    }

    public class GameRoundResultService : IGameRoundResultService
    {
        private readonly IGameRoundRepository repository;

        public GameRoundResultService(IGameRoundRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetBigSmallRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<BigSmallRound>)> GetBigSmallTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetBigSmallTurboRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<DragonTigerRound>)> GetDragonTigerRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetDragonTigerRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<FishPrawnCrabRound>)> GetFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetFishPrawnRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoProMaxRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetOddEvenRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<OddEvenRound>)> GetOddEvenTurboRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetOddEvenTurboRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<SeDieRound>)> GetShakeThePlateRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetShakeThePlateRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<MiniSeDieRound>)> GetMiniSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetMiniSeDieRoundResultAsync(date, roundId, page, pageSize);

        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoProVietRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoProVietRoundResult(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<BaccaratRound>)> GetBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetBaccaratRoundResult(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMaxRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoMaxRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMax2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoMax2RoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMiniRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoMiniRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoMini2RoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoMini2RoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoEastRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoEastRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoWestRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoWestRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoSouthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoSouthRoundResultAsync(date, roundId, page, pageSize);

        }

        public async Task<(long, IEnumerable<KenoRound>)> GetKenoNorthRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetKenoNorthRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<RouletteRound>)> GetRouletteRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetRouletteRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<VipSeDieRound>)> GetVipSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetVipSeDieRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<SpecialSeDieRound>)> GetSpecialSeDieRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetSpecialSeDieRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<VipFishPrawnCrabRound>)> GetVipFishPrawnRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetVipFishPrawnRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<SicBoRound>)> GetSicBoRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetSicBoRoundResultAsync(date, roundId, page, pageSize);
        }
        
        public async Task<(long, IEnumerable<VipSeDieWarRound>)> GetVipSeDieWarRoundResultAsync(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetVipSeDieWarRoundResultAsync(date, roundId, page, pageSize);
        }

        public async Task<(long, IEnumerable<VipBaccaratRound>)> GetVipBaccaratRoundResult(DateTime date, long roundId, int page, int pageSize)
        {
            return await repository.GetVipBaccaratRoundResult(date, roundId, page, pageSize);
        }
    }
}

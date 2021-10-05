using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGameBetService
    {
        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId);

        Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId);

        Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId);

        Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId, bool freeBet);

        Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId);

        Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId);

        Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabAsync(long roundId, int memberId);

        Task<(BaccaratRound, BaccaratBet)> GetBaccaratAsync(long roundId, int memberId);

        Task<(KenoRound, KenoProMaxBet)> GetKenoProMaxAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoProVietAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMaxAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMax2Async(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMiniAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMini2Async(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoEastAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoWestAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoSouthAsync(long roundId, int memberId);

        Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoNorthAsync(long roundId, int memberId);

        Task<(RouletteRound, IEnumerable<RouletteBet>, RouletteOne)> GetRouletteAsync(long roundId, int memberId);

        Task<(VipSeDieRound, VipSeDieBet)> GetVipSeDieAsync(long roundId, int memberId);

        Task<(BlackjackRound, BlackjackBet)> GetBlackjackAsync(long handId, int memberId);

        Task<(SpecialSeDieRound, IEnumerable<SpecialSeDieBet>, SpecialSeDieOne)> GetSpecialSeDieAsync(long roundId, int memberId);

        Task<(VipFishPrawnCrabRound, VipFishPrawnCrabBet)> GetVipFishPrawnCrabAsync(long roundId, int memberId);

        Task<(SicBoRound, IEnumerable<SicBoBet>, SicBoOne)> GetSicBoAsync(long roundId, int memberId);

        Task<(VipSeDieWarRound, IEnumerable<VipSeDieWarBet>, VipSeDieWarOne)> GetVipSeDieWarAsync(long roundId, int memberId);

        Task<(VipBaccaratRound, BaccaratBet)> GetVipBaccaratAsync(long roundId, int memberId);

        Task<FourGuardiansRound> GetFourGuardiansAsync(long roundId, int memberId);


        Task<(LotteryRound, IEnumerable<LotteryBet>, LotteryOne)> GetLotteryAsync(long roundId, int memberId);

        Task<(ThreeCardsRound, ThreeCardsBet)> GetThreeCardsAsync(long roundId, int memberId);

        Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId);

        Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>)> GetBitcoinMasterAsync(long roundId, int memberId);
    }

    public class GameBetService : IGameBetService
    {
        private readonly IGameBetRepository repository;

        public GameBetService(IGameBetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId)
        {
            return await repository.GetBigSmallAsync(roundId, memberId);
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId)
        {
            return await repository.GetBigSmallTurboAsync(roundId, memberId);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId)
        {
            return await repository.GetOddEvenAsync(roundId, memberId);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId)
        {
            return await repository.GetOddEvenTurboAsync(roundId, memberId);
        }

        public async Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId, bool freeBet)
        {
            return await repository.GetSeDieAsync(roundId, memberId, freeBet);
        }

        public async Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId)
        {
            return await repository.GetMiniSeDieAsync(roundId, memberId);
        }

        public async Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId)
        {
            return await repository.GetDragonTigerAsync(roundId, memberId);
        }

        public async Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabAsync(long roundId, int memberId)
        {
            return await repository.GetFishPrawnCrabAsync(roundId, memberId);
        }

        public async Task<(BaccaratRound, BaccaratBet)> GetBaccaratAsync(long roundId, int memberId)
        {
            return await repository.GetBaccaratAsync(roundId, memberId);
        }

        public async Task<(KenoRound, KenoProMaxBet)> GetKenoProMaxAsync(long roundId, int memberId)
        {
            return await repository.GetKenoProMaxAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoProVietAsync(long roundId, int memberId)
        {
            return await repository.GetKenoProVietAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMaxAsync(long roundId, int memberId)
        {
            return await repository.GetKenoMaxAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMax2Async(long roundId, int memberId)
        {
            return await repository.GetKenoMax2Async(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMiniAsync(long roundId, int memberId)
        {
            return await repository.GetKenoMiniAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMini2Async(long roundId, int memberId)
        {
            return await repository.GetKenoMini2Async(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoEastAsync(long roundId, int memberId)
        {
            return await repository.GetKenoEastAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoWestAsync(long roundId, int memberId)
        {
            return await repository.GetKenoWestAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoSouthAsync(long roundId, int memberId)
        {
            return await repository.GetKenoSouthAsync(roundId, memberId);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoNorthAsync(long roundId, int memberId)
        {
            return await repository.GetKenoNorthAsync(roundId, memberId);
        }

        public async Task<(RouletteRound, IEnumerable<RouletteBet>, RouletteOne)> GetRouletteAsync(long roundId, int memberId)
        {
            return await repository.GetRouletteAsync(roundId, memberId);
        }

        public async Task<(VipSeDieRound, VipSeDieBet)> GetVipSeDieAsync(long roundId, int memberId)
        {
            return await repository.GetVipSeDieAsync(roundId, memberId);
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetBlackjackAsync(long handId, int memberId)
        {
            return await repository.GetBlackjackAsync(handId, memberId);
        }

        public async Task<(SpecialSeDieRound, IEnumerable<SpecialSeDieBet>, SpecialSeDieOne)> GetSpecialSeDieAsync(long roundId, int memberId)
        {
            return await repository.GetSpecialSeDieAsync(roundId, memberId);
        }

        public async Task<(VipFishPrawnCrabRound, VipFishPrawnCrabBet)> GetVipFishPrawnCrabAsync(long roundId, int memberId)
        {
            return await repository.GetVipFishPrawnCrabAsync(roundId, memberId);
        }

        public async Task<(SicBoRound, IEnumerable<SicBoBet>, SicBoOne)> GetSicBoAsync(long roundId, int memberId)

        {
            return await repository.GetSicBoAsync(roundId, memberId);
        }

        public async Task<FourGuardiansRound> GetFourGuardiansAsync(long roundId, int memberId)
        {
            return await repository.GetFourGuardiansAsync(roundId, memberId);
        }

        public async Task<(VipSeDieWarRound, IEnumerable<VipSeDieWarBet>, VipSeDieWarOne)> GetVipSeDieWarAsync(long roundId, int memberId)
        {
            return await repository.GetVipSeDieWarAsync(roundId, memberId);
        }

        public async Task<(VipBaccaratRound, BaccaratBet)> GetVipBaccaratAsync(long roundId, int memberId)
        {
            return await repository.GetVipBaccaratAsync(roundId, memberId);
        }

        public async Task<(LotteryRound, IEnumerable<LotteryBet>, LotteryOne)> GetLotteryAsync(long roundId, int memberId)
        {
            return await repository.GetLotteryAsync(roundId, memberId);
        }

        public async Task<(ThreeCardsRound, ThreeCardsBet)> GetThreeCardsAsync(long roundId, int memberId)
        {
            return await repository.GetThreeCardsAsync(roundId, memberId);
        }

        public async Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId)
        {
            return await repository.GetHeroesSlotAsync(roundId, memberId);
        }

        public async Task<(BitcoinMasterRound, IEnumerable<BitcoinMasterBet>)> GetBitcoinMasterAsync(long roundId, int memberId)
        {
            return await repository.GetBitcoinMasterAsync(roundId, memberId);
        }
    }
}
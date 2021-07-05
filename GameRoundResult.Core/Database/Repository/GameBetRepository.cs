using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Extensions;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface IGameBetRepository
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


        Task<FourGuardiansRound> GetFourGuardiansAsync(long roundId, int memberId);
        Task<(VipBaccaratRound, BaccaratBet)> GetVipBaccaratAsync(long roundId, int memberId);

        Task<(LotteryRound, IEnumerable<LotteryBet>, LotteryOne)> GetLotteryAsync(long roundId, int memberId);

        Task<(ThreeCardsRound, ThreeCardsBet)> GetThreeCardsAsync(long roundId, int memberId);

        Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId);
    }

    public class GameBetRepository : IGameBetRepository
    {
        private readonly IMongoDatabase database;

        public GameBetRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        private async Task<IEnumerable<T>> GetBetsAsync<T>(long roundId, int memberId, string collectionName, Expression<Func<T, bool>> filter = null) where T : BaseBetEntity
        {
            Expression<Func<T, bool>> defaultExpression = bet => bet.MemberId == memberId && bet.Round == roundId;

            return await database
                .GetCollection<T>(collectionName)
                .Find(filter == null ? defaultExpression : defaultExpression.And(filter))
                .SortByDescending(x => x.Id)
                .ToListAsync();
        }

        private async Task<T> GetRoundAsync<T>(long roundId, string collectionName) where T : GameRound
            => await database.GetCollection<T>(collectionName).Find(x => x.Round == roundId).FirstOrDefaultAsync();

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BigSmallRound>(roundId, MiniGameRoundCollections.BigSmallRound);
            var bets = await GetBetsAsync<BigSmallBet>(roundId, memberId, MiniGameBetCollections.BigSmallBet);

            return (round, bets);
        }

        public async Task<(BigSmallRound, IEnumerable<BigSmallBet>)> GetBigSmallTurboAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BigSmallRound>(roundId, MiniGameRoundCollections.BigSmallTurboRound);
            var bets = await GetBetsAsync<BigSmallBet>(roundId, memberId, MiniGameBetCollections.BigSmallTurboBet);

            return (round, bets);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<OddEvenRound>(roundId, MiniGameRoundCollections.OddEvenRound);
            var bets = await GetBetsAsync<OddEvenBet>(roundId, memberId, MiniGameBetCollections.OddEvenBet);

            return (round, bets);
        }

        public async Task<(OddEvenRound, IEnumerable<OddEvenBet>)> GetOddEvenTurboAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<OddEvenRound>(roundId, MiniGameRoundCollections.OddEvenTurboRound);
            var bets = await GetBetsAsync<OddEvenBet>(roundId, memberId, MiniGameBetCollections.OddEvenTurboBet);

            return (round, bets);
        }

        public async Task<(SeDieRound, SeDieBet)> GetSeDieAsync(long roundId, int memberId, bool freeBet)
        {
            var round = await GetRoundAsync<SeDieRound>(roundId, MiniGameRoundCollections.SeDieRound);
            var bets = (await GetBetsAsync<SeDieBet>(roundId, memberId, MiniGameBetCollections.SeDieBet, x => !x.FreeBet.HasValue || x.FreeBet == freeBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(MiniSeDieRound, MiniSeDieBet)> GetMiniSeDieAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<MiniSeDieRound>(roundId, MiniGameRoundCollections.MiniSeDieRound);
            var bets = (await GetBetsAsync<MiniSeDieBet>(roundId, memberId, MiniGameBetCollections.MiniSeDieBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(DragonTigerRound, DragonTigerBet)> GetDragonTigerAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<DragonTigerRound>(roundId, MiniGameRoundCollections.DragonTigerRound);
            var bets = (await GetBetsAsync<DragonTigerBet>(roundId, memberId, MiniGameBetCollections.DragonTigetBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(FishPrawnCrabRound, FishPrawnCrabBet)> GetFishPrawnCrabAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<FishPrawnCrabRound>(roundId, MiniGameRoundCollections.FishPrawnRound);
            var bets = (await GetBetsAsync<FishPrawnCrabBet>(roundId, memberId, MiniGameBetCollections.FishPrawnCrabBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(BaccaratRound, BaccaratBet)> GetBaccaratAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<BaccaratRound>(roundId, MiniGameRoundCollections.BaccaratRound);
            var bets = (await GetBetsAsync<BaccaratBet>(roundId, memberId, MiniGameBetCollections.BaccaratBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(KenoRound, KenoProMaxBet)> GetKenoProMaxAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoProMaxRound);
            var bets = (await GetBetsAsync<KenoProMaxBet>(roundId, memberId, MiniGameBetCollections.KenoProMaxBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoProVietAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoProVietRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoProVietOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoProVietBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMaxAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoMaxRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoMaxOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoMaxBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMax2Async(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoMax2Round);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoMax2Ones)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoMax2Bet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMiniAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoMiniRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoMiniOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoMiniBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoMini2Async(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoMini2Round);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoMini2Ones)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoMini2Bet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoEastAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoEastRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoEastOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoEastBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoWestAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoWestRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoWestOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoWestBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoSouthAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoSouthRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoSouthOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoSouthBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(KenoRound, IEnumerable<RNGKenoBet>, decimal?)> GetKenoNorthAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<KenoRound>(roundId, MiniGameRoundCollections.KenoNorthRound);
            var ones = (await GetBetsAsync<RNGKenoOnes>(roundId, memberId, MiniGameBetCollections.KenoNorthOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RNGKenoBet>(MiniGameBetCollections.KenoNorthBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones?.Betwin);
        }

        public async Task<(RouletteRound, IEnumerable<RouletteBet>, RouletteOne)> GetRouletteAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<RouletteRound>(roundId, MiniGameRoundCollections.RouletteRound);
            var ones = (await GetBetsAsync<RouletteOne>(roundId, memberId, MiniGameBetCollections.RouletteOnes)).FirstOrDefault();
            var bets = await database.GetCollection<RouletteBet>(MiniGameBetCollections.RouletteBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones);
        }

        public async Task<(VipSeDieRound, VipSeDieBet)> GetVipSeDieAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<VipSeDieRound>(roundId, MiniGameRoundCollections.VipSeDieRound);
            var bet = (await GetBetsAsync<VipSeDieBet>(roundId, memberId, MiniGameBetCollections.VipSeDieBet)).FirstOrDefault();

            return (round, bet);
        }

        public async Task<(BlackjackRound, BlackjackBet)> GetBlackjackAsync(long handId, int memberId)
        {
            var bet = await database.GetCollection<BlackjackBet>(MiniGameBetCollections.BlackjackBet).Find(x => x.HandId == handId && x.MemberId == memberId)
                .SortByDescending(x => x.Id).FirstOrDefaultAsync();

            if (bet != null)
            {
                var round = await GetRoundAsync<BlackjackRound>(bet.Round, MiniGameRoundCollections.BlackjackRound);

                return (round, bet);
            }

            return (null, bet);
        }

        public async Task<(SpecialSeDieRound, IEnumerable<SpecialSeDieBet>, SpecialSeDieOne)> GetSpecialSeDieAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<SpecialSeDieRound>(roundId, MiniGameRoundCollections.SpecialSeDieRound);
            var ones = (await GetBetsAsync<SpecialSeDieOne>(roundId, memberId, MiniGameBetCollections.SpecialSeDieOnes)).FirstOrDefault();
            var bets = await database.GetCollection<SpecialSeDieBet>(MiniGameBetCollections.SpecialSeDieBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones);
        }

        public async Task<(VipFishPrawnCrabRound, VipFishPrawnCrabBet)> GetVipFishPrawnCrabAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<VipFishPrawnCrabRound>(roundId, MiniGameRoundCollections.VipFishPrawnCrabRound);
            var bet = (await GetBetsAsync<VipFishPrawnCrabBet>(roundId, memberId, MiniGameBetCollections.VipFishPrawnCrabBet)).FirstOrDefault();

            return (round, bet);
        }

        public async Task<(SicBoRound, IEnumerable<SicBoBet>, SicBoOne)> GetSicBoAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<SicBoRound>(roundId, MiniGameRoundCollections.SicBoRound);
            var ones = (await GetBetsAsync<SicBoOne>(roundId, memberId, MiniGameBetCollections.SicBoOnes)).FirstOrDefault();
            var bets = await database.GetCollection<SicBoBet>(MiniGameBetCollections.SicBoBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones);
        }

        public async Task<(VipSeDieWarRound, IEnumerable<VipSeDieWarBet>, VipSeDieWarOne)> GetVipSeDieWarAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<VipSeDieWarRound>(roundId, MiniGameRoundCollections.VipSeDieWarRound);
            var ones = (await GetBetsAsync<VipSeDieWarOne>(roundId, memberId, MiniGameBetCollections.VipSeDieWarOnes)).FirstOrDefault();
            var bets = await database.GetCollection<VipSeDieWarBet>(MiniGameBetCollections.VipSeDieWarBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones);
        }

        public async Task<FourGuardiansRound> GetFourGuardiansAsync(long roundId, int memberId)
        {
            return await database.GetCollection<FourGuardiansRound>(MiniGameRoundCollections.FourGuardianRounds)
                .Find(x => x.Round == roundId && x.MemberId == memberId).FirstOrDefaultAsync();
        }

        public async Task<(VipBaccaratRound, BaccaratBet)> GetVipBaccaratAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<VipBaccaratRound>(roundId, MiniGameRoundCollections.VipBaccaratRound);
            var bets = (await GetBetsAsync<BaccaratBet>(roundId, memberId, MiniGameBetCollections.VipBaccaratBet)).FirstOrDefault();

            return (round, bets);
        }

       

        public async Task<(LotteryRound, IEnumerable<LotteryBet>, LotteryOne)> GetLotteryAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<LotteryRound>(roundId, MiniGameRoundCollections.LotteryRound);
            var ones = (await GetBetsAsync<LotteryOne>(roundId, memberId, MiniGameBetCollections.LotteryOnes)).FirstOrDefault();
            var bets = await database.GetCollection<LotteryBet>(MiniGameBetCollections.LotteryBet)
                .Find(x => x.Round == roundId && x.MemberId == memberId).SortByDescending(x => x.Id).ToListAsync();

            return (round, bets, ones);
        }

        public async Task<(ThreeCardsRound, ThreeCardsBet)> GetThreeCardsAsync(long roundId, int memberId)
        {
            var round = await GetRoundAsync<ThreeCardsRound>(roundId, MiniGameRoundCollections.ThreeCardsRound);
            var bets = (await GetBetsAsync<ThreeCardsBet>(roundId, memberId, MiniGameBetCollections.ThreeCardsBet)).FirstOrDefault();

            return (round, bets);
        }

        public async Task<HeroesSlotRound> GetHeroesSlotAsync(long roundId, int memberId)
        {
            return await database.GetCollection<HeroesSlotRound>(MiniGameRoundCollections.HeroesSlotRounds)
                .Find(x => x.Round == roundId && x.MemberId == memberId).FirstOrDefaultAsync();
        }
    }
}

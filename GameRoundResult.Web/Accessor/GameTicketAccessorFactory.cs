using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameTicketAccessorFactory
    {
        IGameTicketAccessor GetService(GameType game);
    }

    public class GameTicketAccessorFactory : IGameTicketAccessorFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.BigSmall, typeof(BigSmallTicketAccessor<BigSmallRound, BigSmallOne, BigSmallBet>) },
            { GameType.SeDie, typeof(SeDieTicketAccessor) },
            { GameType.FishPrawnCrab, typeof(FishPrawnCrabTicketAccessor) },
            { GameType.BigSmallTurbo, typeof(BigSmallTicketAccessor<TurboBigSmallRound, TurboBigSmallOne, TurboBigSmallBet>) },
            { GameType.OddEvenTurbo, typeof(OddEvenTicketAccessor) },
            { GameType.DragonTiger, typeof(DragonTigerTicketAccessor) },
            { GameType.KenoProMax, typeof(KenoProMaxTicketAccessor) },
            { GameType.MiniSeDie, typeof(MiniSeDieTicketAccessor) },
            { GameType.Baccarat, typeof(BaccaratTicketAccessor<BaccaratRound, BaccaratBet>) },
            { GameType.VipBaccarat, typeof(BaccaratTicketAccessor<VipBaccaratRound, VipBaccaratBet>) },
            { GameType.BlockchainBaccarat, typeof(BaccaratTicketAccessor<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
            { GameType.KenoMax, typeof(MiniKenoTicketAccessor<KenoMaxRound, KenoMaxOne, KenoMaxBet>) },
            { GameType.KenoMax2, typeof(MiniKenoTicketAccessor<KenoMax2Round, KenoMax2One, KenoMax2Bet>) },
            { GameType.KenoMini, typeof(MiniKenoTicketAccessor<KenoMiniRound, KenoMiniOne, KenoMiniBet>) },
            { GameType.KenoMini2, typeof(MiniKenoTicketAccessor<KenoMini2Round, KenoMini2One, KenoMini2Bet>) },
            { GameType.KenoEast, typeof(MiniKenoTicketAccessor<KenoEastRound, KenoEastOne, KenoEastBet>) },
            { GameType.KenoWest, typeof(MiniKenoTicketAccessor<KenoWestRound, KenoWestOne, KenoWestBet>) },
            { GameType.KenoSouth, typeof(MiniKenoTicketAccessor<KenoSouthRound, KenoSouthOne, KenoSouthBet>) },
            { GameType.KenoNorth, typeof(MiniKenoTicketAccessor<KenoNorthRound, KenoNorthOne, KenoNorthBet>) },
            { GameType.Roulette, typeof(RouletteTicketAccessor) },
            { GameType.VipSeDie, typeof(VipSeDieTicketAccessor) },
            { GameType.Blackjack, typeof(BlackjackTicketAccessor) },
            { GameType.SpecialSeDie, typeof(SpecialSeDieTicketAccessor) },
            { GameType.SicBo, typeof(SicBoTicketAccessor) },
            { GameType.VipFishPrawnCrab, typeof(VipFishPrawnCrabTicketAccessor) },
            { GameType.SeDieWar, typeof(VipSeDieWarTicketAccessor) },
            { GameType.Lottery, typeof(LotteryTicketAccessor) },
            { GameType.ThreeCards, typeof(ThreeCardsTicketAccessor) },
            { GameType.KenoMatch1, typeof(KenoMatchTicketAccessor<KenoMatch1Round, KenoMatch1One, KenoMatch1Bet>) },
            { GameType.KenoMatch2, typeof(KenoMatchTicketAccessor<KenoMatch2Round, KenoMatch2One, KenoMatch2Bet>) },
            { GameType.KenoPower1, typeof(KenoPowerTicketAccessor<KenoPower1Round, KenoPower1One, KenoPower1Bet>) },
            { GameType.KenoPower2, typeof(KenoPowerTicketAccessor<KenoPower2Round, KenoPower2One, KenoPower2Bet>) },
            { GameType.HeroesSlot, typeof(FourGuardiansTicketAccessor<HeroesSlotRound>) },
            { GameType.FourGuardians, typeof(FourGuardiansTicketAccessor<FourGuardiansRound>) },
            { GameType.BitcoinMaster, typeof(BitcoinMasterTicketAccessor) },
            { GameType.CasinoHoldemPoker, typeof(CasinoHoldemPokerTicketAccessor) },
            { GameType.TexasHoldemPoker, typeof(TexasHoldemPokerTicketAccessor) },
            { GameType.HiLo, typeof(HiLoTicketAccessor) },
            { GameType.NightClub, typeof(FourGuardiansTicketAccessor<NightClubRound>) },
            { GameType.TreasureIsland, typeof(BaseCascadingSlotTicketAccessor<TreasureIslandRound, TreasureIslandTotalMultiplier>)}
        };

        private readonly IServiceProvider serviceProvider;

        public GameTicketAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameTicketAccessor GetService(GameType game)
            => (IGameTicketAccessor)serviceProvider.GetRequiredService(services[game]);
    }
}
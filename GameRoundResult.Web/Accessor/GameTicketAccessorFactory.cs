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
        IGameTicketAccessor GetSlotGameService();
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
            { GameType.MiniSeDie, typeof(MiniSeDieTicketAccessor<MiniSeDieRound, MiniSeDieBet>) },
            { GameType.Baccarat, typeof(BaccaratTicketAccessor<BaccaratRound, BaccaratBet>) },
            { GameType.VipBaccarat, typeof(BaccaratTicketAccessor<VipBaccaratRound, VipBaccaratBet>) },
            { GameType.BlockchainBaccarat, typeof(BaccaratTicketAccessor<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
            { GameType.KenoMax, typeof(MiniKenoTicketAccessor<KenoMaxRound, KenoMaxOne>) },
            { GameType.KenoMax2, typeof(MiniKenoTicketAccessor<KenoMax2Round, KenoMax2One>) },
            { GameType.KenoMini, typeof(MiniKenoTicketAccessor<KenoMiniRound, KenoMiniOne>) },
            { GameType.KenoMini2, typeof(MiniKenoTicketAccessor<KenoMini2Round, KenoMini2One>) },
            { GameType.KenoEast, typeof(MiniKenoTicketAccessor<KenoEastRound, KenoEastOne>) },
            { GameType.KenoWest, typeof(MiniKenoTicketAccessor<KenoWestRound, KenoWestOne>) },
            { GameType.KenoSouth, typeof(MiniKenoTicketAccessor<KenoSouthRound, KenoSouthOne>) },
            { GameType.KenoNorth, typeof(MiniKenoTicketAccessor<KenoNorthRound, KenoNorthOne>) },
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
            { GameType.HeroesSlot, typeof(SlotGameTicketAccessor) },
            { GameType.FourGuardians, typeof(SlotGameTicketAccessor) },
            { GameType.BitcoinMaster, typeof(BitcoinMasterTicketAccessor) },
            { GameType.CasinoHoldemPoker, typeof(CasinoHoldemPokerTicketAccessor) },
            { GameType.TexasHoldemPoker, typeof(TexasHoldemPokerTicketAccessor) },
            { GameType.HiLo, typeof(HiLoTicketAccessor) },
            { GameType.NightClub, typeof(SlotGameTicketAccessor) },
            { GameType.TreasureIsland, typeof(BaseCascadingSlotTicketAccessor<TreasureIslandRound, TreasureIslandTotalMultiplier>)},
            { GameType.WayToGoal, typeof(SlotGameTicketAccessor) },
            { GameType.MegaKeno, typeof(MiniKenoTicketAccessor<MegaKenoRound, MegaKenoOne>) },
            { GameType.MegaKeno2, typeof(MiniKenoTicketAccessor<MegaKeno2Round, MegaKeno2One>) },
            { GameType.UnbalancedBigSmall1, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall1Round, UnbalancedBigSmall1Bet, UnbalancedBigSmall1BetLog>) },
            { GameType.UnbalancedBigSmall2, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall2Round, UnbalancedBigSmall2Bet, UnbalancedBigSmall2BetLog>) },
            { GameType.UnbalancedBigSmall3, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall3Round, UnbalancedBigSmall3Bet, UnbalancedBigSmall3BetLog>) },
            { GameType.UnbalancedBigSmall4, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall4Round, UnbalancedBigSmall4Bet, UnbalancedBigSmall4BetLog>) },
            { GameType.MiniSeDie2, typeof(MiniSeDieTicketAccessor<MiniSeDie2Round, MiniSeDie2Bet>) },
            { GameType.MiniSeDie3, typeof(MiniSeDieTicketAccessor<MiniSeDie3Round, MiniSeDie3Bet>) },
            { GameType.MiniSeDie4, typeof(MiniSeDieTicketAccessor<MiniSeDie4Round, MiniSeDie4Bet>) },
            { GameType.FruitSlot, typeof(FruitSlotTicketAccessor<FruitSlotRound, FruitSlotBet, FruitSlotBetLog>) },
        };

        private readonly IServiceProvider serviceProvider;

        public GameTicketAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameTicketAccessor GetService(GameType game)
            => (IGameTicketAccessor)serviceProvider.GetRequiredService(services[game]);


        public IGameTicketAccessor GetSlotGameService()
            => serviceProvider.GetService<SlotGameTicketAccessor>();
    }
}
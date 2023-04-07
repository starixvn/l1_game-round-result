using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.CascadingSlotGames;
using GameRoundResult.Web.SlotGames.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameTicketAccessorFactory
    {
        IGameTicketAccessor GetService(GameId gameId, GameType gameType);
    }

    public class GameTicketAccessorFactory : IGameTicketAccessorFactory
    {
        private readonly Dictionary<GameId, Type> services = new()
        {
            { GameId.BigSmall, typeof(BigSmallTicketAccessor<BigSmallRound, BigSmallOne, BigSmallBet>) },
            { GameId.SeDie, typeof(SeDieTicketAccessor) },
            { GameId.FishPrawnCrab, typeof(FishPrawnCrabTicketAccessor) },
            { GameId.BigSmallTurbo, typeof(BigSmallTicketAccessor<TurboBigSmallRound, TurboBigSmallOne, TurboBigSmallBet>) },
            { GameId.OddEvenTurbo, typeof(OddEvenTicketAccessor) },
            { GameId.DragonTiger, typeof(DragonTigerTicketAccessor) },
            { GameId.KenoProMax, typeof(KenoProMaxTicketAccessor) },
            { GameId.MiniSeDie, typeof(MiniSeDieTicketAccessor<MiniSeDieRound, MiniSeDieBet>) },
            { GameId.Baccarat, typeof(BaccaratTicketAccessor<BaccaratRound, BaccaratBet>) },
            { GameId.VipBaccarat, typeof(BaccaratTicketAccessor<VipBaccaratRound, VipBaccaratBet>) },
            { GameId.BlockchainBaccarat, typeof(BaccaratTicketAccessor<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
            { GameId.KenoMax, typeof(MiniKenoTicketAccessor<KenoMaxRound, KenoMaxOne>) },
            { GameId.KenoMax2, typeof(MiniKenoTicketAccessor<KenoMax2Round, KenoMax2One>) },
            { GameId.KenoMini, typeof(MiniKenoTicketAccessor<KenoMiniRound, KenoMiniOne>) },
            { GameId.KenoMini2, typeof(MiniKenoTicketAccessor<KenoMini2Round, KenoMini2One>) },
            { GameId.KenoEast, typeof(MiniKenoTicketAccessor<KenoEastRound, KenoEastOne>) },
            { GameId.KenoWest, typeof(MiniKenoTicketAccessor<KenoWestRound, KenoWestOne>) },
            { GameId.KenoSouth, typeof(MiniKenoTicketAccessor<KenoSouthRound, KenoSouthOne>) },
            { GameId.KenoNorth, typeof(MiniKenoTicketAccessor<KenoNorthRound, KenoNorthOne>) },
            { GameId.Roulette, typeof(RouletteTicketAccessor) },
            { GameId.VipSeDie, typeof(VipSeDieTicketAccessor) },
            { GameId.Blackjack, typeof(BlackjackTicketAccessor) },
            { GameId.SpecialSeDie, typeof(SpecialSeDieTicketAccessor) },
            { GameId.SicBo, typeof(SicBoTicketAccessor) },
            { GameId.VipFishPrawnCrab, typeof(VipFishPrawnCrabTicketAccessor) },
            { GameId.SeDieWar, typeof(VipSeDieWarTicketAccessor) },
            { GameId.Lottery, typeof(LotteryTicketAccessor) },
            { GameId.ThreeCards, typeof(ThreeCardsTicketAccessor) },
            { GameId.KenoMatch1, typeof(KenoMatchTicketAccessor<KenoMatch1Round, KenoMatch1One, KenoMatch1Bet>) },
            { GameId.KenoMatch2, typeof(KenoMatchTicketAccessor<KenoMatch2Round, KenoMatch2One, KenoMatch2Bet>) },
            { GameId.KenoPower1, typeof(KenoPowerTicketAccessor<KenoPower1Round, KenoPower1One, KenoPower1Bet>) },
            { GameId.KenoPower2, typeof(KenoPowerTicketAccessor<KenoPower2Round, KenoPower2One, KenoPower2Bet>) },
            { GameId.BitcoinMaster, typeof(BitcoinMasterTicketAccessor) },
            { GameId.CasinoHoldemPoker, typeof(CasinoHoldemPokerTicketAccessor) },
            { GameId.TexasHoldemPoker, typeof(TexasHoldemPokerTicketAccessor) },
            { GameId.HiLo, typeof(HiLoTicketAccessor) },
            { GameId.MegaKeno, typeof(MiniKenoTicketAccessor<MegaKenoRound, MegaKenoOne>) },
            { GameId.MegaKeno2, typeof(MiniKenoTicketAccessor<MegaKeno2Round, MegaKeno2One>) },
            { GameId.UnbalancedBigSmall1, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall1Round, UnbalancedBigSmall1Bet, UnbalancedBigSmall1BetLog>) },
            { GameId.UnbalancedBigSmall2, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall2Round, UnbalancedBigSmall2Bet, UnbalancedBigSmall2BetLog>) },
            { GameId.UnbalancedBigSmall3, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall3Round, UnbalancedBigSmall3Bet, UnbalancedBigSmall3BetLog>) },
            { GameId.UnbalancedBigSmall4, typeof(UnbalancedBigSmallTicketAccessor<UnbalancedBigSmall4Round, UnbalancedBigSmall4Bet, UnbalancedBigSmall4BetLog>) },
            { GameId.MiniSeDie2, typeof(MiniSeDieTicketAccessor<MiniSeDie2Round, MiniSeDie2Bet>) },
            { GameId.MiniSeDie3, typeof(MiniSeDieTicketAccessor<MiniSeDie3Round, MiniSeDie3Bet>) },
            { GameId.MiniSeDie4, typeof(MiniSeDieTicketAccessor<MiniSeDie4Round, MiniSeDie4Bet>) },
            { GameId.FruitSlot, typeof(FruitSlotTicketAccessor<FruitSlotRound, FruitSlotBet, FruitSlotBetLog>) },
            { GameId.FanTan, typeof(FanTanTicketAccessor) },
            { GameId.WinThreeCards, typeof(Win3CardsTicketAccessor) },
        };

        private readonly Dictionary<GameType, Type> servicesOnType = new()
        {
            {GameType.Slot, typeof(SlotGameHandler) },
            {GameType.CascadingSlot, typeof(CascadingSlotTicketHandler) }
        };

        private readonly IServiceProvider serviceProvider;

        public GameTicketAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameTicketAccessor GetService(GameId gameId, GameType gameType)
            => services.ContainsKey(gameId)
                ? (IGameTicketAccessor)serviceProvider.GetRequiredService(services[gameId])
                : serviceProvider.GetRequiredService(servicesOnType[gameType]) as IGameTicketAccessor;
    }
}
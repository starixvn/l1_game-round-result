using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.CascadingSlotGames;
using GameRoundResult.Web.SlotGames;

namespace GameRoundResult.Web.Services
{
    public interface IEndGameInfoServiceFactory
    {
        IEndGameInfoService GetService(GameId game, GameType gameType);
    }

    public class EndGameInfoServiceFactory : IEndGameInfoServiceFactory
    {
        private readonly Dictionary<GameId, Type> services = new()
        {
            { GameId.BigSmall, typeof(BigSmallEndGameInfoService) },
            { GameId.BigSmallTurbo, typeof(BigSmallTurboEndGameInfoService) },
            { GameId.OddEvenTurbo, typeof(OddEvenTurboEndGameInfoService) },
            { GameId.FishPrawnCrab, typeof(FishPrawnCrabEndGameInfoService) },
            { GameId.SeDie, typeof(SeDieEndGameInfoService) },
            { GameId.MiniSeDie, typeof(MiniSeDieEndGameInfoService<MiniSeDieRound, MiniSeDieBet>) },
            { GameId.DragonTiger, typeof(DragonTigerEndGameInfoService) },
            { GameId.KenoProMax, typeof(KenoProMaxEndGameInfoService) },
            { GameId.Roulette, typeof(RouletteEndGameInfoService) },
            { GameId.VipSeDie, typeof(VipSeDieEndGameInfoService) },
            { GameId.SpecialSeDie, typeof(SpecialSeDieEndGameInfoService) },
            { GameId.Blackjack, typeof(BlackjackEndGameInfoService) },
            { GameId.VipFishPrawnCrab, typeof(VipFishPrawnCrabEndGameInfoService) },
            { GameId.SicBo, typeof(SicBoEndGameInfoService) },
            { GameId.SeDieWar, typeof(VipSeDieWarEndGameInfoService) },
            { GameId.Lottery, typeof(LotteryEndGameInfoService) },
            { GameId.ThreeCards, typeof(ThreeCardsEndGameInfoService) },
            { GameId.BitcoinMaster, typeof(BitcoinMasterEndGameInfoService) },
            { GameId.KenoMatch1, typeof(KenoMatchEndGameInfoService<KenoMatch1Round, KenoMatch1One>) },
            { GameId.KenoMatch2, typeof(KenoMatchEndGameInfoService<KenoMatch2Round, KenoMatch2One>) },
            { GameId.KenoPower1, typeof(KenoPowerEndGameInfoService<KenoPower1Round, KenoPower1One>) },
            { GameId.KenoPower2, typeof(KenoPowerEndGameInfoService<KenoPower2Round, KenoPower2One>) },
            { GameId.CasinoHoldemPoker, typeof(CasinoHoldemPokerEndGameInfoService) },
            { GameId.HiLo, typeof(HiLoEndGameInfoService) },
            { GameId.TexasHoldemPoker, typeof(TexasHoldemPokerEndGameInfoService) },
            { GameId.Baccarat, typeof(BaccaratEndGameInfoService<BaccaratRound, BaccaratBet>) },
            { GameId.VipBaccarat, typeof(BaccaratEndGameInfoService<VipBaccaratRound, VipBaccaratBet>) },
            { GameId.BlockchainBaccarat, typeof(BaccaratEndGameInfoService<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
            { GameId.KenoMax, typeof(MiniKenoEndGameInfoService<KenoMaxRound, KenoMaxOne>) },
            { GameId.KenoMax2, typeof(MiniKenoEndGameInfoService<KenoMax2Round, KenoMax2One>) },
            { GameId.KenoMini, typeof(MiniKenoEndGameInfoService<KenoMiniRound, KenoMiniOne>) },
            { GameId.KenoMini2, typeof(MiniKenoEndGameInfoService<KenoMini2Round, KenoMini2One>) },
            { GameId.KenoEast, typeof(MiniKenoEndGameInfoService<KenoEastRound, KenoEastOne>) },
            { GameId.KenoWest, typeof(MiniKenoEndGameInfoService<KenoWestRound, KenoWestOne>) },
            { GameId.KenoSouth, typeof(MiniKenoEndGameInfoService<KenoSouthRound, KenoSouthOne>) },
            { GameId.KenoNorth, typeof(MiniKenoEndGameInfoService<KenoNorthRound, KenoNorthOne>) },
            { GameId.MegaKeno, typeof(MiniKenoEndGameInfoService<MegaKenoRound, MegaKenoOne>) },
            { GameId.MegaKeno2, typeof(MiniKenoEndGameInfoService<MegaKeno2Round, MegaKeno2One>) },
            { GameId.UnbalancedBigSmall1, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall1Round, UnbalancedBigSmall1Bet>) },
            { GameId.UnbalancedBigSmall2, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall2Round, UnbalancedBigSmall2Bet>) },
            { GameId.UnbalancedBigSmall3, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall3Round, UnbalancedBigSmall3Bet>) },
            { GameId.UnbalancedBigSmall4, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall4Round, UnbalancedBigSmall4Bet>) },
            { GameId.MiniSeDie2, typeof(MiniSeDieEndGameInfoService<MiniSeDie2Round, MiniSeDie2Bet>) },
            { GameId.MiniSeDie3, typeof(MiniSeDieEndGameInfoService<MiniSeDie3Round, MiniSeDie3Bet>) },
            { GameId.MiniSeDie4, typeof(MiniSeDieEndGameInfoService<MiniSeDie4Round, MiniSeDie4Bet>) },
            { GameId.FruitSlot, typeof(FruitSlotEndGameInfoService) },
            { GameId.FanTan, typeof(FanTanEndGameInfoService) },
            { GameId.WinThreeCards, typeof(Win3CardsEndGameInfoService) },
        };

        private readonly Dictionary<GameType, Type> servicesOnType = new()
        {
            { GameType.Slot, typeof(SlotGameEndRoundInfoService)},
            { GameType.CascadingSlot, typeof(CascadingSlotGameEndRoundInfoService)}
        };


        private readonly IServiceProvider serviceProvider;

        public EndGameInfoServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEndGameInfoService GetService(GameId game, GameType gameType)
        => services.ContainsKey(game)
            ? serviceProvider.GetService(services[game]) as IEndGameInfoService
           : serviceProvider.GetService(servicesOnType[gameType]) as IEndGameInfoService;
    }
}
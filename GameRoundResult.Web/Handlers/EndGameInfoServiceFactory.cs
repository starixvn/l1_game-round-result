using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.SlotGames;

namespace GameRoundResult.Web.Services
{
    public interface IEndGameInfoServiceFactory
    {
        IEndGameInfoService GetService(GameType game);
    }

    public class EndGameInfoServiceFactory : IEndGameInfoServiceFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.BigSmall, typeof(BigSmallEndGameInfoService) },
            { GameType.BigSmallTurbo, typeof(BigSmallTurboEndGameInfoService) },
            { GameType.OddEvenTurbo, typeof(OddEvenTurboEndGameInfoService) },
            { GameType.FishPrawnCrab, typeof(FishPrawnCrabEndGameInfoService) },
            { GameType.SeDie, typeof(SeDieEndGameInfoService) },
            { GameType.MiniSeDie, typeof(MiniSeDieEndGameInfoService<MiniSeDieRound, MiniSeDieBet>) },
            { GameType.DragonTiger, typeof(DragonTigerEndGameInfoService) },
            { GameType.KenoProMax, typeof(KenoProMaxEndGameInfoService) },
            { GameType.Roulette, typeof(RouletteEndGameInfoService) },
            { GameType.VipSeDie, typeof(VipSeDieEndGameInfoService) },
            { GameType.SpecialSeDie, typeof(SpecialSeDieEndGameInfoService) },
            { GameType.Blackjack, typeof(BlackjackEndGameInfoService) },
            { GameType.VipFishPrawnCrab, typeof(VipFishPrawnCrabEndGameInfoService) },
            { GameType.SicBo, typeof(SicBoEndGameInfoService) },
            { GameType.SeDieWar, typeof(VipSeDieWarEndGameInfoService) },
            { GameType.Lottery, typeof(LotteryEndGameInfoService) },
            { GameType.ThreeCards, typeof(ThreeCardsEndGameInfoService) },
            { GameType.BitcoinMaster, typeof(BitcoinMasterEndGameInfoService) },
            { GameType.KenoMatch1, typeof(KenoMatchEndGameInfoService<KenoMatch1Round, KenoMatch1One>) },
            { GameType.KenoMatch2, typeof(KenoMatchEndGameInfoService<KenoMatch2Round, KenoMatch2One>) },
            { GameType.KenoPower1, typeof(KenoPowerEndGameInfoService<KenoPower1Round, KenoPower1One>) },
            { GameType.KenoPower2, typeof(KenoPowerEndGameInfoService<KenoPower2Round, KenoPower2One>) },
            { GameType.CasinoHoldemPoker, typeof(CasinoHoldemPokerEndGameInfoService) },
            { GameType.HiLo, typeof(HiLoEndGameInfoService) },
            { GameType.TexasHoldemPoker, typeof(TexasHoldemPokerEndGameInfoService) },
            { GameType.TreasureIsland, typeof(TreasureIslandEndRoundInfoService) },
            { GameType.Baccarat, typeof(BaccaratEndGameInfoService<BaccaratRound, BaccaratBet>) },
            { GameType.VipBaccarat, typeof(BaccaratEndGameInfoService<VipBaccaratRound, VipBaccaratBet>) },
            { GameType.BlockchainBaccarat, typeof(BaccaratEndGameInfoService<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
            { GameType.KenoMax, typeof(MiniKenoEndGameInfoService<KenoMaxRound, KenoMaxOne>) },
            { GameType.KenoMax2, typeof(MiniKenoEndGameInfoService<KenoMax2Round, KenoMax2One>) },
            { GameType.KenoMini, typeof(MiniKenoEndGameInfoService<KenoMiniRound, KenoMiniOne>) },
            { GameType.KenoMini2, typeof(MiniKenoEndGameInfoService<KenoMini2Round, KenoMini2One>) },
            { GameType.KenoEast, typeof(MiniKenoEndGameInfoService<KenoEastRound, KenoEastOne>) },
            { GameType.KenoWest, typeof(MiniKenoEndGameInfoService<KenoWestRound, KenoWestOne>) },
            { GameType.KenoSouth, typeof(MiniKenoEndGameInfoService<KenoSouthRound, KenoSouthOne>) },
            { GameType.KenoNorth, typeof(MiniKenoEndGameInfoService<KenoNorthRound, KenoNorthOne>) },
            { GameType.MegaKeno, typeof(MiniKenoEndGameInfoService<MegaKenoRound, MegaKenoOne>) },
            { GameType.MegaKeno2, typeof(MiniKenoEndGameInfoService<MegaKeno2Round, MegaKeno2One>) },
            { GameType.UnbalancedBigSmall1, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall1Round, UnbalancedBigSmall1Bet>) },
            { GameType.UnbalancedBigSmall2, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall2Round, UnbalancedBigSmall2Bet>) },
            { GameType.UnbalancedBigSmall3, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall3Round, UnbalancedBigSmall3Bet>) },
            { GameType.UnbalancedBigSmall4, typeof(UnbalancedBigSmallEndGameInfoService<UnbalancedBigSmall4Round, UnbalancedBigSmall4Bet>) },
            { GameType.MiniSeDie2, typeof(MiniSeDieEndGameInfoService<MiniSeDie2Round, MiniSeDie2Bet>) },
            { GameType.MiniSeDie3, typeof(MiniSeDieEndGameInfoService<MiniSeDie3Round, MiniSeDie3Bet>) },
            { GameType.MiniSeDie4, typeof(MiniSeDieEndGameInfoService<MiniSeDie4Round, MiniSeDie4Bet>) },
            { GameType.FruitSlot, typeof(FruitSlotEndGameInfoService) },
            { GameType.FanTan, typeof(FanTanEndGameInfoService) },
            { GameType.Win3Cards, typeof(Win3CardsEndGameInfoService) },
        };

        private readonly IServiceProvider serviceProvider;

        public EndGameInfoServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEndGameInfoService GetService(GameType game)
        => services.ContainsKey(game)
            ? serviceProvider.GetService(services[game]) as IEndGameInfoService
           : serviceProvider.GetService(typeof(SlotGameEndRoundInfoService)) as IEndGameInfoService;
    }
}
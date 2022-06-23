using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;

namespace GameRoundResult.Core.Services
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
            { GameType.MiniSeDie, typeof(MiniSeDieEndGameInfoService) },
            { GameType.DragonTiger, typeof(DragonTigerEndGameInfoService) },
            { GameType.KenoProMax, typeof(KenoProMaxEndGameInfoService) },
            { GameType.KenoMax, typeof(KenoMaxEndGameInfoService) },
            { GameType.KenoMax2, typeof(KenoMax2EndGameInfoService) },
            { GameType.KenoMini, typeof(KenoMiniEndGameInfoService) },
            { GameType.KenoMini2, typeof(KenoMini2EndGameInfoService) },
            { GameType.KenoEast, typeof(KenoEastEndGameInfoService) },
            { GameType.KenoWest, typeof(KenoWestEndGameInfoService) },
            { GameType.KenoSouth, typeof(KenoSouthEndGameInfoService) },
            { GameType.KenoNorth, typeof(KenoNorthEndGameInfoService) },
            { GameType.Roulette, typeof(RouletteEndGameInfoService) },
            { GameType.VipSeDie, typeof(VipSeDieEndGameInfoService) },
            { GameType.SpecialSeDie, typeof(SpecialSeDieEndGameInfoService) },
            { GameType.Blackjack, typeof(BlackjackEndGameInfoService) },
            { GameType.VipFishPrawnCrab, typeof(VipFishPrawnCrabEndGameInfoService) },
            { GameType.SicBo, typeof(SicBoEndGameInfoService) },
            { GameType.SeDieWar, typeof(VipSeDieWarEndGameInfoService) },
            { GameType.FourGuardians, typeof(FourGuardiansEndGameInfoService) },
            { GameType.Lottery, typeof(LotteryEndGameInfoService) },
            { GameType.ThreeCards, typeof(ThreeCardsEndGameInfoService) },
            { GameType.HeroesSlot, typeof(HeroesSlotEndGameInfoService) },
            { GameType.BitcoinMaster, typeof(BitcoinMasterEndGameInfoService) },
            { GameType.KenoMatch1, typeof(KenoMatchEndGameInfoService<KenoMatch1Round, KenoMatch1One>) },
            { GameType.KenoMatch2, typeof(KenoMatchEndGameInfoService<KenoMatch2Round, KenoMatch2One>) },
            { GameType.KenoPower1, typeof(KenoPowerEndGameInfoService<KenoPower1Round, KenoPower1One>) },
            { GameType.KenoPower2, typeof(KenoPowerEndGameInfoService<KenoPower2Round, KenoPower2One>) },
            { GameType.CasinoHoldemPoker, typeof(CasinoHoldemPokerEndGameInfoService) },
            { GameType.HiLo, typeof(HiLoEndGameInfoService) },
            { GameType.TexasHoldemPoker, typeof(TexasHoldemPokerEndGameInfoService) },
            { GameType.NightClub, typeof(NightClubEndRoundInfoService) },
            { GameType.TreasureIsland, typeof(TreasureIslandEndRoundInfoService)}
            { GameType.Baccarat, typeof(BaccaratEndGameInfoService<BaccaratRound, BaccaratBet>) },
            { GameType.VipBaccarat, typeof(BaccaratEndGameInfoService<VipBaccaratRound, VipBaccaratBet>) },
            { GameType.BlockchainBaccarat, typeof(BaccaratEndGameInfoService<BlockchainBaccaratRound, BlockchainBaccaratBet>) },
        };

        private readonly IServiceProvider serviceProvider;

        public EndGameInfoServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEndGameInfoService GetService(GameType game)
        => serviceProvider.GetService(services[game]) as IEndGameInfoService;
    }
}
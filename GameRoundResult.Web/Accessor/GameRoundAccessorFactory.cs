using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameRoundAccessorFactory
    {
        IGameRoundAccessor GetService(GameType game);
    }

    public class GameRoundAccessorFactory : IGameRoundAccessorFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.BigSmall, typeof(GameRoundAccessor<BigSmallRound, BigSmallRoundResultViewModel>) },
            { GameType.SeDie, typeof(GameRoundAccessor<SeDieRound, SeDieRoundResultViewModel>) },
            { GameType.FishPrawnCrab, typeof(GameRoundAccessor<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>) },
            { GameType.BigSmallTurbo, typeof(GameRoundAccessor<TurboBigSmallRound, BigSmallRoundResultViewModel>) },
            { GameType.OddEvenTurbo, typeof(GameRoundAccessor<TurboOddEvenRound, OddEvenRoundResultViewModel>) },
            { GameType.DragonTiger, typeof(GameRoundAccessor<DragonTigerRound, DragonTigerRoundResultViewModel>) },
            { GameType.KenoProMax, typeof(GameRoundAccessor<KenoProMaxRound, KenoRoundResultViewModel>) },
            { GameType.MiniSeDie, typeof(GameRoundAccessor<MiniSeDieRound, MiniSeDieRoundResultViewModel>) },
            { GameType.Baccarat, typeof(GameRoundAccessor<BaccaratRound, BaccaratRoundResultViewModel>) },
            { GameType.KenoMax, typeof(GameRoundAccessor<KenoMaxRound, KenoRoundResultViewModel>) },
            { GameType.KenoMax2, typeof(GameRoundAccessor<KenoMax2Round, KenoRoundResultViewModel>) },
            { GameType.KenoMini, typeof(GameRoundAccessor<KenoMiniRound, KenoRoundResultViewModel>) },
            { GameType.KenoMini2, typeof(GameRoundAccessor<KenoMini2Round, KenoRoundResultViewModel>) },
            { GameType.KenoEast, typeof(GameRoundAccessor<KenoEastRound, KenoRoundResultViewModel>) },
            { GameType.KenoWest, typeof(GameRoundAccessor<KenoWestRound, KenoRoundResultViewModel>) },
            { GameType.KenoSouth, typeof(GameRoundAccessor<KenoSouthRound, KenoRoundResultViewModel>) },
            { GameType.KenoNorth, typeof(GameRoundAccessor<KenoNorthRound, KenoRoundResultViewModel>) },
            { GameType.Roulette, typeof(GameRoundAccessor<RouletteRound, RouletteRoundResultViewModel>) },
            { GameType.VipSeDie, typeof(GameRoundAccessor<VipSeDieRound, VipSeDieRoundResultViewModel>) },
            { GameType.SpecialSeDie, typeof(GameRoundAccessor<SpecialSeDieRound, SpecialSeDieRoundResultViewModel>) },
            { GameType.SicBo, typeof(GameRoundAccessor<SicBoRound, SicBoRoundResultViewModel>) },
            { GameType.VipFishPrawnCrab, typeof(GameRoundAccessor<VipFishPrawnCrabRound, VipFishPrawnCrabRoundResultViewModel>) },
            { GameType.VipBaccarat, typeof(GameRoundAccessor<VipBaccaratRound, BaccaratRoundResultViewModel>) },
            { GameType.SeDieWar, typeof(GameRoundAccessor<VipSeDieWarRound, VipSeDieWarRoundResultViewModel>) },
            { GameType.Lottery, typeof(GameRoundAccessor<LotteryRound, LotteryRoundResultViewModel>) },
            { GameType.ThreeCards, typeof(GameRoundAccessor<ThreeCardsRound, ThreeCardsRoundResultViewModel>) },
            { GameType.KenoMatch1, typeof(KenoMatchRoundAccessor<KenoMatch1Round>) },
            { GameType.KenoMatch2, typeof(KenoMatchRoundAccessor<KenoMatch2Round>) },
            { GameType.KenoPower1, typeof(KenoPowerRoundAccessor<KenoPower1Round>) },
            { GameType.KenoPower2, typeof(KenoPowerRoundAccessor<KenoPower2Round>) },
            { GameType.BitcoinMaster, typeof(GameRoundAccessor<BitcoinMasterRound, BitcoinMasterRoundResultViewModel>) },
            { GameType.BlockchainBaccarat, typeof(GameRoundAccessor<BlockchainBaccaratRound, BaccaratRoundResultViewModel>) },
            { GameType.MegaKeno, typeof(GameRoundAccessor<MegaKenoRound, KenoRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall1, typeof(GameRoundAccessor<UnbalancedBigSmall1Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall2, typeof(GameRoundAccessor<UnbalancedBigSmall2Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall3, typeof(GameRoundAccessor<UnbalancedBigSmall3Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall4, typeof(GameRoundAccessor<UnbalancedBigSmall4Round, BigSmallRoundResultViewModel>) },
            { GameType.MegaKeno2, typeof(GameRoundAccessor<MegaKeno2Round, KenoRoundResultViewModel>) },
        };

        private readonly IServiceProvider serviceProvider;

        public GameRoundAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameRoundAccessor GetService(GameType game)
        => (IGameRoundAccessor)serviceProvider.GetRequiredService(services[game]);
    }
}
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
        IGameRoundAccessor GetService(GameId game);
    }

    public class GameRoundAccessorFactory : IGameRoundAccessorFactory
    {
        private readonly Dictionary<GameId, Type> services = new()
        {
            { GameId.BigSmall, typeof(GameRoundAccessor<BigSmallRound, BigSmallRoundResultViewModel>) },
            { GameId.SeDie, typeof(GameRoundAccessor<SeDieRound, SeDieRoundResultViewModel>) },
            { GameId.FishPrawnCrab, typeof(GameRoundAccessor<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>) },
            { GameId.BigSmallTurbo, typeof(GameRoundAccessor<TurboBigSmallRound, BigSmallRoundResultViewModel>) },
            { GameId.OddEvenTurbo, typeof(GameRoundAccessor<TurboOddEvenRound, OddEvenRoundResultViewModel>) },
            { GameId.DragonTiger, typeof(GameRoundAccessor<DragonTigerRound, DragonTigerRoundResultViewModel>) },
            { GameId.KenoProMax, typeof(GameRoundAccessor<KenoProMaxRound, KenoRoundResultViewModel>) },
            { GameId.MiniSeDie, typeof(GameRoundAccessor<MiniSeDieRound, MiniSeDieRoundResultViewModel>) },
            { GameId.Baccarat, typeof(GameRoundAccessor<BaccaratRound, BaccaratRoundResultViewModel>) },
            { GameId.KenoMax, typeof(GameRoundAccessor<KenoMaxRound, KenoRoundResultViewModel>) },
            { GameId.KenoMax2, typeof(GameRoundAccessor<KenoMax2Round, KenoRoundResultViewModel>) },
            { GameId.KenoMini, typeof(GameRoundAccessor<KenoMiniRound, KenoRoundResultViewModel>) },
            { GameId.KenoMini2, typeof(GameRoundAccessor<KenoMini2Round, KenoRoundResultViewModel>) },
            { GameId.KenoEast, typeof(GameRoundAccessor<KenoEastRound, KenoRoundResultViewModel>) },
            { GameId.KenoWest, typeof(GameRoundAccessor<KenoWestRound, KenoRoundResultViewModel>) },
            { GameId.KenoSouth, typeof(GameRoundAccessor<KenoSouthRound, KenoRoundResultViewModel>) },
            { GameId.KenoNorth, typeof(GameRoundAccessor<KenoNorthRound, KenoRoundResultViewModel>) },
            { GameId.Roulette, typeof(GameRoundAccessor<RouletteRound, RouletteRoundResultViewModel>) },
            { GameId.VipSeDie, typeof(GameRoundAccessor<VipSeDieRound, VipSeDieRoundResultViewModel>) },
            { GameId.SpecialSeDie, typeof(GameRoundAccessor<SpecialSeDieRound, SpecialSeDieRoundResultViewModel>) },
            { GameId.SicBo, typeof(GameRoundAccessor<SicBoRound, SicBoRoundResultViewModel>) },
            { GameId.VipFishPrawnCrab, typeof(GameRoundAccessor<VipFishPrawnCrabRound, VipFishPrawnCrabRoundResultViewModel>) },
            { GameId.VipBaccarat, typeof(GameRoundAccessor<VipBaccaratRound, BaccaratRoundResultViewModel>) },
            { GameId.SeDieWar, typeof(GameRoundAccessor<VipSeDieWarRound, VipSeDieWarRoundResultViewModel>) },
            { GameId.Lottery, typeof(GameRoundAccessor<LotteryRound, LotteryRoundResultViewModel>) },
            { GameId.ThreeCards, typeof(GameRoundAccessor<ThreeCardsRound, ThreeCardsRoundResultViewModel>) },
            { GameId.KenoMatch1, typeof(KenoMatchRoundAccessor<KenoMatch1Round>) },
            { GameId.KenoMatch2, typeof(KenoMatchRoundAccessor<KenoMatch2Round>) },
            { GameId.KenoPower1, typeof(KenoPowerRoundAccessor<KenoPower1Round>) },
            { GameId.KenoPower2, typeof(KenoPowerRoundAccessor<KenoPower2Round>) },
            { GameId.BitcoinMaster, typeof(GameRoundAccessor<BitcoinMasterRound, BitcoinMasterRoundResultViewModel>) },
            { GameId.BlockchainBaccarat, typeof(GameRoundAccessor<BlockchainBaccaratRound, BaccaratRoundResultViewModel>) },
            { GameId.MegaKeno, typeof(GameRoundAccessor<MegaKenoRound, KenoRoundResultViewModel>) },
            { GameId.MegaKeno2, typeof(GameRoundAccessor<MegaKeno2Round, KenoRoundResultViewModel>) },
            { GameId.UnbalancedBigSmall1, typeof(GameRoundAccessor<UnbalancedBigSmall1Round, BigSmallRoundResultViewModel>) },
            { GameId.UnbalancedBigSmall2, typeof(GameRoundAccessor<UnbalancedBigSmall2Round, BigSmallRoundResultViewModel>) },
            { GameId.UnbalancedBigSmall3, typeof(GameRoundAccessor<UnbalancedBigSmall3Round, BigSmallRoundResultViewModel>) },
            { GameId.UnbalancedBigSmall4, typeof(GameRoundAccessor<UnbalancedBigSmall4Round, BigSmallRoundResultViewModel>) },
            { GameId.MiniSeDie2, typeof(GameRoundAccessor<MiniSeDie2Round, MiniSeDieRoundResultViewModel>) },
            { GameId.MiniSeDie3, typeof(GameRoundAccessor<MiniSeDie3Round, MiniSeDieRoundResultViewModel>) },
            { GameId.MiniSeDie4, typeof(GameRoundAccessor<MiniSeDie4Round, MiniSeDieRoundResultViewModel>) },
            { GameId.FruitSlot, typeof(GameRoundAccessor<FruitSlotRound, FruitSlotRoundResultViewModel>) },
            { GameId.FanTan, typeof(GameRoundAccessor<FanTanRound, FanTanRoundResultViewModel>) },
            { GameId.WinThreeCards, typeof(GameRoundAccessor<Win3CardsRound, Win3CardsRoundResultViewModel>)},
        };

        private readonly IServiceProvider serviceProvider;

        public GameRoundAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameRoundAccessor GetService(GameId game)
        => (IGameRoundAccessor)serviceProvider.GetRequiredService(services[game]);
    }
}
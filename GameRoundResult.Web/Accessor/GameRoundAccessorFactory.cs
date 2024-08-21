using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.BandarQiuQiu;
using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Core.Database.Entities.ColorGame;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameRoundAccessorFactory
    {
        IGameRoundAccessor GetService(GameType game, bool isCrashGame);
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
            { GameType.MegaKeno2, typeof(GameRoundAccessor<MegaKeno2Round, KenoRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall1, typeof(GameRoundAccessor<UnbalancedBigSmall1Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall2, typeof(GameRoundAccessor<UnbalancedBigSmall2Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall3, typeof(GameRoundAccessor<UnbalancedBigSmall3Round, BigSmallRoundResultViewModel>) },
            { GameType.UnbalancedBigSmall4, typeof(GameRoundAccessor<UnbalancedBigSmall4Round, BigSmallRoundResultViewModel>) },
            { GameType.MiniSeDie2, typeof(GameRoundAccessor<MiniSeDie2Round, MiniSeDieRoundResultViewModel>) },
            { GameType.MiniSeDie3, typeof(GameRoundAccessor<MiniSeDie3Round, MiniSeDieRoundResultViewModel>) },
            { GameType.MiniSeDie4, typeof(GameRoundAccessor<MiniSeDie4Round, MiniSeDieRoundResultViewModel>) },
            { GameType.FruitSlot, typeof(GameRoundAccessor<FruitSlotRound, FruitSlotRoundResultViewModel>) },
            { GameType.FanTan, typeof(GameRoundAccessor<FanTanRound, FanTanRoundResultViewModel>) },
            { GameType.WinThreeCards, typeof(GameRoundAccessor<Win3CardsRound, Win3CardsRoundResultViewModel>)},
            { GameType.DragonTigerFight, typeof(GameRoundAccessor<DragonTigerFightRound, DragonTigerFightRoundResultViewModel>) },
            { GameType.ColorGame, typeof(GameRoundAccessor<ColorGameRound, ColorGameRoundResultViewModel>) },
            { GameType.BandarQiuQiu, typeof(GameRoundAccessor<BandarQiuQiuRound, BandarQiuQiuRoundResultViewModel>) },
            { GameType.FootballDice, typeof(GameRoundAccessor<FootballDiceRound, FootballDiceRoundResultViewModel>) },
            { GameType.FootballSlot, typeof(GameRoundAccessor<FootballSlotRound, FootballSlotRoundResultViewModel>) },
            { GameType.BacBall1, typeof(GameRoundAccessor<BacBall1Round, BacBallRoundResultViewModel>) },
            { GameType.BacBall2, typeof(GameRoundAccessor<BacBall2Round, BacBallRoundResultViewModel>) },
            { GameType.LuckyNext1, typeof(GameRoundAccessor<LuckyNext1Round, LuckyNextRoundResultViewModel>) },
            { GameType.LuckyNext2, typeof(GameRoundAccessor<LuckyNext2Round, LuckyNextRoundResultViewModel>) },
            { GameType.CoinToss, typeof(GameRoundAccessor<CoinTossRound, CoinTossRoundResultViewModel>) },
            { GameType.SeBall1, typeof(GameRoundAccessor<SeBall1Round, SeBallRoundResultViewModel>) },
            { GameType.LuckyThree, typeof(GameRoundAccessor<LuckyThreeRound, LuckyThreeRoundResultViewModel>) },
            { GameType.FootballCoinToss, typeof(GameRoundAccessor<FootballCoinTossRound, FootballCoinTossRoundResultViewModel>) },
            { GameType.Bac81, typeof(GameRoundAccessor<Bac81Round, BaccaratXRoundResultViewModel>) },
            { GameType.SeDie3, typeof(GameRoundAccessor<SeDie3Round, SeDie3RoundResultViewModel>) },
        };

        private readonly IServiceProvider serviceProvider;

        public GameRoundAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGameRoundAccessor GetService(GameType game, bool isCrashGame)
        {
            var serviceType = isCrashGame ? typeof(GameRoundAccessor<CrashGameRound, CrashGameRoundResultViewModel>) : services[game];
            return (IGameRoundAccessor)serviceProvider.GetRequiredService(serviceType);
        }
    }
}
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
            { GameType.Baccarat, typeof(BaccaratTicketAccessor) },
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
            { GameType.SpecialSeDie, typeof(SpecialSeDieTicketAccessor) },
            { GameType.SicBo, typeof(SicBoTicketAccessor) },
            { GameType.VipFishPrawnCrab, typeof(VipFishPrawnCrabTicketAccessor) },
            { GameType.VipBaccarat, typeof(VipBaccaratTicketAccessor) },
            { GameType.SeDieWar, typeof(VipSeDieWarTicketAccessor) },
            { GameType.Lottery, typeof(LotteryTicketAccessor) },
            { GameType.ThreeCards, typeof(ThreeCardsTicketAccessor) },
            { GameType.MyDinh, typeof(KenoSoccerTicketAccessor<KenoSoccerMyDinhRound, KenoSoccerMyDinhOne, KenoSoccerMyDinhBet>) },
            { GameType.HangDay, typeof(KenoSoccerTicketAccessor<KenoSoccerHangDayRound, KenoSoccerHangDayOne, KenoSoccerHangDayBet>) },
            { GameType.ThongNhat, typeof(KenoSoccerTicketAccessor<KenoSoccerThongNhatRound, KenoSoccerThongNhatOne, KenoSoccerThongNhatBet>) },
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
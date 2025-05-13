using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Core.Database.Entities.SevenUpDown;
using GameRoundResult.Core.Database.Entities.RNGSoccer;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Models.RoundHistory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.RoundHistory
{
    public interface IRoundHistoryAccessorFactory
    {
        IRoundHistoryAccessor GetService(GameType game);
    }

    public class RoundHistoryAccessorFactory : IRoundHistoryAccessorFactory
    {
        private readonly Dictionary<GameType, Type> services = new()
        {
            { GameType.CoinToss, typeof(RoundHistoryAccessor<CoinTossRound, CoinTossRoundResultViewModel, CoinTossBet, RoundHistoryBetViewModel>) },
            { GameType.SeBall1, typeof(DrawRoundHistoryAccessor<SeBall1Round, SeBallRoundResultViewModel, SeBall1Bet, RoundHistoryBetViewModel, SeBallRoundResult, SeBallSettlementResult>) },
            { GameType.LuckyThree, typeof(DrawRoundHistoryAccessor<LuckyThreeRound, LuckyThreeRoundResultViewModel, LuckyThreeBet, RoundHistoryBetViewModel, LuckyThreeRoundResult, LuckyThreeSettlementResult>) },
            { GameType.FootballCoinToss, typeof(RoundHistoryAccessor<FootballCoinTossRound, FootballCoinTossRoundResultViewModel, FootballCoinTossBet, RoundHistoryBetViewModel>) },
            { GameType.Bac81, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac82, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac83, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac84, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac85, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac86, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac87, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac88, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac89, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac90, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac91, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac92, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.SeDie3, typeof(RoundHistoryAccessor<SeDie3Round, SeDie3RoundResultViewModel, SeDie3Bet, RoundHistoryBetViewModel>) }, 
            { GameType.KaraKrus, typeof(RoundHistoryAccessor<KaraKrusRound, KaraKrusRoundResultViewModel, KaraKrusBet, RoundHistoryBetViewModel>) },
            { GameType.Bac97, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac98, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac100, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.Bac101, typeof(RoundHistoryAccessor<BaccaratXRound, BaccaratXRoundResultViewModel, BaccaratXBet, RoundHistoryBetViewModel>) },
            { GameType.SevenUpDown, typeof(RoundHistoryAccessor<SevenUpDownRound, SevenUpDownRoundResultViewModel, SevenUpDownBet, RoundHistoryBetViewModel>) },
            { GameType.MarbleFootball, typeof(RoundHistoryAccessor<MarbleFootballRound, MarbleFootballRoundResultViewModel, MarbleFootballBet, RoundHistoryBetViewModel>) },
            { GameType.MarbleFootball2, typeof(RoundHistoryAccessor<MarbleFootball2Round, MarbleFootball2RoundResultViewModel, MarbleFootball2Bet, RoundHistoryBetViewModel>) },
            { GameType.RNGSoccer, typeof(RoundHistoryAccessor<RNGSoccerRound, RNGSoccerRoundResultViewModel, RNGSoccerBet, RoundHistoryBetViewModel>) },
        };

        private readonly IServiceProvider serviceProvider;

        public RoundHistoryAccessorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IRoundHistoryAccessor GetService(GameType game)
        {
            return (IRoundHistoryAccessor)serviceProvider.GetRequiredService(services[game]);
        }
    }
}
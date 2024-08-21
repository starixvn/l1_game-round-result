using System;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Database.Entities.BandarQiuQiu;
using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Core.Database.Entities.ColorGame;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Core.Database.Entities.FootballCoinToss;

namespace GameRoundResult.Web.Extensions
{
    public static class MappingModelExtensions
    {
        public static TViewModel ToViewModel<TRoundEntity, TViewModel>(this TRoundEntity entity, IMapper mapper, TimeSpan timeZoneOffset)
            where TRoundEntity : GameRound where TViewModel : RoundResultViewModel
        {
            return mapper.Map<TRoundEntity, TViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static TBetViewModel ToBetViewModel<TBetEntity, TBetViewModel>(this TBetEntity entity, IMapper mapper, TimeSpan timeZoneOffset)
           where TBetEntity : RoundHistoryBetEntity where TBetViewModel : RoundHistoryBetViewModel
        {
            return mapper.Map<TBetEntity, TBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static TBetLogViewModel ToBetLogViewModel<TBetLogEntity, TBetLogViewModel>(this TBetLogEntity entity, IMapper mapper, TimeSpan timeZoneOffset)
        where TBetLogEntity : BaseBetLogEntity where TBetLogViewModel : BetLogViewModel
        {
            return mapper.Map<TBetLogEntity, TBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static BigSmallBetViewModel ToViewModel(this BigSmallBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BigSmallBet, BigSmallBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static OddEvenBetViewModel ToViewModel(this OddEvenBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<OddEvenBet, OddEvenBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static SeDieBetViewModel ToViewModel(this SeDieBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<SeDieBet, SeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static MiniSeDieBetViewModel ToViewModel(this MiniSeDieBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<MiniSeDieBet, MiniSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static DragonTigerBetViewModel ToViewModel(this DragonTigerBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<DragonTigerBet, DragonTigerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static DragonTigerFightBetLogViewModel ToViewModel(this DragonTigerFightBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<DragonTigerFightBetLog, DragonTigerFightBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static DragonTigerFightRoundResultViewModel ToViewModel(this DragonTigerFightRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<DragonTigerFightRound, DragonTigerFightRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static ColorGameBetLogViewModel ToViewModel(this ColorGameBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<ColorGameBetLog, ColorGameBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BandarQiuQiuBetLogViewModel ToViewModel(this BandarQiuQiuBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BandarQiuQiuBetLog, BandarQiuQiuBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static TranslationBetLogViewModel ToViewModelTicketBetLog<T>(this T entity, IMapper mapper, TimeSpan timeZoneOffset)
            where T : GameDrawBaseBetEntity
        {
            return mapper.Map<T, TranslationBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static T ToViewModelTicketResult<T>(this T entity, IMapper mapper, TimeSpan timeZoneOffset)
            where T : GameDrawResultBase
        {
            return mapper.Map<T, T>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }
	public static FishPrawnCrabBetViewModel ToViewModel(this FishPrawnCrabBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FishPrawnCrabBet, FishPrawnCrabBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BaccaratBetViewModel ToViewModel(this BaccaratBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BaccaratBet, BaccaratBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static KenoProMaxBetViewModel ToViewModel(this KenoProMaxBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<KenoProMaxBet, KenoProMaxBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static RNGKenoBetViewModel ToViewModel(this RNGKenoOnes entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<RNGKenoOnes, RNGKenoBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static RouletteBetViewModel ToViewModel(this RouletteBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<RouletteBet, RouletteBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static VipSeDieBetViewModel ToViewModel(this VipSeDieBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<VipSeDieBet, VipSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static SpecialSeDieBetViewModel ToViewModel(this SpecialSeDieBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<SpecialSeDieBet, SpecialSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BlackjackBetViewModel ToViewModel(this BlackjackBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BlackjackBet, BlackjackBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static VipFishPrawnCrabBetViewModel ToViewModel(this VipFishPrawnCrabBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<VipFishPrawnCrabBet, VipFishPrawnCrabBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static SicBoBetViewModel ToViewModel(this SicBoBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<SicBoBet, SicBoBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static VipSeDieWarBetViewModel ToViewModel(this VipSeDieWarBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<VipSeDieWarBet, VipSeDieWarBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static LotteryBetViewModel ToViewModel(this LotteryBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<LotteryBet, LotteryBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static ThreeCardsBetViewModel ToViewModel(this ThreeCardsBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<ThreeCardsBet, ThreeCardsBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static KenoMatchBetViewModel ToViewModel(this KenoMatchBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<KenoMatchBet, KenoMatchBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static KenoPowerBetViewModel ToViewModel(this KenoPowerBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<KenoPowerBet, KenoPowerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BitcoinMasterRoundResultViewModel ToViewModel(this BitcoinMasterRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BitcoinMasterRound, BitcoinMasterRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BitcoinMasterBetViewModel ToViewModel(this BitcoinMasterBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<BitcoinMasterBet, BitcoinMasterBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static CasinoHoldemPokerBetViewModel ToViewModel(this CasinoHoldemPokerBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<CasinoHoldemPokerBet, CasinoHoldemPokerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                    dest.CallTime = source.CallTime.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static CasinoHoldemPokerDetailBetViewModel ToViewModel(this CasinoHoldemPokerBetSettlementResult entity, IMapper mapper)
        {
            return mapper.Map<CasinoHoldemPokerBetSettlementResult, CasinoHoldemPokerDetailBetViewModel>(entity);
        }

        public static CasinoHoldemPokerRoundResultViewModel ToViewModel(this CasinoHoldemPokerRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<CasinoHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.RoundStartTime.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static TexasHoldemPokerBetViewModel ToViewModel(this TexasHoldemPokerBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<TexasHoldemPokerBet, TexasHoldemPokerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours);
                    dest.CallTime = source.CallTime.AddHours(timeZoneOffset.TotalHours);
                    dest.RiverTime = source.RiverTime.AddHours(timeZoneOffset.TotalHours);
                    dest.TurnTime = source.TurnTime.AddHours(timeZoneOffset.TotalHours);
                });
            });
        }

        public static TexasHoldemPokerDetailBetViewModel ToViewModel(this TexasHoldemPokerBetSettlementResult entity, IMapper mapper)
        {
            return mapper.Map<TexasHoldemPokerBetSettlementResult, TexasHoldemPokerDetailBetViewModel>(entity);
        }

        public static CasinoHoldemPokerRoundResultViewModel ToViewModel(this TexasHoldemPokerRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<CasinoHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.RoundStartTime.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static UnbalancedBigSmallBetLogViewModel ToViewModel(this UnbalancedBigSmallBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<UnbalancedBigSmallBetLog, UnbalancedBigSmallBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FruitSlotRoundResultViewModel ToViewModel(this FruitSlotRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FruitSlotRound, FruitSlotRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FruitSlotBetLogViewModel ToViewModel(this FruitSlotBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FruitSlotBetLog, FruitSlotBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FanTanBetViewModel ToViewModel(this FanTanBet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FanTanBet, FanTanBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static Win3CardsBetLogViewModel ToViewModel(this Win3CardsBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<Win3CardsBetLog, Win3CardsBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static CrashGameBetLogViewModel ToViewModel(this CrashGameBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<CrashGameBetLog, CrashGameBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FootballDiceBetLogViewModel ToViewModel(this FootballDiceBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FootballDiceBetLog, FootballDiceBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FootballSlotRoundResultViewModel ToViewModel(this FootballSlotRound entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FootballSlotRound, FootballSlotRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static FootballSlotBetLogViewModel ToViewModel(this FootballSlotBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FootballSlotBetLog, FootballSlotBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BetLogViewModel ToViewModel(this CoinTossBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<CoinTossBetLog, BetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static BetLogViewModel ToViewModel(this FootballCoinTossBetLog entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<FootballCoinTossBetLog, BetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }

        public static SeDie3BetViewModel ToViewModel(this SeDie3Bet entity, IMapper mapper, TimeSpan timeZoneOffset)
        {
            return mapper.Map<SeDie3Bet, SeDie3BetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(timeZoneOffset.TotalHours));
            });
        }
    }
}
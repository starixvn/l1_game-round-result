using System;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall1;
using GameRoundResult.Core.Database.Entities.BacBall2;
using GameRoundResult.Core.Database.Entities.BandarQiuQiu;
using GameRoundResult.Core.Database.Entities.ColorGame;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Web.CrashGames.ViewModels;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;

namespace GameRoundResult.Web.Extensions
{
    public static class MappingModelExtensions
    {
        public static TViewModel ToViewModel<TRoundEntity, TViewModel>(this TRoundEntity entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
            where TRoundEntity : GameRound where TViewModel : RoundResultViewModel
        {
            return mapper.Map<TRoundEntity, TViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                    dest.TimeZone = timeZoneInfo;
                });
            });
        }

        public static BigSmallBetViewModel ToViewModel(this BigSmallBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BigSmallBet, BigSmallBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static OddEvenBetViewModel ToViewModel(this OddEvenBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<OddEvenBet, OddEvenBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SeDieBetViewModel ToViewModel(this SeDieBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SeDieBet, SeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static MiniSeDieBetViewModel ToViewModel(this MiniSeDieBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<MiniSeDieBet, MiniSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static DragonTigerBetViewModel ToViewModel(this DragonTigerBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<DragonTigerBet, DragonTigerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static DragonTigerFightBetLogViewModel ToViewModel(this DragonTigerFightBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<DragonTigerFightBetLog, DragonTigerFightBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static DragonTigerFightRoundResultViewModel ToViewModel(this DragonTigerFightRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {           
            return mapper.Map<DragonTigerFightRound, DragonTigerFightRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static ColorGameBetLogViewModel ToViewModel(this ColorGameBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<ColorGameBetLog, ColorGameBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BandarQiuQiuBetLogViewModel ToViewModel(this BandarQiuQiuBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BandarQiuQiuBetLog, BandarQiuQiuBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BacBall1BetLogViewModel ToViewModel(this BacBall1BetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BacBall1BetLog, BacBall1BetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BacBall2BetLogViewModel ToViewModel(this BacBall2BetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BacBall2BetLog, BacBall2BetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }


        public static FishPrawnCrabBetViewModel ToViewModel(this FishPrawnCrabBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FishPrawnCrabBet, FishPrawnCrabBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BaccaratBetViewModel ToViewModel(this BaccaratBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BaccaratBet, BaccaratBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static KenoProMaxBetViewModel ToViewModel(this KenoProMaxBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<KenoProMaxBet, KenoProMaxBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static RNGKenoBetViewModel ToViewModel(this RNGKenoOnes entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<RNGKenoOnes, RNGKenoBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static RouletteBetViewModel ToViewModel(this RouletteBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<RouletteBet, RouletteBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipSeDieBetViewModel ToViewModel(this VipSeDieBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipSeDieBet, VipSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SpecialSeDieBetViewModel ToViewModel(this SpecialSeDieBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SpecialSeDieBet, SpecialSeDieBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BlackjackBetViewModel ToViewModel(this BlackjackBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BlackjackBet, BlackjackBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipFishPrawnCrabBetViewModel ToViewModel(this VipFishPrawnCrabBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipFishPrawnCrabBet, VipFishPrawnCrabBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SicBoBetViewModel ToViewModel(this SicBoBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SicBoBet, SicBoBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipSeDieWarBetViewModel ToViewModel(this VipSeDieWarBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipSeDieWarBet, VipSeDieWarBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static LotteryBetViewModel ToViewModel(this LotteryBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<LotteryBet, LotteryBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static ThreeCardsBetViewModel ToViewModel(this ThreeCardsBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<ThreeCardsBet, ThreeCardsBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static KenoMatchBetViewModel ToViewModel(this KenoMatchBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<KenoMatchBet, KenoMatchBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static KenoPowerBetViewModel ToViewModel(this KenoPowerBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<KenoPowerBet, KenoPowerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BitcoinMasterRoundResultViewModel ToViewModel(this BitcoinMasterRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BitcoinMasterRound, BitcoinMasterRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BitcoinMasterBetViewModel ToViewModel(this BitcoinMasterBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BitcoinMasterBet, BitcoinMasterBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                });
            });
        }

        public static CasinoHoldemPokerBetViewModel ToViewModel(this CasinoHoldemPokerBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<CasinoHoldemPokerBet, CasinoHoldemPokerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                    dest.CallTime = TimeZoneInfo.ConvertTimeFromUtc(source.CallTime, timeZoneInfo);
                });
            });
        }

        public static CasinoHoldemPokerDetailBetViewModel ToViewModel(this CasinoHoldemPokerBetSettlementResult entity, IMapper mapper)
        {
            return mapper.Map<CasinoHoldemPokerBetSettlementResult, CasinoHoldemPokerDetailBetViewModel>(entity);
        }

        public static CasinoHoldemPokerRoundResultViewModel ToViewModel(this CasinoHoldemPokerRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<CasinoHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.RoundStartTime, timeZoneInfo));
            });
        }

        public static TexasHoldemPokerBetViewModel ToViewModel(this TexasHoldemPokerBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<TexasHoldemPokerBet, TexasHoldemPokerBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                    dest.CallTime = TimeZoneInfo.ConvertTimeFromUtc(source.CallTime, timeZoneInfo);
                    dest.RiverTime = TimeZoneInfo.ConvertTimeFromUtc(source.RiverTime, timeZoneInfo);
                    dest.TurnTime = TimeZoneInfo.ConvertTimeFromUtc(source.TurnTime, timeZoneInfo);
                });
            });
        }

        public static TexasHoldemPokerDetailBetViewModel ToViewModel(this TexasHoldemPokerBetSettlementResult entity, IMapper mapper)
        {
            return mapper.Map<TexasHoldemPokerBetSettlementResult, TexasHoldemPokerDetailBetViewModel>(entity);
        }

        public static CasinoHoldemPokerRoundResultViewModel ToViewModel(this TexasHoldemPokerRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<CasinoHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.RoundStartTime, timeZoneInfo));
            });
        }

        public static UnbalancedBigSmallBetLogViewModel ToViewModel(this UnbalancedBigSmallBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<UnbalancedBigSmallBetLog, UnbalancedBigSmallBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static FruitSlotRoundResultViewModel ToViewModel(this FruitSlotRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FruitSlotRound, FruitSlotRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static FruitSlotBetLogViewModel ToViewModel(this FruitSlotBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FruitSlotBetLog, FruitSlotBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static FanTanBetViewModel ToViewModel(this FanTanBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FanTanBet, FanTanBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static Win3CardsBetLogViewModel ToViewModel(this Win3CardsBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<Win3CardsBetLog, Win3CardsBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static CrashGameBetLogViewModel ToViewModel(this CrashGameBetLog entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<CrashGameBetLog, CrashGameBetLogViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }
    }
}
using System;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Extensions
{
    public static class MappingModelExtensions
    {
        public static BigSmallRoundResultViewModel ToViewModel(this BigSmallRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BigSmallRound, BigSmallRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static OddEvenRoundResultViewModel ToViewModel(this OddEvenRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<OddEvenRound, OddEvenRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SeDieRoundResultViewModel ToViewModel(this SeDieRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SeDieRound, SeDieRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static FishPrawnCrabRoundResultViewModel ToViewModel(this FishPrawnCrabRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static DragonTigerRoundResultViewModel ToViewModel(this DragonTigerRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<DragonTigerRound, DragonTigerRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static KenoRoundResultViewModel ToViewModel(this KenoRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<KenoRound, KenoRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static MiniSeDieRoundResultViewModel ToViewModel(this MiniSeDieRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<MiniSeDieRound, MiniSeDieRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static BaccaratRoundResultViewModel ToViewModel(this BaccaratRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<BaccaratRound, BaccaratRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static RouletteRoundResultViewModel ToViewModel(this RouletteRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<RouletteRound, RouletteRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipSeDieRoundResultViewModel ToViewModel(this VipSeDieRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipSeDieRound, VipSeDieRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SpecialSeDieRoundResultViewModel ToViewModel(this SpecialSeDieRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SpecialSeDieRound, SpecialSeDieRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipFishPrawnCrabRoundResultViewModel ToViewModel(this VipFishPrawnCrabRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipFishPrawnCrabRound, VipFishPrawnCrabRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static FourGuardiansRoundResultViewModel ToViewModel(this FourGuardiansRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FourGuardiansRound, FourGuardiansRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static SicBoRoundResultViewModel ToViewModel(this SicBoRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<SicBoRound, SicBoRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static VipSeDieWarRoundResultViewModel ToViewModel(this VipSeDieWarRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipSeDieWarRound, VipSeDieWarRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
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

        public static RNGKenoBetViewModel ToViewModel(this RNGKenoBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<RNGKenoBet, RNGKenoBetViewModel>(entity, opts =>
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

        public static BaccaratRoundResultViewModel ToViewModel(this VipBaccaratRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<VipBaccaratRound, BaccaratRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                });
            });
        }

        public static LotteryRoundResultViewModel ToViewModel(this LotteryRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<LotteryRound, LotteryRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                });
            });
        }

        public static LotteryBetViewModel ToViewModel(this LotteryBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<LotteryBet, LotteryBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }

        public static ThreeCardsRoundResultViewModel ToViewModel(this ThreeCardsRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<ThreeCardsRound, ThreeCardsRoundResultViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) =>
                {
                    dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo);
                });
            });
        }

        public static ThreeCardsBetViewModel ToViewModel(this ThreeCardsBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<ThreeCardsBet, ThreeCardsBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }
    }
}
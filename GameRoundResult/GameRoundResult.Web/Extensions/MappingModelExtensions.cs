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

        public static SeDieRoundResultViewModel ToViewModel(this MiniSeDieRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<MiniSeDieRound, SeDieRoundResultViewModel>(entity, opts =>
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

        public static SeDieBetViewModel ToViewModel(this MiniSeDieBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<MiniSeDieBet, SeDieBetViewModel>(entity, opts =>
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

        public static RNGKEnoBetViewModel ToViewModel(this RNGKenoBet entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<RNGKenoBet, RNGKEnoBetViewModel>(entity, opts =>
            {
                opts.AfterMap((source, dest) => dest.Time = TimeZoneInfo.ConvertTimeFromUtc(source.Time, timeZoneInfo));
            });
        }
    }
}
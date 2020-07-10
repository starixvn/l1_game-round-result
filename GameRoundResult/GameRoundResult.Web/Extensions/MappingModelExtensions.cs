using System;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;

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

        public static FishPrawnRoundResultViewModel ToViewModel(this FishPrawnRound entity, IMapper mapper, TimeZoneInfo timeZoneInfo)
        {
            return mapper.Map<FishPrawnRound, FishPrawnRoundResultViewModel>(entity, opts =>
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

        public static CardViewModel ToViewModel(this Card entity)
        {
            return new CardViewModel
            {
                Number = entity.Number,
                Type = entity.Type
            };
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
    }
}
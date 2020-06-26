using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Extensions
{
    public static class MappingModelExtensions
    {
        public static BigSmallRoundResultViewModel ToViewModel(this BigSmallRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new BigSmallRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Dices = new List<byte>
                {
                    entity.FirstDice,
                    entity.SecondDice,
                    entity.ThirdDice,
                }
            };
        }

        public static OddEvenRoundResultViewModel ToViewModel(this OddEvenRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new OddEvenRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Dices = new List<byte>
                {
                    entity.FirstDice,
                    entity.SecondDice,
                    entity.ThirdDice,
                }
            };
        }

        public static SeDieRoundResultViewModel ToViewModel(this ShakeThePlateRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new SeDieRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                RedChips = new List<bool>
                {
                    entity.FirstRedChip,
                    entity.SecondRedChip,
                    entity.ThirdRedChip,
                    entity.FourthRedChip
                }.OrderByDescending(x => x)
            };
        }

        public static FishPrawnRoundResultViewModel ToViewModel(this FishPrawnRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new FishPrawnRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Dices = new List<byte>
                {
                    entity.FirstDice,
                    entity.SecondDice,
                    entity.ThirdDice,
                }
            };
        }

        public static DragonTigerRoundResultViewModel ToViewModel(this DragonTigerRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new DragonTigerRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Dragon = new CardViewModel
                {
                    Number = entity.Dragon.Number,
                    Type = entity.Dragon.Type
                },
                Tiger = new CardViewModel
                {
                    Number = entity.Tiger.Number,
                    Type = entity.Tiger.Type
                }
            };
        }

        public static KenoRoundResultViewModel ToViewModel(this KenoRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new KenoRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Result = entity.Result?.ToList(),
                IsBig = entity.SettlementResult.Big,
                IsEven = entity.SettlementResult.Even,
                IsEarth = entity.SettlementResult.Earth,
                IsFire = entity.SettlementResult.Fire,
                IsGold = entity.SettlementResult.Gold,
                IsWood = entity.SettlementResult.Wood,
                IsWater = entity.SettlementResult.Water
            };
        }

        public static SeDieRoundResultViewModel ToViewModel(this MiniSeDieRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new SeDieRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                RedChips = new List<bool>
                {
                    entity.FirstRedChip,
                    entity.SecondRedChip,
                    entity.ThirdRedChip,
                    entity.FourthRedChip
                }.OrderByDescending(x => x)
            };
        }

        public static BaccaratRoundResultViewModel ToViewModel(this BaccaratRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new BaccaratRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                PlayerCards = entity.Player.ThirdCard != null ?
                    new[] { entity.Player.FirstCard.ToViewModel(), entity.Player.SecondCard.ToViewModel(), entity.Player.ThirdCard.ToViewModel() } :
                    new[] { entity.Player.FirstCard.ToViewModel(), entity.Player.SecondCard.ToViewModel() },
                BankerCards = entity.Banker.ThirdCard != null ?
                    new[] { entity.Banker.FirstCard.ToViewModel(), entity.Banker.SecondCard.ToViewModel(), entity.Banker.ThirdCard?.ToViewModel() } :
                    new[] { entity.Banker.FirstCard.ToViewModel(), entity.Banker.SecondCard.ToViewModel()},
                Player = entity.Result.Player,
                Banker = entity.Result.Banker,
                Tie = entity.Result.Tie,
                Big = entity.Result.Big,
                Small = entity.Result.Small,
                PlayerPair = entity.Result.PlayerPair,
                BankerPair = entity.Result.BankerPair,
                Natural = entity.Result.Natural,
            };
        }

        public static CardViewModel ToViewModel(this Card entity)
        {
            return new CardViewModel
            {
                Number = entity.Number,
                Type = entity.Type
            };
        }
    }
}
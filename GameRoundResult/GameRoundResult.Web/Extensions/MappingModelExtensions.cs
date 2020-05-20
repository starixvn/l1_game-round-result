using System;
using System.Collections.Generic;
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

        public static ShakeThePlateRoundResultViewModel ToViewModel(this ShakeThePlateRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new ShakeThePlateRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                RedChips = new List<bool>
                {
                    entity.FirstRedChip,
                    entity.SecondRedChip,
                    entity.ThirdRedChip,
                    entity.FourthRedChip
                }
            };
        }

        public static FishPrawnRoundResultVIewModel ToViewModel(this FishPrawnRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new FishPrawnRoundResultVIewModel
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

        public static KenoProMaxRoundResultViewModel ToViewModel(this KenoProMaxRound entity, TimeZoneInfo timeZoneInfo)
        {
            return new KenoProMaxRoundResultViewModel
            {
                Round = entity.Round,
                Time = TimeZoneInfo.ConvertTimeFromUtc(entity.Time, timeZoneInfo),
                Result = entity.Result,
                IsBig = entity.SettlementResult.Big,
                IsEven = entity.SettlementResult.Even,
                IsEarth = entity.SettlementResult.Earth,
                IsFire = entity.SettlementResult.Fire,
                IsGold = entity.SettlementResult.Gold,
                IsWood = entity.SettlementResult.Wood,
                IsWater = entity.SettlementResult.Water
            };
        }
    }
}
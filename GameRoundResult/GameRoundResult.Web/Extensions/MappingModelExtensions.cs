using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Extensions
{
    public static class MappingModelExtensions
    {
        public static BigSmallRoundResultViewModel ToViewModel(this BigSmallRound entity)
        {
            return new BigSmallRoundResultViewModel
            {
                Round = entity.Round,
                Time = entity.Time,
                Dice1 = entity.Dice1,
                Dice2 = entity.Dice2,
                Dice3 = entity.Dice3,
            };
        }

        public static OddEvenRoundResultViewModel ToViewModel(this OddEvenRound entity)
        {
            return new OddEvenRoundResultViewModel
            {
                Round = entity.Round,
                Time = entity.Time,
                Dice1 = entity.Dice1,
                Dice2 = entity.Dice2,
                Dice3 = entity.Dice3,
            };
        }
    }
}
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotRoundResultGenerator : Generator<RoundResultModel>
    {
        public override List<RoundResultModel> GetData()
        {
            return new List<RoundResultModel>
            {
                new RoundResultModel (GameType.FruitSlot, 1, "2022-10-25", "FruitSlotRound1"),
            };
        }
    }
}
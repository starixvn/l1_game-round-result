using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotBetHistoryGenerator : Generator<BetHistoryModel>
    {
        public override List<BetHistoryModel> GetData()
        {
            return new List<BetHistoryModel>
            {
                new BetHistoryModel(GameType.FruitSlot, 123, 1, "en-US", "FruitSlotRound1"),
            };
        }
    }
}
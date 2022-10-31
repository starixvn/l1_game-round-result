using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class FruitSlotEndRoundGenerator : Generator<EndRoundModel>
    {
        public override List<EndRoundModel> GetData()
        {
            return new List<EndRoundModel>
            {
                new EndRoundModel(GameType.FruitSlot, 123, 1, 10, 20, 10, new DateTimeOffset(2022, 10, 25, 07, 56, 59, new TimeSpan()), "0", null),
                new EndRoundModel(GameType.FruitSlot, 123, 1000, 0, 0, 0, null, "SB1001", "The game round does not exist."),
            };
        }
    }
}
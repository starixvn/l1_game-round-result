using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallEndRoundGenerator : Generator<EndRoundModel>
    {
        public override List<EndRoundModel> GetData()
        {
            return new List<EndRoundModel>
            {
                new EndRoundModel(GameType.BigSmall, 123, 1, 10, 0, 10, new DateTimeOffset(2022, 11, 1, 08, 0, 0, new TimeSpan()), "0", null),
            };
        }
    }
}
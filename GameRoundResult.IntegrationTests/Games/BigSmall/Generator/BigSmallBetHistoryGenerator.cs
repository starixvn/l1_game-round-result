using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallBetHistoryGenerator : Generator<BetHistoryModel>
    {
        public override List<BetHistoryModel> GetData()
        {
            return new List<BetHistoryModel>
            {
                new BetHistoryModel(GameType.BigSmall, 123, 1, "en-US", "BigSmallRound1"),
                new BetHistoryModel(GameType.BigSmall, 123, 2, "en-US", "BigSmallRound2"),
            };
        }
    }
}
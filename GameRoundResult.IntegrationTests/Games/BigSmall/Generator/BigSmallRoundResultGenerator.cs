using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.IntegrationTests
{
    public class BigSmallRoundResultGenerator : Generator<RoundResultModel>
    {
        public override List<RoundResultModel> GetData()
        {
            return new List<RoundResultModel>
            {
                new RoundResultModel (GameType.BigSmall, 1, "2022-11-01", "BigSmallRound1"),
                new RoundResultModel (GameType.BigSmall, 0, "2022-11-01", "BigSmallRound0"),
            };
        }
    }
}
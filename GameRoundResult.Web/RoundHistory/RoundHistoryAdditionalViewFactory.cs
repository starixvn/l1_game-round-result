using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.RoundHistory
{
    public interface IRoundHistoryAdditionalViewFactory
    {
        string GetView(GameConfigModel gameConfig);
    }

    public class RoundHistoryAdditionalViewFactory : IRoundHistoryAdditionalViewFactory
    {
        private const string baccaratX = "_BaccaratXAdditionalResult";

        public string GetView(GameConfigModel gameConfig)
        {
            return gameConfig.ApplyMultiplier ? baccaratX : string.Empty;
        }
    }
}
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
        private static readonly Dictionary<GameType, string> AdditionalViewDictionary = new()
        {
            { GameType.Bac81, "_BaccaratXAdditionalResult" },
            { GameType.Bac82, "_BaccaratXAdditionalResult" },
            { GameType.Bac83, "_BaccaratXAdditionalResult" },
            { GameType.Bac84, "_BaccaratXAdditionalResult" },
            { GameType.Bac85, "_BaccaratXAdditionalResult" },
            { GameType.Bac86, "_BaccaratXAdditionalResult" },
            { GameType.Bac87, "_BaccaratXAdditionalResult" },
            { GameType.Bac88, "_BaccaratXAdditionalResult" },
            { GameType.Bac89, "_BaccaratXAdditionalResult" },
            { GameType.Bac90, "_BaccaratXAdditionalResult" },
            { GameType.Bac91, "_BaccaratXAdditionalResult" },
            { GameType.Bac92, "_BaccaratXAdditionalResult" },
            { GameType.Bac97, "_BaccaratXAdditionalResult" },
            { GameType.Bac98, "_BaccaratXAdditionalResult" },
            { GameType.Bac100, "_BaccaratXAdditionalResult" },
            { GameType.Bac101, "_BaccaratXAdditionalResult" },
            { GameType.SevenUpDown, "_SevenUpDownAdditionalResult" }
        };

        public string GetView(GameConfigModel gameConfig)
        {
            return gameConfig.ApplyMultiplier &&
                   AdditionalViewDictionary.TryGetValue((GameType)gameConfig.GameId, out var viewName)
                ? viewName
                : string.Empty;
        }
    }
}

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
        private static Dictionary<GameType, string> AdditionalResultMappings()
        {
            var mappings = new Dictionary<GameType, string>();
            AddMappings(mappings, new List<GameType>
            {
                GameType.Bac81, GameType.Bac82, GameType.Bac83, GameType.Bac84,
                GameType.Bac85, GameType.Bac86, GameType.Bac87, GameType.Bac88,
                GameType.Bac89, GameType.Bac90, GameType.Bac91, GameType.Bac92,
                GameType.Bac97, GameType.Bac98, GameType.Bac100, GameType.Bac101
            }, "_BaccaratXAdditionalResult");

            AddMappings(mappings, new List<GameType>
            { GameType.SevenUpDown}, "_SevenUpDownAdditionalResult");
            return mappings;
        }

        private static void AddMappings(Dictionary<GameType, string> mappings, List<GameType> gameTypes, string view)
        {
            foreach (var gameType in gameTypes)
            {
                mappings[gameType] = view;
            }
        }

        private readonly Dictionary<GameType, string> additionalViewDictionary;

        public RoundHistoryAdditionalViewFactory()
        {
            additionalViewDictionary = AdditionalResultMappings();
        }    

        public string GetView(GameConfigModel gameConfig)
        {
            return additionalViewDictionary.TryGetValue((GameType)gameConfig.GameId, out var viewName)
                ? viewName
                : string.Empty;
        }
    }
}
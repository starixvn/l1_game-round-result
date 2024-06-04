using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.RoundHistory
{
    public interface IRoundHistoryAdditionalViewFactory
    {
        string GetView(GameType game);
    }

    public class RoundHistoryAdditionalViewFactory : IRoundHistoryAdditionalViewFactory
    {
        private const string baccaratX = "_BaccaratXAdditionalResult";

        private readonly Dictionary<GameType, string> views = new()
        {
            { GameType.Bac81, baccaratX },
        };

        public string GetView(GameType game)
        {
            return views.ContainsKey(game) ? views[game] : string.Empty;
        }
    }
}
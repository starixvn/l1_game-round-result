using GameRoundResult.Core.Constants;

namespace GameRoundResult.Core.Extensions
{
    public static class StringExtensions
    {
        public static string FormatPlayerId(string operatorId, string siteId, string playerId)
        {
            if (operatorId == Operators.SabaPlay)
            {
                return string.IsNullOrWhiteSpace(siteId) || playerId.Contains($"{siteId}~") ? playerId : $"{siteId}~{playerId}";
            }

            return playerId;
        }
    }
}

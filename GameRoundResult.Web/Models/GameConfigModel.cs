using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameConfigModel
    {
        public int GameId { get; set; }

        public GameType Type { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Enabled { get; set; }

        public Dictionary<string, double> Odds { get; set; }

        public SlotsConfigModel SlotsConfig { get; set; }
    }

    public class SlotsConfigModel
    {
        public JackpotModel Jackpot { get; set; }
    }

    public class JackpotModel
    {
        public bool Enabled { get; set; }

        public bool ExcludeTestCurrency { get; set; }

        public double WinningRatio { get; set; }

        public double PlayerContributionRatio { get; set; }

        public double BotContributionRatio { get; set; }

        public string AllowedCurrency { get; set; }
    }
}
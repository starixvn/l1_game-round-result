using System;

namespace GameRoundResult.Web.Models
{
    public class GameTicketViewModel
    {
        public TimeSpan TimeZoneOffset { get; set; }

        public string TimeOffsetString => $"GMT{TimeZoneOffset.Hours:+#;-#}";

        public bool? FractionalOddsFormat { get; set; }
    }
}
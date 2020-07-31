using System.Globalization;

namespace GameRoundResult.Web.Configuration
{
    public class ViewFormat
    {
        public const string NumberFormat = "#,##0.##";

        public const string TicketDateFormat = "MM/dd/yyyy";

        public const string TicketTimeFormat = "hh:mm:ss tt";

        public const string RoundTimeFormat = "hh:mm tt";

        public const string RoundDateFormat = "MM/dd/yyyy";
    }

    public static class FormatHelper
    {
        public static string Format(this decimal value)
        {
            return value.ToString(ViewFormat.NumberFormat, CultureInfo.InvariantCulture);
        }
    }
}
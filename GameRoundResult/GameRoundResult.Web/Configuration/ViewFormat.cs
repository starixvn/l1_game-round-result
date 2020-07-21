using System.Globalization;

namespace GameRoundResult.Web.Configuration
{
    public class ViewFormat
    {
        public const string DateTimeFormat = "HH:mm dd/MM/yyyy";
        public const string TicketDateTimeFormat = "HH:mm:ss dd/MM/yyyy";
        public const string NumberFormat = "#,##0.##";
    }

    public static class FormatHelper
    {
        public static string Format(this decimal value)
        {
            return value.ToString(ViewFormat.NumberFormat, CultureInfo.InvariantCulture);
        }
    }
}
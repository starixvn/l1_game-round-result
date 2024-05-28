using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models
{
    public abstract class TimeViewModel
    {
        public DateTime Time { get; set; }

        public DateTimeOffset UserTime => TimeZoneInfo.ConvertTimeFromUtc(Time, TimeZone);

        public string DisplayRoundDate => UserTime.RoundDateFormat();

        public string DisplayRoundTime => UserTime.RoundTimeWithSecondFormat();

        public TimeZoneInfo TimeZone { get; set; }
    }

    public class RoundResultViewModel : TimeViewModel
    {
        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public long RoundId { get; set; }

        public long ExchangeRateId { get; set; }

        public virtual IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return new[] { $"{DateDisplay}<br />{Time.ToString(ViewFormat.RoundTimeFormat, CultureInfo.InvariantCulture)}", RoundId.ToString() };
        }

        public virtual string GetDate()
        {
            return $"{DateDisplay}<br />{Time.ToString(ViewFormat.RoundTimeFormat, CultureInfo.InvariantCulture)}";
        }

        public virtual string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return string.Empty;
        }

        public virtual string GetWinningTextResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return string.Empty;
        }

        public virtual bool IsWinningChoice(string choice)
        {
            return false;
        }
    }
}
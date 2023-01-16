using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Web.Configuration;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class RoundResultViewModel
    {
        public DateTime Time { get; set; }

        public DateTimeOffset UserTime => TimeZoneInfo.ConvertTimeFromUtc(Time, TimeZone);

        public string DisplayRoundDate => UserTime.RoundDateFormat();

        public string DisplayRoundTime => UserTime.RoundTimeWithSecondFormat();

        public TimeZoneInfo TimeZone { get; set; }

        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public long RoundId { get; set; }

        public virtual IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return new[] { $"{DateDisplay}<br />{Time.ToString(ViewFormat.RoundTimeFormat, CultureInfo.InvariantCulture)}", RoundId.ToString() };
        }
    }
}
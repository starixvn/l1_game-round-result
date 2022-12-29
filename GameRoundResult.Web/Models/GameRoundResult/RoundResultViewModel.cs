using System;
using System.Collections.Generic;
using System.Globalization;
using GameRoundResult.Web.Configuration;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public class RoundResultViewModel
    {
        public DateTimeOffset Time { get; set; }

        public string DateDisplay => Time.ToString(ViewFormat.RoundDateFormat);
        public string TimeDisplay => Time.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);

        public long RoundId { get; set; }

        public virtual IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return new[] { $"{DateDisplay}<br />{Time.ToString(ViewFormat.RoundTimeFormat, CultureInfo.InvariantCulture)}", RoundId.ToString() };
        }
    }
}
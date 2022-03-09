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

        public long RoundId { get; set; }

        public virtual IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return new[] { $"{Time.ToString(ViewFormat.RoundDateFormat)}<br/ >{Time.ToString(ViewFormat.RoundTimeFormat, CultureInfo.InvariantCulture)}", RoundId.ToString() };
        }
    }
}
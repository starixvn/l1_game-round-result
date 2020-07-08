using System;
using System.Collections.Generic;
using GameRoundResult.Web.Configuration;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Models
{
    public abstract class RoundResultViewModel
    {
        public DateTime Time { get; set; }

        public long Round { get; set; }

        public virtual IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return new string[] { Time.ToString(ViewFormat.DateTimeFormat), Round.ToString() };
        }
    }
}
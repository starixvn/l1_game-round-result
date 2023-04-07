using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultViewModel
    {
        public GameId GameType { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public long? RoundId { get; set; }

        public string UserTimeZone { get; set; }

        public IEnumerable<SelectListItem> GameTypes { get; set; }
    }
}
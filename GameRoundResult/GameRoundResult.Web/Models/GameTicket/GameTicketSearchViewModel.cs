using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class GameTicketSearchViewModel
    {
        public long? RoundId { get; set; }

        public int? MemberId { get; set; }

        public GameType GameType { get; set; }

        public IEnumerable<SelectListItem> GameTypes { get; set; }
    }
}
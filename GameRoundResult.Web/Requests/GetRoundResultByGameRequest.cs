using System;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Requests
{
    public class GetRoundResultByGameRequest
    {
        public GameRoundResultAuthModel Auth { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public GameType GameType { get; set; }

        public long RoundId { get; set; }

        public string UserTimeZone { get; set; }

        public DateTime Date { get; set; }
    }
}
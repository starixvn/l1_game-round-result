using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetRoundResultRequest : IRequest<IEnumerable<RoundResultViewModel>>
    {
        public GetRoundResultRequest(GameType gameType, DateTime date, long roundId, TimeZoneInfo timeZoneInfo)
        {
            GameType = gameType;
            Date = date;
            RoundId = roundId;
            TimeZoneInfo = timeZoneInfo;
        }

        public long RoundId { get; }

        public DateTime Date { get; }

        public GameType GameType { get; }

        public TimeZoneInfo TimeZoneInfo { get; }
    }
}
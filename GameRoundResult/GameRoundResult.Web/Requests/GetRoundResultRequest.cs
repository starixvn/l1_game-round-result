using System;
using System.Collections.Generic;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetRoundResultRequest : IRequest<IEnumerable<RoundResultViewModel>>
    {
        public GetRoundResultRequest(byte gameTypeId, DateTime date, long roundId)
        {
            GameTypeId = gameTypeId;
            Date = date;
            RoundId = roundId;
        }

        public long RoundId { get; }

        public DateTime Date { get; }

        public byte GameTypeId { get; }
    }
}
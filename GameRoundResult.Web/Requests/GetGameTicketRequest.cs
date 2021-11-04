using System;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetGameTicketRequest : IRequest<GameTicketViewModel>
    {
        public GetGameTicketRequest(GameType gameType, long roundId, int memberId, TimeZoneInfo timeZoneInfo)
        {
            GameType = gameType;
            MemberId = memberId;
            RoundId = roundId;
            TimeZoneInfo = timeZoneInfo;
        }

        public long RoundId { get; }

        public int MemberId { get; }

        public GameType GameType { get; }

        public TimeZoneInfo TimeZoneInfo { get; }

        public bool FreeBet { get; }
    }
}
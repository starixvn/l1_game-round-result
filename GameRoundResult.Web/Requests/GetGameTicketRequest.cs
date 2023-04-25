using System;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetGameTicketRequest : IRequest<GameTicketViewModel>
    {
        public GetGameTicketRequest(GameType gameId, long roundId, int playerId, TimeZoneInfo timeZoneInfo, string operatorId, bool freeBet, string systemType)
        {
            GameId = gameId;
            PlayerId = playerId;
            RoundId = roundId;
            TimeZoneInfo = timeZoneInfo;
            OperatorId = operatorId;
            FreeBet = freeBet;
            SystemType = systemType;
        }

        public long RoundId { get; }

        public int PlayerId { get; }

        public GameType GameId { get; }

        public TimeZoneInfo TimeZoneInfo { get; }

        public bool FreeBet { get; }

        public string OperatorId { get; }

        public string SystemType { get; }
    }
}
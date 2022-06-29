using System;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetGameTicketRequest : IRequest<GameTicketViewModel>
    {
        public GetGameTicketRequest(GameType gameType, long roundId, int playerId, TimeZoneInfo timeZoneInfo, string operatorId, bool freeBet)
        {
            GameType = gameType;
            PlayerId = playerId;
            RoundId = roundId;
            TimeZoneInfo = timeZoneInfo;
            OperatorId = operatorId;
            FreeBet = freeBet;
        }

        public long RoundId { get; }

        public int PlayerId { get; }

        public GameType GameType { get; }

        public TimeZoneInfo TimeZoneInfo { get; }

        public bool FreeBet { get; }

        public string OperatorId { get; }
    }
}
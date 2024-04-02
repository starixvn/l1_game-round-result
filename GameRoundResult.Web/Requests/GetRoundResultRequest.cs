using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;
using MediatR;

namespace GameRoundResult.Web.Requests
{
    public class GetRoundResultRequest : IRequest<(long, IEnumerable<RoundResultViewModel>)>
    {
        public GetRoundResultRequest(GameType gameType, DateTime date, long roundId, TimeZoneInfo timeZoneInfo, int page, int pageSize)
        {
            GameType = gameType;
            Date = date;
            RoundId = roundId;
            TimeZoneInfo = timeZoneInfo;
            Page = page;
            PageSize = pageSize;
        }

        public long RoundId { get; }

        public DateTime Date { get; }

        public GameType GameType { get; }

        public TimeZoneInfo TimeZoneInfo { get; }

        public int Page { get; }
        public int PageSize { get; }

        public bool IsGameDraw
        {
            get
            {
                return 
                    GameType == GameType.BacBall1 ||
                    GameType == GameType.BacBall2 ||
                    GameType == GameType.LuckyNext1 ||
                    GameType == GameType.LuckyNext2;
            }
        }
    }
}
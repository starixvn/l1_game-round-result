using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services
{
    public class EndRoundInfoResult
    {
        public string ErrorCode { get; set; } = "0";

        public string ErrorDescription { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalWin { get; set; }

        public decimal ValidBetAmount { get; set; }

        public DateTimeOffset? EndTime { get; set; }
    }

    public static class EndGameInfoError
    {
        public readonly static EndRoundInfoResult SB1000 = new EndRoundInfoResult
        {
            ErrorCode = "SB1000",
            ErrorDescription = "An Error has occurred."
        };

        public readonly static EndRoundInfoResult SB1001 = new EndRoundInfoResult
        {
            ErrorCode = "SB1001",
            ErrorDescription = "The game round does not exist."
        };

        public readonly static EndRoundInfoResult SB1002 = new EndRoundInfoResult
        {
            ErrorCode = "SB1002",
            ErrorDescription = "Game round id is required."
        };

        public readonly static EndRoundInfoResult SB1003 = new EndRoundInfoResult
        {
            ErrorCode = "SB1003",
            ErrorDescription = "Site Id is required."
        };

        public readonly static EndRoundInfoResult SB1004 = new EndRoundInfoResult
        {
            ErrorCode = "SB1004",
            ErrorDescription = "ObCustId is required."
        };

        public readonly static EndRoundInfoResult SB1005 = new EndRoundInfoResult
        {
            ErrorCode = "SB1005",
            ErrorDescription = "Game round is running."
        };

        public readonly static EndRoundInfoResult SB1006 = new EndRoundInfoResult
        {
            ErrorCode = "SB1006",
            ErrorDescription = "GameTypeId is invalid."
        };
    }
}

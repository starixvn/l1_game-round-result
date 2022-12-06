using System;

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

    public static class EndRoundInfoError
    {
        public static readonly EndRoundInfoResult SB1000 = new()
        {
            ErrorCode = "SB1000",
            ErrorDescription = "An Error has occurred."
        };

        public static readonly EndRoundInfoResult SB1001 = new()
        {
            ErrorCode = "SB1001",
            ErrorDescription = "The game round does not exist."
        };

        public static readonly EndRoundInfoResult SB1002 = new()
        {
            ErrorCode = "SB1002",
            ErrorDescription = "Game round id is required."
        };

        public static readonly EndRoundInfoResult SB1003 = new()
        {
            ErrorCode = "SB1003",
            ErrorDescription = "Site Id is required."
        };

        public static readonly EndRoundInfoResult SB1004 = new()
        {
            ErrorCode = "SB1004",
            ErrorDescription = "ObCustId is required."
        };

        public static readonly EndRoundInfoResult SB1005 = new()
        {
            ErrorCode = "SB1005",
            ErrorDescription = "Game round is running."
        };

        public static readonly EndRoundInfoResult SB1006 = new()
        {
            ErrorCode = "SB1006",
            ErrorDescription = "GameTypeId is invalid."
        };
    }
}
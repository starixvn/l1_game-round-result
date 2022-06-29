using System;

namespace GameRoundResult.Web.Models
{
    public class EndGameInfoResultModel
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
        public static readonly EndGameInfoResultModel SB1000 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1000",
            ErrorDescription = "An Error has occurred."
        };

        public static readonly EndGameInfoResultModel SB1001 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1001",
            ErrorDescription = "The game round does not exist."
        };

        public static readonly EndGameInfoResultModel SB1002 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1002",
            ErrorDescription = "Game round id is required."
        };

        public static readonly EndGameInfoResultModel SB1003 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1003",
            ErrorDescription = "Site Id is required."
        };

        public static readonly EndGameInfoResultModel SB1004 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1004",
            ErrorDescription = "PlayerId is required."
        };

        public static readonly EndGameInfoResultModel SB1005 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1005",
            ErrorDescription = "Game round is running."
        };

        public static readonly EndGameInfoResultModel SB1006 = new EndGameInfoResultModel
        {
            ErrorCode = "SB1006",
            ErrorDescription = "GameTypeId is invalid."
        };
    }
}

using GameRoundResult.Core.Constants;

namespace GameRoundResult.Core.Database.Entities.Player
{
    public class SGResult
    {
        public string ErrorCode { get; set; } = ErrorCodes.SuccessCode;

        public string ErrorDescription { get; set; }

        public string Seq { get; set; }
    }
}
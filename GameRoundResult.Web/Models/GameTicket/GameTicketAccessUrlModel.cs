using System.ComponentModel.DataAnnotations;
using GameRoundResult.Core.Constants;
using MediatR;

namespace GameRoundResult.Web.Models
{
    public class GameTicketAccessUrlRequestModel
    {
        [Required]
        public GameType GameTypeId { get; set; }

        public AuthModel Auth { get; set; }

        [Required]
        public long GameRoundId { get; set; }

        [Required]
        public int ObCustId { get; set; }

        public string Language { get; set; }

        public bool FreeBet { get; set; }
    }

    public class AuthModel
    {
        [Required]
        public string OperatorId { get; set; }

        public string OperatorSecret { get; set; }
    }

    public class AuthenticationResult
    {
        public AuthenticationResult(bool isAuthorize, string operatorSecret)
        {
            IsAuthorize = isAuthorize;
            OperatorSecret = operatorSecret;
        }

        public bool IsAuthorize { get; }

        public string OperatorSecret { get; }
    }

    public class BetHistoryAccessUrlRequestModel : IRequest<GameTicketAccessUrlResultModel>
    {
        [Required]
        public GameType GameTypeId { get; set; }

        public AuthModel Auth { get; set; }

        [Required]
        public long GameRoundId { get; set; }

        [Required]
        public string PlayerId { get; set; }

        public string Language { get; set; }

        public bool FreeBet { get; set; }

        public bool CallFromCloudService { get; set; }
    }
}
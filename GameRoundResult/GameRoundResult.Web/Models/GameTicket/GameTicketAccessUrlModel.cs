using System.ComponentModel.DataAnnotations;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketAccessUrlRequestModel
    {
        [Required]
        public GameType GameTypeId { get; set; }

        public AuthModel Auth { get; set; }

        [Required]
        public long RoundId { get; set; }

        [Required]
        public int MemberId { get; set; }

        public string Language { get; set; }
    }

    public class AuthModel
    {
        [Required]
        public string ClientID { get; set; }

        [Required]
        public string ClientKey { get; set; }
    }
}
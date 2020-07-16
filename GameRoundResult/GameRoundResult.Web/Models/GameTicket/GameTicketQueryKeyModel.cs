using System.ComponentModel.DataAnnotations;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketQueryKeyModel
    {
        [Required]
        public GameType GameTypeId { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public long RoundId { get; set; }

        [Required]
        public int MemberId { get; set; }
    }
}
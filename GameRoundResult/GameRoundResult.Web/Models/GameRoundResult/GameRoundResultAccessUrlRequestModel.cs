using System.ComponentModel.DataAnnotations;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultAccessUrlRequestModel
    {
        public AuthModel Auth { get; set; }

        public string Language { get; set; }

        public byte GameId { get; set; }
    }
}
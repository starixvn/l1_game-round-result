using System.ComponentModel.DataAnnotations;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultAccessUrlRequestModel
    {
        public AuthModel Auth { get; set; }

        public string Language { get; set; }

        public int GameId { get; set; }

        public string SiteName { get; set; }
    }
}
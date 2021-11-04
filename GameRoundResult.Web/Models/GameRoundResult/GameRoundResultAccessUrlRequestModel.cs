using System.ComponentModel.DataAnnotations;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultAccessUrlRequestModel
    {
        public GameRoundResultAuthModel Auth { get; set; }

        public string Language { get; set; }

        public int GameId { get; set; }

        public string SiteName { get; set; }

        public string PartnerId { get; set; }

        public string CurrencyGroupId { get; set; }
    }

    public class GameRoundResultAuthModel
    {
        [Required]
        public string ClientID { get; set; }

        [Required]
        public string ClientKey { get; set; }
    }

    public class GameRoundResultAuthModel
    {
        [Required]
        public string ClientID { get; set; }

        [Required]
        public string ClientKey { get; set; }
    }
}
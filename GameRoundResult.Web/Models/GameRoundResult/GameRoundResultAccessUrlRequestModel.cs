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
        public string OperatorId { get; set; }

        public string OperatorSecret { get; set; }

        public string ClientID { get; set; }

        public string ClientKey { get; set; }
    }
}
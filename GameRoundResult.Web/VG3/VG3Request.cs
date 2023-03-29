using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.VG3
{
    public class VG3Request
    {
        public byte GameTypeId { get; set; }

        public AuthModel Auth { get; set; }

        public long GameRoundId { get; set; }

        public int ObCustId { get; set; }

        public int PlayerId { get; set; }

        public string Language { get; set; }

        public bool FreeBet { get; set; }
    }
}
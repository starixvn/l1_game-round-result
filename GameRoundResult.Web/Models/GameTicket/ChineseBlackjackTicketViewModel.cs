using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    [TolgeeNamespace("ChineseBlackjack")]
    public class ChineseBlackjackTicketViewModel : BlackjackTicketViewModel
    {
        public bool IsDealerBanBan()
        {
            return DealerCards.Count() == ChineseBlackjack.MinCardsOnHand && DealerCards.All(card => card.Rank == "A");
        }
        public bool IsDealerBanLuck()
        {
            if(DealerCards.Count() == ChineseBlackjack.MinCardsOnHand)
            {
                var cardWithAceRank = DealerCards.FirstOrDefault(card => card.Rank == "A");
                var cardWithoutAceRank = DealerCards.FirstOrDefault(card => card.Rank != "A");
                if (cardWithAceRank != null
                && (cardWithoutAceRank.Rank == "10"
                || cardWithoutAceRank.Rank == "J"
                || cardWithoutAceRank.Rank == "Q"
                || cardWithoutAceRank.Rank == "K"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
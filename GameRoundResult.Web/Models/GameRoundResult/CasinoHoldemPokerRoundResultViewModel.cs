using System.Collections.Generic;
using GameRoundResult.Web.Configuration;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class CasinoHoldemPokerRoundResultViewModel : RoundResultViewModel
    {
        public bool IsQualified { get; set; }
        public bool Ended { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCards { get; set; }
        public IEnumerable<PokerCardViewModel> CommunityCards { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCombinationCards { get; set; }
        public byte HandRankId { get; set; }
        public bool? IsSwappedOrHold { get; set; }

        public override IEnumerable<string> ToDataTableArray(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return default;
        }
    }
}
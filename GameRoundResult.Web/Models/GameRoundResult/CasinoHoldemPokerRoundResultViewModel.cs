using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models.GameRoundResult
{
    public class CasinoHoldemPokerRoundResultViewModel : RoundResultViewModel
    {
        public DateTime Time { get; set; }
        public long Round { get; set; }
        public bool IsQualified { get; set; }
        public bool Ended { get; set; }
        public bool IsFold { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCards { get; set; }
        public IEnumerable<PokerCardViewModel> CommunityCards { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCombinationCards { get; set; }
        public byte HandRankId { get; set; }

        public override IEnumerable<string> ToDataTableArray(IStringLocalizer<RoundResultViewModel> stringLocalizer)
        {
            return default;
        }

    }

}

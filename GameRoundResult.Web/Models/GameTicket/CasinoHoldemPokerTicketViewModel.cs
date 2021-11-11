using System;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class CasinoHoldemPokerTicketViewModel : GameTicketViewModel
    {
        
        public CasinoHoldemPokerBetViewModel Bet { get; set; }

        public CasinoHoldemPokerRoundViewModel Round { get; set; }

        public CasinoHoldemPokerHandViewModel Player 
            => new CasinoHoldemPokerHandViewModel { Cards = Bet.PlayerCards, CombinationCards = Bet.CombinationCards, Id = Bet.HandRankId };

        public CasinoHoldemPokerHandViewModel Dealer
            => new CasinoHoldemPokerHandViewModel { Cards = Round.DealerCards, CombinationCards = Round.DealerCombinationCards, Id = Round.HandRankId };

        public IEnumerable<PokerCardViewModel> CommunityCards => Round.CommunityCards;

        public bool Ended { get; set; }

        public bool IsFold { get; set; }

        public bool IsQualified => Round.IsQualified;

        public decimal TotalBet => Bet.Ante + Bet.Aa + Bet.Call;

        public decimal TotalWin => Ended || IsFold ? Bet.SettlementResult.Aa + Bet.SettlementResult.Ante + Bet.SettlementResult.Call : 0;

        public decimal WinLoss => TotalWin - TotalBet;

        public CasinoHoldemPokerDetailBetViewModel SettlementResult { get; set; }
    }

    public class CasinoHoldemPokerHandViewModel
    {
        private readonly string[] RankHandName = {
                        "DoesNotQualify",
                        "HighCard",
                        "Pair",
                        "TwoPairs",
                        "ThreeOfAKind",
                        "Straight",
                        "Flush",
                        "FullHouse",
                        "FourOfAKind",
                        "StraightFlush",
                        "RoyalFlush",
                    };
        public byte Id { get; set; }
        public IEnumerable<PokerCardViewModel> Cards { get; set; }
        public IEnumerable<PokerCardViewModel> CombinationCards { get; set; }
        public string Rank => RankHandName[Id];
    }

    public class CasinoHoldemPokerRoundViewModel 
    {
        public DateTime Time { get; set; }
        public long Round { get; set; }
        public bool IsQualified { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCards { get; set; }
        public IEnumerable<PokerCardViewModel> CommunityCards { get; set; }
        public IEnumerable<PokerCardViewModel> DealerCombinationCards { get; set; }
        public byte HandRankId { get; set; }
    }

    public class CasinoHoldemPokerBetViewModel
    {
        public decimal Aa { get; set; }
        public decimal Ante { get; set; }
        public decimal Call { get; set; }
        public IEnumerable<PokerCardViewModel> PlayerCards { get; set; }
        public IEnumerable<PokerCardViewModel> CombinationCards { get; set; }
        public byte HandRankId { get; set; }
        public CasinoHoldemPokerDetailBetViewModel SettlementResult { get; set; }
        public decimal BetWin { get; set; }
    }

    public class CasinoHoldemPokerDetailBetViewModel
    {
        public decimal Aa { get; set; }
        public decimal Ante { get; set; }
        public decimal Call { get; set; }
    }

    public class PokerCardViewModel
    {
        public byte Rank { get; set; }
        public byte Suit { get; set; }
    }
}

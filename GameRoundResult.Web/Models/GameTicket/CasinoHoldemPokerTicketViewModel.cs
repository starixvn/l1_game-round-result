using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models.GameRoundResult;
using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class CasinoHoldemPokerTicketViewModel : GameTicketViewModel
    {
        private readonly string EmptyOdds = "-";

        public CasinoHoldemPokerBetViewModel Bet { get; set; }

        public CasinoHoldemPokerRoundResultViewModel Round { get; set; }

        public CasinoHoldemPokerDetailBetViewModel SettlementResult { get; set; }

        public CasinoHoldemPokerHandViewModel Player
            => new CasinoHoldemPokerHandViewModel { Cards = Bet.PlayerCards, CombinationCards = Bet.CombinationCards, Id = Bet.HandRankId };

        public CasinoHoldemPokerHandViewModel Dealer
            => new CasinoHoldemPokerHandViewModel { Cards = Round.DealerCards, CombinationCards = Round.DealerCombinationCards, Id = Round.HandRankId };

        public IEnumerable<PokerCardViewModel> CommunityCards => Round.CommunityCards;

        public bool Ended => Round.Ended;

        public bool IsFold => Bet.IsFold;

        public bool IsQualified => Round.IsQualified;

        public string AnteOddsDisplayed => Ended && (Bet.SettlementResult?.Ante > Bet.Ante) ? Bet.AnteOdds.ToString(ViewFormat.NumberFormat) : EmptyOdds;

        public string AAOddsDisplayed => Ended && (Bet.SettlementResult?.Aa > Bet.Aa) ? Bet.AaOdds.ToString(ViewFormat.NumberFormat) : EmptyOdds;

        public string CallOddsDisplayed => Ended && (Bet.SettlementResult?.Call > Bet.Call) ? Bet.CallOdds.ToString(ViewFormat.NumberFormat) : EmptyOdds;

        public decimal TotalBet => Bet.Ante + Bet.Aa + Bet.Call;

        public decimal TotalWin => Ended ? Bet.SettlementResult.Aa + Bet.SettlementResult.Ante + Bet.SettlementResult.Call : 0;

        public string WinLossDisplayed => Ended ? WinLoss.ToString(ViewFormat.NumberFormat) : string.Empty;

        private decimal WinLoss => Bet.SettlementResult.Aa + Bet.SettlementResult.Ante + Bet.SettlementResult.Call - TotalBet;
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

    public class CasinoHoldemPokerBetViewModel
    {
        public decimal Aa { get; set; }
        public decimal AaOdds { get; set; }
        public decimal Ante { get; set; }
        public decimal AnteOdds { get; set; }
        public decimal Call { get; set; }
        public decimal CallOdds { get; set; }
        public bool IsFold { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime Time { get; set; }
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

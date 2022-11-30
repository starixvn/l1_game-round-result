using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models.GameRoundResult;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models
{
    public class TexasHoldemPokerTicketViewModel : GameTicketViewModel
    {
        private readonly string EmptyOdds = "-";
        private readonly IEnumerable<PokerCardViewModel> DefaultPokerCards = Enumerable.Empty<PokerCardViewModel>();

        public TexasHoldemPokerBetViewModel Bet { get; set; }

        public CasinoHoldemPokerRoundResultViewModel Round { get; set; }

        public TexasHoldemPokerDetailBetViewModel SettlementResult { get; set; }

        public TexasHoldemPokerHandViewModel Player
            => new TexasHoldemPokerHandViewModel
            {
                Cards = Bet?.PlayerCards ?? DefaultPokerCards,
                CombinationCards = Bet?.CombinationCards ?? DefaultPokerCards,
                Id = Bet?.HandRankId ?? 0
            };

        public TexasHoldemPokerHandViewModel Dealer
            => new TexasHoldemPokerHandViewModel
            {
                Cards = Round?.DealerCards ?? DefaultPokerCards,
                CombinationCards = Round?.DealerCombinationCards ?? DefaultPokerCards,
                Id = Round?.HandRankId ?? 0
            };

        public IEnumerable<PokerCardViewModel> CommunityCards => Round?.CommunityCards;

        public bool Ended => Round?.Ended ?? false;

        public bool IsFold => Bet?.IsFold ?? false;

        public bool? IsSwappedOrHold => Round?.IsSwappedOrHold;

        public string AnteOddsDisplayed => Ended && (Bet.SettlementResult?.Ante > Bet.Ante) ? Bet.AnteOdds.FormatOdds(FractionalOddsFormat) : EmptyOdds;

        public string TurnOddsDisplayed => Ended && (Bet.SettlementResult?.Turn > Bet.Turn) ? Bet.TurnOdds.FormatOdds(FractionalOddsFormat) : EmptyOdds;

        public string RiverOddsDisplayed => Ended && (Bet.SettlementResult?.River > Bet.River) ? Bet.RiverOdds.FormatOdds(FractionalOddsFormat) : EmptyOdds;

        public string CallOddsDisplayed => Ended && (Bet.SettlementResult?.Call > Bet.Call) ? Bet.CallOdds.FormatOdds(FractionalOddsFormat) : EmptyOdds;

        public decimal TotalBet => Bet.Ante + Bet.Turn + Bet.River + Bet.Call;

        public decimal TotalWin => Ended ? Bet.SettlementResult.River + Bet.SettlementResult.Turn + Bet.SettlementResult.Ante + Bet.SettlementResult.Call : 0;

        public string WinLossDisplayed => Ended ? WinLoss.ToString(ViewFormat.NumberFormat) : string.Empty;

        private decimal WinLoss => Bet.SettlementResult.River + Bet.SettlementResult.Turn + Bet.SettlementResult.Ante + Bet.SettlementResult.Call - TotalBet;
    }

    public class TexasHoldemPokerHandViewModel
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

    public class TexasHoldemPokerBetViewModel
    {
        public decimal Ante { get; set; }

        public decimal AnteOdds { get; set; }

        public decimal Turn { get; set; }

        public decimal TurnOdds { get; set; }

        public decimal River { get; set; }

        public decimal RiverOdds { get; set; }

        public decimal Call { get; set; }

        public decimal CallOdds { get; set; }

        public bool IsFold { get; set; }

        public DateTime Time { get; set; }

        public DateTime CallTime { get; set; }

        public DateTime TurnTime { get; set; }

        public DateTime RiverTime { get; set; }

        public IEnumerable<PokerCardViewModel> PlayerCards { get; set; }

        public IEnumerable<PokerCardViewModel> CombinationCards { get; set; }

        public byte HandRankId { get; set; }

        public TexasHoldemPokerDetailBetViewModel SettlementResult { get; set; }

        public decimal BetWin { get; set; }
    }

    public class TexasHoldemPokerDetailBetViewModel
    {
        public decimal Ante { get; set; }

        public decimal Call { get; set; }

        public decimal Turn { get; set; }

        public decimal River { get; set; }
    }
}
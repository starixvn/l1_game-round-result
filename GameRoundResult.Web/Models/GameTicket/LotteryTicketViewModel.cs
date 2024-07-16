using System;
using System.Collections.Generic;

namespace GameRoundResult.Web.Models
{
    public class LotteryTicketViewModel : GameTicketViewModel
    {
        public LotteryRoundResultViewModel RoundResult { get; set; }

        public LotterySettlementResultViewModel SettlementResult { get; set; }

        public IEnumerable<LotteryBetViewModel> Bets { get; set; }

        public decimal TotalBet { get; set; }

        public decimal TotalBetWin { get; set; }

        public decimal WinLoss => TotalBetWin - TotalBet;

        public LotteryChoicesViewModel Choices { get; set; }
    }

    public class LotterySettlementResultViewModel
    {
        public IEnumerable<string> FourSets { get; set; }

        public string Special { get; set; }

        public string Head { get; set; }

        public string Tail { get; set; }

        public Dictionary<string, bool> Others { get; set; }

        public IEnumerable<string> TwentySevenSets { get; set; }

        public LotteryOccurrencesViewModel Occurrences { get; set; }
    }

    public class LotteryOccurrencesViewModel
    {
        public Dictionary<string, byte> All { get; set; }
        public Dictionary<string, byte> Seventh { get; set; }
    }

    public class LotteryBetViewModel
    {
        public DateTime Time { get; set; }

        public LotteryChoicesViewModel Choices { get; set; }
    }

    public class LotteryChoicesViewModel
    {
        public Dictionary<string, decimal> FourSets { get; set; }

        public Dictionary<string, decimal> Special { get; set; }

        public Dictionary<string, decimal> Head { get; set; }

        public Dictionary<string, decimal> Tail { get; set; }

        public Dictionary<string, decimal> Parlay2 { get; set; }

        public Dictionary<string, decimal> Parlay3 { get; set; }

        public Dictionary<string, decimal> Parlay4 { get; set; }

        public Dictionary<string, decimal> TwentySevenSets { get; set; }

        public Dictionary<string, decimal> Others { get; set; }
    }

    public class LotteryOddsViewModel
    {
        public decimal FourSets { get; set; }
        public decimal Special { get; set; }
        public decimal Head { get; set; }
        public decimal Tail { get; set; }
        public decimal Parlay2 { get; set; }
        public decimal Parlay3 { get; set; }
        public decimal Parlay4 { get; set; }
        public decimal TwentySevenSets { get; set; }
        public decimal Others { get; set; }
    }
}
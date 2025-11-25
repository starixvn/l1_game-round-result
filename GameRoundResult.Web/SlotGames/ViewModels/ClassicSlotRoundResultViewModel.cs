using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.SlotGames.ViewModels
{
    public class ClassicSlotRoundResultViewModel : RoundResultViewModel
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public IEnumerable<ClassicSlotBonusChestViewModel> BonusChests { get; set; }

        public ClassicSlotSettlementResultViewModel SettlementResult { get; set; }

        public decimal BetWin { get; set; }

        public ClassicSlotJackpotContributionViewModel JackpotContribution { get; set; }

        public byte[,] FormatResults
        {
            get
            {
                var array = Result.ToArray();

                var formatResult = new byte[SlotGameConstant.NumberOfRows, SlotGameConstant.NumberOfColumns];

                for (var row = 0; row < SlotGameConstant.NumberOfRows; row++)
                {
                    for (var column = 0; column < SlotGameConstant.NumberOfColumns; column++)
                    {
                        formatResult[row, column] = array[row + column * SlotGameConstant.NumberOfRows];
                    }
                }

                return formatResult;
            }
        }

        public decimal PickedBonusChestsTotalAmount => BonusChests.Where(x => x.Picked).Sum(x => x.Amount);

        public IEnumerable<byte> NotWinningPaylines
            => Paylines.Where(x => SettlementResult.WinningPaylines.All(y => y.Payline != x) && x != SettlementResult.Jackpot?.WinningLine);

        public string DisplayTotalAmount => FreeSpin ? "0" : TotalAmount.Format();

        public decimal TotalBetWin => BetWin + (SettlementResult.Jackpot?.WinningAmount ?? 0);

        public string DisplayTotalBetWin => TotalBetWin.Format();

        public int XMode { get; set; }
    }
}
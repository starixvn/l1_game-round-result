using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class FortuneCatTicketViewModel : GameTicketViewModel
    {
        public FortuneCatRoundResultViewModel RoundResult { get; set; }

        public decimal BetWin => RoundResult.BetWin + (RoundResult.SettlementResult.Jackpot?.WinningAmount ?? 0);

        public decimal WinLoss => RoundResult.FreeSpin ? BetWin : BetWin - RoundResult.TotalAmount;

        public string SystemType { get; set; }

        public string GetImageJackpot()
        {
            var img = new TagBuilder("img");
            img.AddCssClass($"symbol");
            var ticks = DateTime.Now.Ticks;
            if (SystemType.Equals("SC1"))
            {
                img.Attributes.Add("src", $"/scss/images/fortune-cat/10.png?v={ticks}");
            }
            else
            {
                if (CultureInfo.CurrentUICulture.Name == "vi-VN")
                {
                    img.Attributes.Add("src", $"/scss/images/fortune-cat/10.vi-VN.png?v={ticks}");
                }
                else
                {
                    img.Attributes.Add("src", $"/scss/images/fortune-cat/10.jackpot.png?v={ticks}");
                }
            }
           
            return img.GetHtmlString();
        }
    }

    public class FortuneCatRoundResultViewModel : RoundResultViewModel
    {
        public decimal Bet { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<byte> Paylines { get; set; }

        public bool FreeSpin { get; set; }

        public IEnumerable<byte> Result { get; set; }

        public IEnumerable<FortuneCatBonusChestViewModel> BonusChests { get; set; }

        public FortuneCatSettlementResultViewModel SettlementResult { get; set; }

        public decimal BetWin { get; set; }

        public byte[,] GetFormatResults()
        {
            var array = Result.ToArray();

            var formatResult = new byte[3, 5];

            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 5; column++)
                {
                    formatResult[row, column] = array[row + column * 3];
                }
            }

            return formatResult;
        }
    }

    public class FortuneCatBonusChestViewModel
    {
        public decimal Amount { get; set; }

        public bool Picked { get; set; }
    }

    public class FortuneCatSettlementResultViewModel
    {
        public IEnumerable<FortuneCatWinningLineViewModel> WinningPaylines { get; set; }

        public FortuneCatBonusViewModel Bonus { get; set; }

        public FortuneCatFreeSpinViewModel FreeSpins { get; set; }

        public FortuneCatJackpotViewModel Jackpot { get; set; }
    }

    public class FortuneCatJackpotViewModel
    {
        public byte WinningLine { get; set; }

        public decimal WinningAmount { get; set; }
    }

    public class FortuneCatWinningLineViewModel
    {
        public byte Payline { get; set; }

        public string Symbol { get; set; }

        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class FortuneCatBonusViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }

    public class FortuneCatFreeSpinViewModel
    {
        public byte Count { get; set; }

        public decimal Odds { get; set; }
    }
}
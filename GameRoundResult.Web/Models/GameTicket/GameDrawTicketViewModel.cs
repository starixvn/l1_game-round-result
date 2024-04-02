using GameRoundResult.Core.Database.Entities.GameDraw;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.Web.Models.GameTicket
{
    public class GameDrawTicketViewModel<GameDraw, Result, Settle> : GameTicketViewModel
        where GameDraw : GameDraw<Result, Settle>
        where Result : GameDrawResultBase
        where Settle : GameDrawBase
    {
        public long DrawId { get; set; }
        public IEnumerable<TranslationBetLogViewModel> BetLogs { get; set; }

        public Dictionary<string, decimal> Odds { get; set; }

        public GameDraw RoundResult { get; set; }

        public Result DrawResult => RoundResult.Result.First(draw => draw.DrawId == DrawId);

        public DateTime Time => DrawResult.Time;

        public string GetRowBetClass(string displayedChoice)
        {
            return IsWinningChoice(displayedChoice) ? "bold text-blue" : string.Empty;
        }

        public virtual bool IsWinningChoice(string displayedChoice)
        {
            var settlementResult = RoundResult.SettlementResult.FirstOrDefault(r => r.DrawId == DrawId);
            return bool.Parse(settlementResult.GetType().GetProperty(displayedChoice).GetValue(settlementResult, null).ToString());
        }

        public virtual decimal GetBetLogWin(TranslationBetLogViewModel bet)
        {
            return IsWinningChoice(bet.ChoiceDisplay) ? Odds[bet.Choice] * bet.Amount : 0;
        }
    }
}

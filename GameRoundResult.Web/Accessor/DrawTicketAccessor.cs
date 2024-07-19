using AutoMapper;
using GameRoundResult.Core.Database.Entities.GameDraw;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameTicket;
using GameRoundResult.Web.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameRoundResult.Web.Accessor
{
    public class DrawTicketAccessor<ITicketService, Draw, Bet, BetLog, Result, Settle, VM> : IGameTicketAccessor
        where ITicketService : IDrawTicketService<Draw, Bet, BetLog, Result, Settle>
        where Draw : GameDraw<Result, Settle>
        where Bet : GameDrawBaseBetEntity
        where BetLog : GameDrawBaseBetEntity
        where Result : GameDrawResultBase
        where Settle : GameDrawBase
        where VM : GameDrawTicketViewModel<Draw, Result, Settle>
    {
        private readonly ITicketService gameBetService;
        private readonly IMapper mapper;
        private readonly ICurrencyGroupService currencyGroupService;

        public DrawTicketAccessor(ITicketService gameBetService, IMapper mapper, ICurrencyGroupService currencyGroupService)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            this.currencyGroupService = currencyGroupService;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);

            var viewModel = createViewModel();
            if (result.Item1 != null)
            {
                result.Item1.Result.ForEach(x => x.ToViewModelTicketResult(mapper, request.TimeZoneOffset));
                viewModel.RoundResult = result.Item1;
            }
            viewModel.BetLogs = result.Item3?.Select(x => x.ToViewModelTicketBetLog(mapper, request.TimeZoneOffset));
            viewModel.Odds = result.Item2?.Odds;
            viewModel.TotalBet = result.Item2?.TotalBet ?? 0;
            viewModel.BetWin = result.Item2?.Betwin ?? 0;
            viewModel.DrawId = request.RoundId;


            if (!string.IsNullOrEmpty(result.Item2?.Currency))
            {
                viewModel.FractionalOddsFormat = await currencyGroupService.GetFractionalOddsFormat(result.Item2.Currency, request.OperatorId);
            }
            return viewModel;
        }

        private VM createViewModel()
        {
            return (VM)Activator.CreateInstance(typeof(VM), new object[] { });
        }
    }
}
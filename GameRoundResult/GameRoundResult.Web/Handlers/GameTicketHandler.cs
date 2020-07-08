using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, BigSmallTicketViewModel>
    {
        private readonly IGameBetService service;
        private readonly IMapper mapper;

        public GameTicketHandler(IGameBetService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<BigSmallTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetBigSmallAsync(request.RoundId, request.MemberId);

            return new BigSmallTicketViewModel
            {
                RoundResult = result.Item1.ToViewModel(mapper, request.TimeZoneInfo),
                Bets = result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, GameTicketViewModel>
    {
        private readonly IGameBetService service;
        private readonly IMapper mapper;

        public GameTicketHandler(IGameBetService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            switch (request.GameType)
            {
                case GameType.BigSmall:
                    var bigSmallResult = await service.GetBigSmallAsync(request.RoundId, request.MemberId);
                    return new BigSmallTicketViewModel
                    {
                        RoundResult = bigSmallResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = bigSmallResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.BigSmallTurbo:
                    var bigSmallTurboResult = await service.GetBigSmallTurboAsync(request.RoundId, request.MemberId);
                    return new BigSmallTicketViewModel
                    {
                        RoundResult = bigSmallTurboResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = bigSmallTurboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.OddEven:
                    var oddEvenResult = await service.GetOddEvenAsync(request.RoundId, request.MemberId);
                    return new OddEvenTicketViewModel
                    {
                        RoundResult = oddEvenResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = oddEvenResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.OddEvenTurbo:
                    var oddEvenTurboResult = await service.GetOddEvenTurboAsync(request.RoundId, request.MemberId);
                    return new OddEvenTicketViewModel
                    {
                        RoundResult = oddEvenTurboResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = oddEvenTurboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                default:
                    throw new ArgumentException(nameof(GetGameTicketRequest.GameType));
            }
           
        }
    }
}

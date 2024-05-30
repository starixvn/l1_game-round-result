using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public class HiLoTicketAccessor : IGameTicketAccessor
    {
        private readonly IHiLoTicketService gameBetService;
        private readonly IMapper mapper;

        public HiLoTicketAccessor(IHiLoTicketService gameBetService, IMapper mapper)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request)
        {
            var hiloResult = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId);
            var roundResult = hiloResult.Item1?.ToViewModel<HiLoRound, HiLoRoundResultViewModel>(mapper, request.TimeZoneOffset);

            if (roundResult != null && roundResult.EndTime.HasValue)
            {
                roundResult.EndTime = roundResult.EndTime.Value.AddHours(request.TimeZoneOffset.TotalHours);
            }

            return new HiLoTicketViewModel
            {
                RoundResult = roundResult,
                BetLogs = hiloResult.Item2.Select(x => mapper.Map<HiLoBetLog, HiLoBetLogViewModel>(x, opts =>
                {
                    opts.AfterMap((source, dest) => dest.Time = source.Time.AddHours(request.TimeZoneOffset.TotalHours));
                }))
            };
        }
    }
}
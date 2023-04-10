using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Accessor;
using GameRoundResult.Web.CascadingSlotGames.ViewModels;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using Microsoft.Extensions.Options;

namespace GameRoundResult.Web.CascadingSlotGames
{
    public class CascadingSlotTicketHandler : IGameTicketAccessor
    {
        private readonly ICascadingSlotTicketService gameBetService;
        private readonly IMapper mapper;
        private readonly GameResource gameResource;

        public CascadingSlotTicketHandler(ICascadingSlotTicketService gameBetService, IMapper mapper, IOptions<GameResource> gameResourceOptions)
        {
            this.gameBetService = gameBetService;
            this.mapper = mapper;
            gameResource = gameResourceOptions.Value;
        }

        public async Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request, GameConfigModel gameConfigs)
        {
            var result = await gameBetService.GetAsync(request.RoundId, request.PlayerId, request.OperatorId, gameConfigs.Name);

            return new BaseCascadingSlotTicketViewModel
            {
                GameName = gameConfigs.Name,
                Round = result.Item1?.ToViewModel<BaseCascadingSlotRoundEntity, BaseCascadingSlotRoundViewModel>(mapper, request.TimeZoneInfo),
                Multipliers = result.Item2?.Rounds.Select(multiplier => multiplier.ToViewModel(mapper, request.TimeZoneInfo)),
                StaticResourceUrl = gameResource.BaseUrl.ToString()
            };
        }
    }
}
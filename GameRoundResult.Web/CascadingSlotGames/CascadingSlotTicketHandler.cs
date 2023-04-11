using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

            var viewModel = new BaseCascadingSlotTicketViewModel
            {
                GameName = gameConfigs.Name,
                StaticResourceUrl = gameResource.BaseUrl.ToString()
            };

            if (result.Item1 != null)
            {
                viewModel.Round = mapper.Map<BaseCascadingSlotRoundViewModel>(result.Item1);
                viewModel.Round.TimeZone = request.TimeZoneInfo;
            }

            if (result.Item2 != null)
            {
                viewModel.Multipliers = result.Item2.Rounds.Select(x =>
                {
                    var mappedModel = mapper.Map<BaseCascadingSlotRoundMultiplierViewModel>(x);
                    mappedModel.TimeZone = request.TimeZoneInfo;

                    return mappedModel;
                });
            }

            return viewModel;
        }
    }
}
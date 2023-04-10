using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.CascadingSlotGames.ViewModels;

namespace GameRoundResult.Web.CascadingSlotGames.Mappers
{
    public class CascadingSlotGameProfile : Profile
    {
        public CascadingSlotGameProfile()
        {
            CreateMap<BaseCascadingSlotRoundEntity, BaseCascadingSlotRoundViewModel>();
            CreateMap<BaseCascadingSlotSettlementResult, BaseCascadingSlotSettlementResultViewModel>();
            CreateMap<BaseCascadingSlotRoundMultiplier, BaseCascadingSlotRoundMultiplierViewModel>();
            CreateMap<BaseCascadingSlotFreeSpin, BaseCascadingSlotFreeSpinViewModel>();
            CreateMap<BaseCascadingSlotWinningSymbol, BaseCascadingSlotWinningSymbolViewModel>();
            CreateMap<BaseCascadingSlotTumble, BaseCascadingSlotTumbleViewModel>();
        }
    }
}
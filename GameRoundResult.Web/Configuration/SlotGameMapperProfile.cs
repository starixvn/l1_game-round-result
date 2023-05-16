using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.SlotGames.ViewModels;

namespace GameRoundResult.Web.Configuration
{
    public class SlotGameMapperProfile : Profile
    {
        public SlotGameMapperProfile()
        {
            CreateMap<SlotGameRound, ClassicSlotRoundResultViewModel>();
            CreateMap<SlotGameSettlementResult, ClassicSlotSettlementResultViewModel>();
            CreateMap<SlotGameFreeSpin, ClassicSlotSymbolViewModel>();
            CreateMap<SlotGameBonus, ClassicSlotSymbolViewModel>();
            CreateMap<SlotGameWinningLine, ClassicSlotWinningLineViewModel>();
            CreateMap<SlotGameBonusChest, ClassicSlotBonusChestViewModel>();
            CreateMap<SlotGameJackpot, ClassicSlotJackpotViewModel>();
            CreateMap<SlotGameJackpotContribution, ClassicSlotJackpotContributionViewModel>();
        }
    }
}
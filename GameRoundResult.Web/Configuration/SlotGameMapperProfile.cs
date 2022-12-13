using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Configuration
{
    public class SlotGameMapperProfile : Profile
    {
        public SlotGameMapperProfile()
        {
            CreateMap<SlotGameRound, SlotGameRoundResultViewModel>();
            CreateMap<SlotGameSettlementResult, SlotGameSettlementResultViewModel>();
            CreateMap<SlotGameFreeSpin, SlotGameFreeSpinViewModel>();
            CreateMap<SlotGameBonus, SlotGameBonusViewModel>();
            CreateMap<SlotGameWinningLine, SlotGameWinningLineViewModel>();
            CreateMap<SlotGameBonusChest, SlotGameBonusChestViewModel>();
            CreateMap<SlotGameJackpot, SlotGameJackpotViewModel>();
        }
    }
}
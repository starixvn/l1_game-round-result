using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.SlotGames.Mappers
{
    public class SlotGameProfile : Profile
    {
        public SlotGameProfile()
        {
            CreateMap<SlotGameRound, ClassicSlotRoundResultViewModel>();
            CreateMap<SlotGameSettlementResult, ClassicSlotSettlementResultViewModel>();
            CreateMap<SlotGameFreeSpin, ClassicSlotFreeSpinViewModel>();
            CreateMap<SlotGameBonus, ClassicSlotBonusViewModel>();
            CreateMap<SlotGameWinningLine, ClassicSlotWinningLineViewModel>();
            CreateMap<SlotGameBonusChest, ClassicSlotBonusChestViewModel>();
            CreateMap<SlotGameJackpot, ClassicSlotJackpotViewModel>();
        }
    }
}
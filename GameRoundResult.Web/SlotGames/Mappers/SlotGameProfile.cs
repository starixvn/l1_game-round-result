using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.SlotGames.ViewModels;

namespace GameRoundResult.Web.SlotGames.Mappers
{
    public class SlotGameProfile : Profile
    {
        public SlotGameProfile()
        {
            CreateMap<SlotGameRound, ClassicSlotRoundResultViewModel>();
            CreateMap<SlotGameSettlementResult, ClassicSlotSettlementResultViewModel>();
            CreateMap<SlotGameFreeSpin, ClassicSlotSymbolViewModel>();
            CreateMap<SlotGameBonus, ClassicSlotSymbolViewModel>();
            CreateMap<SlotGameWinningLine, ClassicSlotWinningLineViewModel>();
            CreateMap<SlotGameBonusChest, ClassicSlotBonusChestViewModel>();
            CreateMap<SlotGameJackpot, ClassicSlotJackpotViewModel>();
        }
    }
}
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.PlinkoGames.ViewModels;

namespace GameRoundResult.Web.PlinkoGames.Mappers
{
    public class PlinkoGameProfile : Profile
    {
        public PlinkoGameProfile()
        {
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PlinkoGameRound, PlinkoGameRoundResultViewModel>();
        }
    }
}
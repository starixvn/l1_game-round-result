using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.PlinkoXGames.ViewModels;

namespace GameRoundResult.Web.PlinkoXGames.Mappers
{
    public class PlinkoXGameProfile : Profile
    {
        public PlinkoXGameProfile()
        {
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PlinkoXGameRound, PlinkoXGameRoundResultViewModel>();
        }
    }
}

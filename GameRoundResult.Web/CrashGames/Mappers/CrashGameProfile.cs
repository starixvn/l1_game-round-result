using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.CrashGames.ViewModels;

namespace GameRoundResult.Web.CrashGames.Mappers
{
    public class CrashGameProfile : Profile
    {
        public CrashGameProfile()
        {
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<CrashGameRound, CrashGameRoundResultViewModel>();
            CreateMap<CrashGameBetLog, CrashGameBetLogViewModel>();
        }
    }
}
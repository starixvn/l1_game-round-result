using System.Linq;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;

namespace GameRoundResult.Web.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BigSmallRound, BigSmallRoundResultViewModel>()
                .ForMember(x => x.Dices, opt => opt.MapFrom(x => new byte[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<OddEvenRound, OddEvenRoundResultViewModel>()
              .ForMember(x => x.Dices, opt => opt.MapFrom(x => new byte[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<FishPrawnRound, FishPrawnRoundResultViewModel>()
             .ForMember(x => x.Dices, opt => opt.MapFrom(x => new byte[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<SeDieRound, SeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
                {
                    x.FirstRedChip,
                    x.SecondRedChip,
                    x.ThirdRedChip,
                    x.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<MiniSeDieRound, SeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
                {
                    x.FirstRedChip,
                    x.SecondRedChip,
                    x.ThirdRedChip,
                    x.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<DragonTigerRound, DragonTigerRoundResultViewModel>();
            CreateMap<Card, CardViewModel>();

            CreateMap<BaccaratRound, BaccaratRoundResultViewModel>()
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom(x => x.Player.ThirdCard != null ?
                    new[] { x.Player.FirstCard.ToViewModel(), x.Player.SecondCard.ToViewModel(), x.Player.ThirdCard.ToViewModel() } :
                    new[] { x.Player.FirstCard.ToViewModel(), x.Player.SecondCard.ToViewModel() }))
                .ForMember(x => x.BankerCards, opt => opt.MapFrom(x => x.Banker.ThirdCard != null ?
                    new[] { x.Banker.FirstCard.ToViewModel(), x.Banker.SecondCard.ToViewModel(), x.Banker.ThirdCard.ToViewModel() } :
                    new[] { x.Banker.FirstCard.ToViewModel(), x.Banker.SecondCard.ToViewModel() }))
                .ForMember(x => x.Player, opt => opt.MapFrom(x => x.Result.Player))
                .ForMember(x => x.Banker, opt => opt.MapFrom(x => x.Result.Banker))
                .ForMember(x => x.Tie, opt => opt.MapFrom(x => x.Result.Tie))
                .ForMember(x => x.Big, opt => opt.MapFrom(x => x.Result.Big))
                .ForMember(x => x.Small, opt => opt.MapFrom(x => x.Result.Small))
                .ForMember(x => x.PlayerPair, opt => opt.MapFrom(x => x.Result.PlayerPair))
                .ForMember(x => x.BankerPair, opt => opt.MapFrom(x => x.Result.BankerPair))
                .ForMember(x => x.Natural, opt => opt.MapFrom(x => x.Result.Natural));

            CreateMap<KenoRound, KenoRoundResultViewModel>()
               .ForMember(x => x.Result, opt => opt.MapFrom(x => x.Result.ToList()))
               .ForMember(x => x.IsBig, opt => opt.MapFrom(x => x.SettlementResult.Big))
               .ForMember(x => x.IsEven, opt => opt.MapFrom(x => x.SettlementResult.Even))
               .ForMember(x => x.IsGold, opt => opt.MapFrom(x => x.SettlementResult.Gold))
               .ForMember(x => x.IsWood, opt => opt.MapFrom(x => x.SettlementResult.Wood))
               .ForMember(x => x.IsWater, opt => opt.MapFrom(x => x.SettlementResult.Water))
               .ForMember(x => x.IsFire, opt => opt.MapFrom(x => x.SettlementResult.Fire))
               .ForMember(x => x.IsEarth, opt => opt.MapFrom(x => x.SettlementResult.Earth));
        }
    }
}
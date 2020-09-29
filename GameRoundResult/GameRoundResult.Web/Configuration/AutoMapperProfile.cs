using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameTicket;

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

            CreateMap<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>()
             .ForMember(x => x.Dices, opt => opt.MapFrom(x => new byte[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<SeDieRound, SeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
                {
                    x.Result != null ? x.Result.FirstRedChip : x.FirstRedChip,
                    x.Result != null ? x.Result.SecondRedChip : x.SecondRedChip,
                    x.Result != null ? x.Result.ThirdRedChip : x.ThirdRedChip,
                    x.Result != null ? x.Result.FourthRedChip : x.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<MiniSeDieRound, SeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
                {
                    x.Result != null ? x.Result.FirstRedChip : x.FirstRedChip,
                    x.Result != null ? x.Result.SecondRedChip : x.SecondRedChip,
                    x.Result != null ? x.Result.ThirdRedChip : x.ThirdRedChip,
                    x.Result != null ? x.Result.FourthRedChip : x.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<DragonTigerRound, DragonTigerRoundResultViewModel>();
            CreateMap<Card, CardViewModel>();

            CreateMap<BaccaratRound, BaccaratRoundResultViewModel>()
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    var mapper = context.Mapper;
                    var result = new List<CardViewModel> { mapper.Map<CardViewModel>(source.Player.FirstCard), mapper.Map<CardViewModel>(source.Player.SecondCard) };
                    if (source.Player.ThirdCard != null)
                    {
                        result.Add(mapper.Map<CardViewModel>(source.Player.ThirdCard));
                    }

                    return result;
                }))
                 .ForMember(x => x.BankerCards, opt => opt.MapFrom((source, destination, i, context) =>
                 {
                     var mapper = context.Mapper;
                     var result = new List<CardViewModel> { mapper.Map<CardViewModel>(source.Banker.FirstCard), mapper.Map<CardViewModel>(source.Banker.SecondCard) };
                     if (source.Banker.ThirdCard != null)
                     {
                         result.Add(mapper.Map<CardViewModel>(source.Banker.ThirdCard));
                     }

                     return result;
                 }))
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

            CreateMap<RouletteRound, RouletteRoundResultViewModel>();
            CreateMap<RouletteSettlementResult, RouletteSettlementResultViewModel>();

            CreateMap<BigSmallBet, BigSmallBetViewModel>();
            CreateMap<OddEvenBet, OddEvenBetViewModel>();

            CreateMap<SeDieBet, SeDieBetViewModel>()
                .ForMember(x => x.Odd, opt => opt.MapFrom(x => x.Odd + x.OldOdd))
                .ForMember(x => x.Even, opt => opt.MapFrom(x => x.Even + x.OldEven));

            CreateMap<MiniSeDieBet, SeDieBetViewModel>();
            CreateMap<DragonTigerBet, DragonTigerBetViewModel>();
            CreateMap<FishPrawnCrabBet, FishPrawnCrabBetViewModel>();
            CreateMap<BaccaratBet, BaccaratBetViewModel>();
            CreateMap<KenoProMaxBet, KenoProMaxBetViewModel>();
            CreateMap<RNGKenoBet, RNGKenoBetViewModel>();
            CreateMap<RouletteBet, RouletteBetViewModel>();

            CreateMap<VipSeDieRound, VipSeDieRoundResultViewModel>()
             .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
             {
                 x.Result.FirstRedChip,
                 x.Result.SecondRedChip,
                 x.Result.ThirdRedChip,
                 x.Result.FourthRedChip
             }.OrderByDescending(x => x)));


            CreateMap<VipSeDieBet, VipSeDieBetViewModel>();
        }
    }
}
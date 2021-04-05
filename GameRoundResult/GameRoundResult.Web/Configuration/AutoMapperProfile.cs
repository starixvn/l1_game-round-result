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
                .ForMember(x => x.Dices, opt => opt.MapFrom(x => x.Result != null ? new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice } : new[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<OddEvenRound, OddEvenRoundResultViewModel>()
              .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));

            CreateMap<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>()
             .ForMember(x => x.Dices, opt => opt.MapFrom(x => x.Result != null ? new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice } : new[] { x.FirstDice, x.SecondDice, x.ThirdDice }));

            CreateMap<SeDieRound, SeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new[]
                {
                    x.Result.FirstRedChip,
                    x.Result.SecondRedChip ,
                    x.Result.ThirdRedChip,
                    x.Result.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<SeDieSettlementResultEntity, SeDieSettlementResultViewModel>();

            CreateMap<MiniSeDieRound, MiniSeDieRoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new bool[]
                {
                    x.Result != null ? x.Result.FirstRedChip : x.FirstRedChip,
                    x.Result != null ? x.Result.SecondRedChip : x.SecondRedChip,
                    x.Result != null ? x.Result.ThirdRedChip : x.ThirdRedChip,
                    x.Result != null ? x.Result.FourthRedChip : x.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<MiniSeDieSettlementResultEntity, MiniSeDieSettlementResultViewModel>();

            CreateMap<DragonTigerRound, DragonTigerRoundResultViewModel>()
                .ForMember(x => x.Dragon, opt => opt.MapFrom(x => x.Result != null ? x.Result.Dragon : x.Dragon))
                .ForMember(x => x.Tiger, opt => opt.MapFrom(x => x.Result != null ? x.Result.Tiger : x.Tiger));

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

            CreateMap<BigSmallBet, BigSmallBetViewModel>()
                .ForMember(x => x.Bet, opt => opt.MapFrom(x => x.Amount ?? x.Bet))
                .ForMember(x => x.Select, opt => opt.MapFrom(x => x.Select ?? x.Choice == "big"))
                .ForMember(x => x.Back, opt => opt.MapFrom(x => x.Back ?? x.Refund));

            CreateMap<OddEvenBet, OddEvenBetViewModel>()
                .ForMember(x => x.Bet, opt => opt.MapFrom(x => x.Amount ?? x.Bet))
                .ForMember(x => x.Select, opt => opt.MapFrom(x => x.Select ?? x.Choice == "even"))
                .ForMember(x => x.Back, opt => opt.MapFrom(x => x.Back ?? x.Refund)); ;

            CreateMap<SeDieBet, SeDieBetViewModel>();
            CreateMap<MiniSeDieBet, MiniSeDieBetViewModel>();

            CreateMap<DragonTigerBet, DragonTigerBetViewModel>();
            CreateMap<FishPrawnCrabBet, FishPrawnCrabBetViewModel>()
                .ForMember(x => x.Stag, opt => opt.MapFrom(x=> x.Stag != null ? x.Stag : x.OldStag))
                .ForMember(x => x.Gourd, opt => opt.MapFrom(x => x.Gourd != null ? x.Gourd : x.OldGourd))
                .ForMember(x => x.Rooster, opt => opt.MapFrom(x => x.Rooster != null ? x.Rooster : x.OldRooster))
                .ForMember(x => x.Fish, opt => opt.MapFrom(x => x.Fish != null ? x.Fish : x.OldFish))
                .ForMember(x => x.Crab, opt => opt.MapFrom(x => x.Crab != null ? x.Crab : x.OldCrab))
                .ForMember(x => x.Prawn, opt => opt.MapFrom(x => x.Prawn != null ? x.Prawn : x.OldPrawn));

            CreateMap<BaccaratBet, BaccaratBetViewModel>();
            CreateMap<KenoProMaxBet, KenoProMaxBetViewModel>();
            CreateMap<RNGKenoBet, RNGKenoBetViewModel>();
            CreateMap<RouletteBet, RouletteBetViewModel>();

            CreateMap<VipSeDieRound, VipSeDieRoundResultViewModel>()
             .ForMember(x => x.IsEven, opt => opt.MapFrom(x => x.SettlementResult.Even))
             .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new[]
             {
                 x.Result.FirstRedChip,
                 x.Result.SecondRedChip,
                 x.Result.ThirdRedChip,
                 x.Result.FourthRedChip
             }.OrderByDescending(x => x)));

            CreateMap<VipSeDieBet, VipSeDieBetViewModel>();

            CreateMap<BlackjackBet, BlackjackBetViewModel>();
            CreateMap<BlackjackCard, BlackjackCardViewModel>();
            CreateMap<SpecialSeDieRound, SpecialSeDieRoundResultViewModel>()
                .ForMember(x => x.IsEven, opt => opt.MapFrom(x => x.SettlementResult.Even))
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new[]
                {
                      x.Result.FirstRedChip,
                      x.Result.SecondRedChip,
                      x.Result.ThirdRedChip,
                      x.Result.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<SpecialSeDieBet, SpecialSeDieBetViewModel>();

            CreateMap<VipFishPrawnCrabRound, VipFishPrawnCrabRoundResultViewModel>()
             .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));
            CreateMap<VipFishPrawnCrabBet, VipFishPrawnCrabBetViewModel>();

            CreateMap<SicBoRound, SicBoRoundResultViewModel>()
                .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));

            CreateMap<SicBoBet, SicBoBetViewModel>();

            CreateMap<FourGuardiansRound, FourGuardiansRoundResultViewModel>();
            CreateMap<FourGuardiansSettlementResult, FourGuardiansSettlementResultViewModel>();
            CreateMap<FourGuardiansFreeSpin, FourGuardiansFreeSpinViewModel>();
            CreateMap<FourGuardiansBonus, FourGuardiansBonusViewModel>();
            CreateMap<FourGuardiansWinningLine, FourGuardiansWinningLineViewModel>();
            CreateMap<FourGuardiansBonusChest, FourGuardiansBonusChestViewModel>();
            CreateMap<FourGuardiansJackpot, FourGuardiansJackpotViewModel>();
            CreateMap<VipSeDieWarRound, VipSeDieWarRoundResultViewModel>()
              .ForMember(x => x.PlayerChips, opt => opt.MapFrom(x => new[]
              {
                    x.Result.Player.FirstChip,
                    x.Result.Player.SecondChip,
                    x.Result.Player.ThirdChip,
                    x.Result.Player.FourthChip
              }.OrderByDescending(x => x)))
              .ForMember(x => x.BankerChips, opt => opt.MapFrom(x => new[]
              {
                    x.Result.Banker.FirstChip,
                    x.Result.Banker.SecondChip,
                    x.Result.Banker.ThirdChip,
                    x.Result.Banker.FourthChip
              }.OrderByDescending(x => x)));

            CreateMap<VipSeDieWarBet, VipSeDieWarBetViewModel>();
            CreateMap<VipBaccaratRound, BaccaratRoundResultViewModel>()
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    var mapper = context.Mapper;
                    var result = new List<CardViewModel> { mapper.Map<CardViewModel>(source.Result.Player.FirstCard), mapper.Map<CardViewModel>(source.Result.Player.SecondCard) };
                    if (source.Result.Player.ThirdCard != null)
                    {
                        result.Add(mapper.Map<CardViewModel>(source.Result.Player.ThirdCard));
                    }

                    return result;
                }))
                .ForMember(x => x.BankerCards, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    var mapper = context.Mapper;
                    var result = new List<CardViewModel> { mapper.Map<CardViewModel>(source.Result.Banker.FirstCard), mapper.Map<CardViewModel>(source.Result.Banker.SecondCard) };
                    if (source.Result.Banker.ThirdCard != null)
                    {
                        result.Add(mapper.Map<CardViewModel>(source.Result.Banker.ThirdCard));
                    }

                    return result;
                }))
                .ForMember(x => x.Player, opt => opt.MapFrom(x => x.SettlementResult.Player))
                .ForMember(x => x.Banker, opt => opt.MapFrom(x => x.SettlementResult.Banker))
                .ForMember(x => x.Tie, opt => opt.MapFrom(x => x.SettlementResult.Tie))
                .ForMember(x => x.Big, opt => opt.MapFrom(x => x.SettlementResult.Big))
                .ForMember(x => x.Small, opt => opt.MapFrom(x => x.SettlementResult.Small))
                .ForMember(x => x.PlayerPair, opt => opt.MapFrom(x => x.SettlementResult.PlayerPair))
                .ForMember(x => x.BankerPair, opt => opt.MapFrom(x => x.SettlementResult.BankerPair))
                .ForMember(x => x.Natural, opt => opt.MapFrom(x => x.SettlementResult.Natural));
        }
    }
}
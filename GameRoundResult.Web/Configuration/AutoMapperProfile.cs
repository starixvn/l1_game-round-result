using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.BacBall;
using GameRoundResult.Core.Database.Entities.LuckyNext;
using GameRoundResult.Core.Database.Entities.BandarQiuQiu;
using GameRoundResult.Core.Database.Entities.ColorGame;
using GameRoundResult.Core.Database.Entities.DragonTigerFight;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Web.Models.RoundHistory;
using GameRoundResult.Core.Database.Entities.CoinToss;
using GameRoundResult.Core.Database.Entities.FootballCoinToss;
using GameRoundResult.Core.Database.Entities.KaraKrus;
using GameRoundResult.Core.Database.Entities.SevenUpDown;
using GameRoundResult.Web.Models.GameTicket;

namespace GameRoundResult.Web.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BigSmallRound, BigSmallRoundResultViewModel>()
                .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));

            CreateMap<BigSmallSettlementResult, BigSmallSettlementResultViewModel>();

            CreateMap<OddEvenRound, OddEvenRoundResultViewModel>()
              .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));

            CreateMap<FishPrawnCrabRound, FishPrawnCrabRoundResultViewModel>()
             .ForMember(x => x.Dices,
                opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice, x.Result.ThirdDice }));

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
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new[]
                {
                    x.Result.FirstRedChip,
                    x.Result.SecondRedChip ,
                    x.Result.ThirdRedChip,
                    x.Result.FourthRedChip
                }.OrderByDescending(x => x)));

            CreateMap<MiniSeDieSettlementResultEntity, MiniSeDieSettlementResultViewModel>();

            CreateMap<DragonTigerRound, DragonTigerRoundResultViewModel>()
                .ForMember(x => x.Dragon, opt => opt.MapFrom(x => x.Result.Dragon))
                .ForMember(x => x.Tiger, opt => opt.MapFrom(x => x.Result.Tiger));

            CreateMap<DragonTigerCard, DragonTigerCardViewModel>();

            CreateMap<BaccaratRound, BaccaratRoundResultViewModel>()
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    var mapper = context.Mapper;
                    var result = new List<DragonTigerCardViewModel> { mapper.Map<DragonTigerCardViewModel>(source.Player.FirstCard), mapper.Map<DragonTigerCardViewModel>(source.Player.SecondCard) };
                    if (source.Player.ThirdCard != null)
                    {
                        result.Add(mapper.Map<DragonTigerCardViewModel>(source.Player.ThirdCard));
                    }

                    return result;
                }))
                 .ForMember(x => x.BankerCards, opt => opt.MapFrom((source, destination, i, context) =>
                 {
                     var mapper = context.Mapper;
                     var result = new List<DragonTigerCardViewModel> { mapper.Map<DragonTigerCardViewModel>(source.Banker.FirstCard), mapper.Map<DragonTigerCardViewModel>(source.Banker.SecondCard) };
                     if (source.Banker.ThirdCard != null)
                     {
                         result.Add(mapper.Map<DragonTigerCardViewModel>(source.Banker.ThirdCard));
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
                .ForMember(x => x.Bet, opt => opt.MapFrom(x => x.Amount))
                .ForMember(x => x.Select, opt => opt.MapFrom(x => x.Choice == "big"))
                .ForMember(x => x.Back, opt => opt.MapFrom(x => x.Refund));

            CreateMap<OddEvenBet, OddEvenBetViewModel>()
                .ForMember(x => x.Bet, opt => opt.MapFrom(x => x.Amount))
                .ForMember(x => x.Select, opt => opt.MapFrom(x => x.Choice == "even"))
                .ForMember(x => x.Back, opt => opt.MapFrom(x => x.Refund));

            CreateMap<SeDieBet, SeDieBetViewModel>();
            CreateMap<MiniSeDieBet, MiniSeDieBetViewModel>();

            CreateMap<DragonTigerBet, DragonTigerBetViewModel>();
            CreateMap<FishPrawnCrabBet, FishPrawnCrabBetViewModel>();

            CreateMap<BaccaratBet, BaccaratBetViewModel>();
            CreateMap<KenoProMaxBet, KenoProMaxBetViewModel>();
            CreateMap<RNGKenoOnes, RNGKenoBetViewModel>();
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
            CreateMap<Card, CardViewModel>();
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
                    var result = new List<DragonTigerCardViewModel>
                    {
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Player.FirstCard),
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Player.SecondCard)
                    };
                    if (source.Result.Player.ThirdCard != null)
                    {
                        result.Add(mapper.Map<DragonTigerCardViewModel>(source.Result.Player.ThirdCard));
                    }

                    return result;
                }))
                .ForMember(x => x.BankerCards, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    var mapper = context.Mapper;
                    var result = new List<DragonTigerCardViewModel> {
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.FirstCard),
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.SecondCard)
                    };

                    if (source.Result.Banker.ThirdCard != null)
                    {
                        result.Add(mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.ThirdCard));
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

            CreateMap<LotteryRound, LotteryRoundResultViewModel>()
                .ForMember(x => x.Special, opt => opt.MapFrom(x => x.Result.Special))
                .ForMember(x => x.First, opt => opt.MapFrom(x => x.Result.First))
                .ForMember(x => x.Second, opt => opt.MapFrom(x => x.Result.Second))
                .ForMember(x => x.Third, opt => opt.MapFrom(x => x.Result.Third))
                .ForMember(x => x.Fourth, opt => opt.MapFrom(x => x.Result.Fourth))
                .ForMember(x => x.Fifth, opt => opt.MapFrom(x => x.Result.Fifth))
                .ForMember(x => x.Sixth, opt => opt.MapFrom(x => x.Result.Sixth))
                .ForMember(x => x.Seventh, opt => opt.MapFrom(x => x.Result.Seventh));

            CreateMap<LotteryBet, LotteryBetViewModel>();
            CreateMap<LotteryOdds, LotteryOddsViewModel>();
            CreateMap<LotteryChoices, LotteryChoicesViewModel>();
            CreateMap<LotterySettlementResult, LotterySettlementResultViewModel>();
            CreateMap<LotteryOccurrences, LotteryOccurrencesViewModel>();

            CreateMap<ThreeCardsRound, ThreeCardsRoundResultViewModel>();
            CreateMap<ThreeCardsSettlementResult, ThreeCardsSettlementResultViewModel>();
            CreateMap<ThreeCardsBet, ThreeCardsBetViewModel>();
            CreateMap<ThreeCardsOdds, ThreeCardsOddsViewModel>();

            CreateMap<KenoMatchRound, KenoMatchRoundResultViewModel>();
            CreateMap<KenoMatchPeriod, KenoMatchPeriodViewModel>();
            CreateMap<KenoMatchPeriodResult, KenoMatchPeriodResultViewModel>();
            CreateMap<KenoMatchPeriodSettlementResult, KenoMatchPeriodSettlementResultViewModel>();
            CreateMap<KenoMatchBet, KenoMatchBetViewModel>();

            CreateMap<KenoPowerRound, KenoPowerRoundResultViewModel>();
            CreateMap<KenoPowerResult, KenoPowerResultViewModel>();
            CreateMap<KenoPowerSettlementResult, KenoPowerSettlementResultViewModel>();
            CreateMap<KenoPowerBet, KenoPowerBetViewModel>();
            CreateMap<PokerCard, PokerCardViewModel>();
            CreateMap<BitcoinMasterRound, BitcoinMasterRoundResultViewModel>();
            CreateMap<BitcoinMasterBet, BitcoinMasterBetViewModel>()
                .ForMember(x => x.Bet, opt => opt.MapFrom(x => x.Amount));

            CreateMap<CasinoHoldemPokerBetSettlementResult, CasinoHoldemPokerDetailBetViewModel>();
            CreateMap<CasinoHoldemPokerBet, CasinoHoldemPokerBetViewModel>()
                .ForMember(x => x.CombinationCards, opt => opt.MapFrom(x => x.Result.Cards))
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom(x => x.Cards))
                .ForMember(x => x.HandRankId, opt => opt.MapFrom(x => x.Result.HandRankId))
                .ForMember(x => x.SettlementResult, opt => opt.MapFrom(x => x.SettlementResult));
            CreateMap<CasinoHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>()
                .ForMember(x => x.CommunityCards, opt => opt.MapFrom(x => x.Result.CommunityCards))
                .ForMember(x => x.DealerCards, opt => opt.MapFrom(x => x.Result.Dealer))
                .ForMember(x => x.DealerCombinationCards, opt
                    => opt.MapFrom(x => x.Ended ? x.SettlementResult.Cards : new List<PokerCard>()))
                .ForMember(x => x.HandRankId, opt => opt.MapFrom(x
                => x.Ended ? x.SettlementResult.HandRankId
                : 0))
                .ForMember(x => x.IsQualified, opt => opt.MapFrom(x => x.SettlementResult.IsQualified ?? false));

            CreateMap<HiLoRound, HiLoRoundResultViewModel>();
            CreateMap<HiLoBetLog, HiLoBetLogViewModel>();

            CreateMap<TexasHoldemPokerBetSettlementResult, TexasHoldemPokerDetailBetViewModel>();
            CreateMap<TexasHoldemPokerBet, TexasHoldemPokerBetViewModel>()
                .ForMember(x => x.CombinationCards, opt => opt.MapFrom(x => x.Result.Cards))
                .ForMember(x => x.PlayerCards, opt => opt.MapFrom(x => x.Cards))
                .ForMember(x => x.HandRankId, opt => opt.MapFrom(x => x.Result.HandRankId))
                .ForMember(x => x.SettlementResult, opt => opt.MapFrom(x => x.SettlementResult));
            CreateMap<TexasHoldemPokerRound, CasinoHoldemPokerRoundResultViewModel>()
                .ForMember(x => x.CommunityCards, opt => opt.MapFrom(x => x.Result.CommunityCards))
                .ForMember(x => x.DealerCards, opt => opt.MapFrom(x => x.Result.Dealer))
                .ForMember(x => x.DealerCombinationCards, opt
                    => opt.MapFrom(x => x.Ended ? x.SettlementResult.Cards : new List<PokerCard>()))
                .ForMember(x => x.HandRankId, opt => opt.MapFrom(x
                => x.Ended ? x.SettlementResult.HandRankId
                : 0));

            CreateMap<UnbalancedBigSmallBetLog, UnbalancedBigSmallBetLogViewModel>();

            CreateMap<BaccaratCard, DragonTigerCardViewModel>();
            CreateMap<BlockchainBaccaratRound, BaccaratRoundResultViewModel>()
             .ForMember(x => x.PlayerCards, opt => opt.MapFrom((source, destination, i, context) =>
             {
                 var mapper = context.Mapper;
                 var result = new List<DragonTigerCardViewModel>
                 {
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Player.FirstCard),
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Player.SecondCard)
                 };
                 if (source.Result.Player.ThirdCard != null)
                 {
                     result.Add(mapper.Map<DragonTigerCardViewModel>(source.Result.Player.ThirdCard));
                 }

                 return result;
             }))
             .ForMember(x => x.BankerCards, opt => opt.MapFrom((source, destination, i, context) =>
             {
                 var mapper = context.Mapper;
                 var result = new List<DragonTigerCardViewModel> {
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.FirstCard),
                        mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.SecondCard)
                 };

                 if (source.Result.Banker.ThirdCard != null)
                 {
                     result.Add(mapper.Map<DragonTigerCardViewModel>(source.Result.Banker.ThirdCard));
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

            CreateMap<FanTanRound, FanTanRoundResultViewModel>();
            CreateMap<FanTanResultEntity, FanTanResultViewModel>();
            CreateMap<FanTanSettlementResult, FanTanSettlementResultViewModel>();
            CreateMap<FanTanBet, FanTanBetViewModel>();

            CreateMap<FruitSlotRound, FruitSlotRoundResultViewModel>()
                .ForMember(x => x.SymbolsResult, opt => opt.MapFrom(x => x.Result.Symbols))
                .ForMember(x => x.NumberResult, opt => opt.MapFrom(x => x.Result.Number));
            CreateMap<FruitSlotBetLog, FruitSlotBetLogViewModel>();

            CreateMap<Win3CardsRound, Win3CardsRoundResultViewModel>();
            CreateMap<Win3CardsResult, Win3CardsResultViewModel>();
            CreateMap<Win3CardsHand, Win3CardsHandViewModel>()
                .ForMember(x => x.Cards,
                    opt => opt.MapFrom((source, destination, i, context) =>
                    {
                        var mapper = context.Mapper;
                        return new List<PokerCardViewModel>() {
                            mapper.Map<PokerCardViewModel>(source.Cards.Card1),
                            mapper.Map<PokerCardViewModel>(source.Cards.Card2),
                            mapper.Map<PokerCardViewModel>(source.Cards.Card3)
                        };
                    }));
            CreateMap<Win3CardsSettlementResult, Win3CardsSettlementResultViewModel>();

            CreateMap<Win3CardsBetLog, Win3CardsBetLogViewModel>();
            CreateMap<DragonTigerFightRound, DragonTigerFightRoundResultViewModel>()
                .ForMember(x => x.Result, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    return new DragonTigerFightResultViewModel
                    {
                        Dragon = new Models.DragonTigerFightCard { Rank = source.Result.Dragon.Rank, Suit = source.Result.Dragon.Suit },
                        Tiger = new Models.DragonTigerFightCard { Rank = source.Result.Tiger.Rank, Suit = source.Result.Tiger.Suit }
                    };
                }))
                .ForMember(x => x.SettlementResult, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    return new DragonTigerFightSettlementResultViewModel
                    {
                        Dragon = source.SettlementResult.Dragon,
                        Tiger = source.SettlementResult.Tiger,
                        Tie = source.SettlementResult.Tie,
                        BlackDragon = source.SettlementResult.BlackDragon,
                        BlackTiger = source.SettlementResult.BlackTiger,
                        RedDragon = source.SettlementResult.RedDragon,
                        RedTiger = source.SettlementResult.RedTiger,
                    };
                }));
            CreateMap<DragonTigerFightBetLog, DragonTigerFightBetLogViewModel>();
            CreateMap<ColorGameRound, ColorGameRoundResultViewModel>()
                .ForMember(x => x.Result, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    return new ColorGameResultViewModel
                    {
                        Dice1 = source.Result.Dice1,
                        Dice2 = source.Result.Dice2,
                        Dice3 = source.Result.Dice3,
                    };
                }));

            CreateMap<ColorGameBetLog, ColorGameBetLogViewModel>();

            CreateMap<BandarQiuQiuRound, BandarQiuQiuRoundResultViewModel>()
                .ForMember(x => x.Result, opt => opt.MapFrom((source, destination, i, context) =>
                {
                    return new BandarQiuQiuRoundResultModel
                    {
                        Banker = new BandarQiuQiuResultItemViewModel()
                        {
                            Dominoes = source.Result.Banker.Dominoes,
                            HandRankingId = source.Result.Banker.HandRankingId,
                            PipsOfSet = source.Result.Banker.PipsOfSet
                        },
                        Spade = new BandarQiuQiuResultItemViewModel()
                        {
                            Dominoes = source.Result.Spade.Dominoes,
                            HandRankingId = source.Result.Spade.HandRankingId,
                            PipsOfSet = source.Result.Spade.PipsOfSet
                        },
                        Heart = new BandarQiuQiuResultItemViewModel()
                        {
                            Dominoes = source.Result.Heart.Dominoes,
                            HandRankingId = source.Result.Heart.HandRankingId,
                            PipsOfSet = source.Result.Heart.PipsOfSet
                        },
                        Club = new BandarQiuQiuResultItemViewModel()
                        {
                            Dominoes = source.Result.Club.Dominoes,
                            HandRankingId = source.Result.Club.HandRankingId,
                            PipsOfSet = source.Result.Club.PipsOfSet
                        },
                        Diamond = new BandarQiuQiuResultItemViewModel()
                        {
                            Dominoes = source.Result.Diamond.Dominoes,
                            HandRankingId = source.Result.Diamond.HandRankingId,
                            PipsOfSet = source.Result.Diamond.PipsOfSet
                        },
                    };
                }));

            CreateMap<BandarQiuQiuBetLog, BandarQiuQiuBetLogViewModel>();

            CreateMap<FootballDiceBetLog, FootballDiceBetLogViewModel>();
            CreateMap<FootballDiceRound, FootballDiceRoundResultViewModel>()
            .ForMember(x => x.Result, opt => opt.MapFrom((source, destination, i, context) =>
            {
                return new FootballDiceResultViewModel
                {
                    Home = source.Result.Home,
                    Away = source.Result.Away,
                    HomeValue = source.Result.Home.ElementAt(0) + source.Result.Home.ElementAt(1),
                    AwayValue = source.Result.Away.ElementAt(0) + source.Result.Away.ElementAt(1),
                };
            }));

            CreateMap<FootballSlotRound, FootballSlotRoundResultViewModel>()
                .ForMember(x => x.SymbolsResult, opt => opt.MapFrom(x => x.Result.Symbols))
                .ForMember(x => x.NumberResult, opt => opt.MapFrom(x => x.Result.Number));
            CreateMap<FootballSlotBetLog, FootballSlotBetLogViewModel>();

            CreateMap<BacBall1BetLog, TranslationBetLogViewModel>();
            CreateMap<BacBall1Round, BacBallRoundResultViewModel>();

            CreateMap<BacBall2BetLog, TranslationBetLogViewModel>();
            CreateMap<BacBall2Round, BacBallRoundResultViewModel>();

            CreateMap<LuckyNext1BetLog, TranslationBetLogViewModel>();
            CreateMap<LuckyNext1Round, LuckyNextRoundResultViewModel>();

            CreateMap<LuckyNext2BetLog, TranslationBetLogViewModel>();
            CreateMap<LuckyNext2Round, LuckyNextRoundResultViewModel>();

            CreateMap<RoundHistoryBetEntity, RoundHistoryBetViewModel>();

            CreateMap<CoinTossRound, CoinTossRoundResultViewModel>();
            CreateMap<CoinTossBetLog, BetLogViewModel>();

            CreateMap<SeBall1BetLog, TranslationBetLogViewModel>();
            CreateMap<SeBall1Round, SeBallRoundResultViewModel>();
            CreateMap<LuckyThreeBetLog, TranslationBetLogViewModel>();
            CreateMap<LuckyThreeRound, LuckyThreeRoundResultViewModel>();

            CreateMap<RoundHistoryBetEntity, RoundHistoryBetViewModel>();

            CreateMap<FootballCoinTossRound, FootballCoinTossRoundResultViewModel>();
            CreateMap<FootballCoinTossBetLog, BetLogViewModel>();
            CreateMap<BaccaratXRound, BaccaratXRoundResultViewModel>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            CreateMap<BaccaratXBetLog, BaccaratXBetLogViewModel>();
            CreateMap<SeDie3Bet, SeDie3BetViewModel>();
            CreateMap<SeDie3Round, SeDie3RoundResultViewModel>()
                .ForMember(x => x.RedChips, opt => opt.MapFrom(x => new[]
                {
                    x.Result.FirstRedChip,
                    x.Result.SecondRedChip ,
                    x.Result.ThirdRedChip
                }.OrderByDescending(x => x)));
            CreateMap<SeDie3SettlementResultEntity, SeDie3SettlementResultViewModel>();
            CreateMap<SeDie3BetLog, SeDie3BetLogViewModel>();
            CreateMap<KaraKrusRound, KaraKrusRoundResultViewModel>()
                .ForMember(x => x.HeadChips, opt => opt.MapFrom(x => new[]
                {
                    x.Result.FirstHeadChip,
                    x.Result.SecondHeadChip ,
                    x.Result.ThirdHeadChip
                }.OrderByDescending(x => x)));
            CreateMap<KaraKrusSettlementResultEntity, KaraKrusSettlementResultViewModel>();
            CreateMap<KaraKrusBetLog, KaraKrusBetLogViewModel>();
            CreateMap<SevenUpDownRound, SevenUpDownRoundResultViewModel>()
                .ForMember(x => x.Dices, opt => opt.MapFrom(x => new[] { x.Result.FirstDice, x.Result.SecondDice }))
                .ForMember(dest => dest.Multiplier, opt => opt.MapFrom(src => new MultiplierViewModel
                {
                    Value = src.Result.Multiplier.Value,
                    Choice = src.Result.Multiplier.Choice
                }));
            CreateMap<SevenUpDownSettlementResultEntity, SevenUpDownSettlementResultViewModel>();
            CreateMap<SevenUpDownBetLog, SevenUpDownBetLogViewModel>();

        }
    }
}
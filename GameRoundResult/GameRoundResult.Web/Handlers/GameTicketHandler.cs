using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameTicket;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class GameTicketHandler : IRequestHandler<GetGameTicketRequest, GameTicketViewModel>
    {
        private readonly IGameBetService service;
        private readonly IMapper mapper;

        public GameTicketHandler(IGameBetService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<GameTicketViewModel> Handle(GetGameTicketRequest request, CancellationToken cancellationToken)
        {
            switch (request.GameType)
            {
                case GameType.BigSmall:
                    var bigSmallResult = await service.GetBigSmallAsync(request.RoundId, request.MemberId);
                    return new BigSmallTicketViewModel
                    {
                        RoundResult = bigSmallResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = bigSmallResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.BigSmallTurbo:
                    var bigSmallTurboResult = await service.GetBigSmallTurboAsync(request.RoundId, request.MemberId);
                    return new BigSmallTicketViewModel
                    {
                        RoundResult = bigSmallTurboResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = bigSmallTurboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.OddEven:
                    var oddEvenResult = await service.GetOddEvenAsync(request.RoundId, request.MemberId);
                    return new OddEvenTicketViewModel
                    {
                        RoundResult = oddEvenResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = oddEvenResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.OddEvenTurbo:
                    var oddEvenTurboResult = await service.GetOddEvenTurboAsync(request.RoundId, request.MemberId);
                    return new OddEvenTicketViewModel
                    {
                        RoundResult = oddEvenTurboResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = oddEvenTurboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo))
                    };

                case GameType.SeDie:
                    var seDieResult = await service.GetSeDieAsync(request.RoundId, request.MemberId, request.FreeBet);
                    return new SeDieTicketViewModel
                    {
                        RoundResult = seDieResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = seDieResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.MiniSeDie:
                    var miniSeDieResult = await service.GetMiniSeDieAsync(request.RoundId, request.MemberId);
                    return new SeDieTicketViewModel
                    {
                        RoundResult = miniSeDieResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = miniSeDieResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.DragonTiger:
                    var dragonTigerResult = await service.GetDragonTigerAsync(request.RoundId, request.MemberId);
                    return new DragonTigerTicketViewModel
                    {
                        RoundResult = dragonTigerResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = dragonTigerResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.FishPrawnCrab:
                    var fishPrawnCrabResult = await service.GetFishPrawnCrabAsync(request.RoundId, request.MemberId);
                    return new FishPrawnCrabTicketViewModel
                    {
                        RoundResult = fishPrawnCrabResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = fishPrawnCrabResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.Baccarat:
                    var baccaratResult = await service.GetBaccaratAsync(request.RoundId, request.MemberId);
                    return new BaccaratTicketViewModel
                    {
                        RoundResult = baccaratResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = baccaratResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.KenoProMax:
                    var kenoProMaxResult = await service.GetKenoProMaxAsync(request.RoundId, request.MemberId);
                    return new KenoProMaxTicketViewModel
                    {
                        RoundResult = kenoProMaxResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = kenoProMaxResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };

                case GameType.KenoProViet:
                    var kenoProVietResult = await service.GetKenoProVietAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoProVietResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoProVietResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoProVietResult.Item3 ?? 0
                    };

                case GameType.KenoMax:
                    var kenoMaxResult = await service.GetKenoMaxAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoMaxResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoMaxResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoMaxResult.Item3 ?? 0
                    };

                case GameType.KenoMax2:
                    var kenoMax2Result = await service.GetKenoMax2Async(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoMax2Result.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoMax2Result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoMax2Result.Item3 ?? 0
                    };

                case GameType.KenoMini:
                    var kenoMiniResult = await service.GetKenoMiniAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoMiniResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoMiniResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoMiniResult.Item3 ?? 0
                    };

                case GameType.KenoMini2:
                    var kenoMini2Result = await service.GetKenoMini2Async(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoMini2Result.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoMini2Result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoMini2Result.Item3 ?? 0
                    };

                case GameType.KenoEast:
                    var kenoEastResult = await service.GetKenoEastAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoEastResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoEastResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoEastResult.Item3 ?? 0
                    };

                case GameType.KenoWest:
                    var kenoWestResult = await service.GetKenoWestAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoWestResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoWestResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoWestResult.Item3 ?? 0
                    };

                case GameType.KenoSouth:
                    var kenoSouthResult = await service.GetKenoSouthAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoSouthResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoSouthResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoSouthResult.Item3 ?? 0
                    };

                case GameType.KenoNorth:
                    var kenoNorthResult = await service.GetKenoNorthAsync(request.RoundId, request.MemberId);
                    return new RNGKenoTicketViewModel
                    {
                        RoundResult = kenoNorthResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = kenoNorthResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalWin = kenoNorthResult.Item3 ?? 0
                    };

                case GameType.Roulette:
                    var rouletteResult = await service.GetRouletteAsync(request.RoundId, request.MemberId);
                    return new RouletteTicketViewModel
                    {
                        RoundResult = rouletteResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = rouletteResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalBet = rouletteResult.Item3?.TotalAmount ?? 0,
                        BetWin = rouletteResult.Item3?.Betwin ?? 0,
                    };

                case GameType.VipSeDie:
                    var vipSeDieResult = await service.GetVipSeDieAsync(request.RoundId, request.MemberId);
                    return new VipSeDieTicketViewModel
                    {
                        RoundResult = vipSeDieResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = vipSeDieResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo),
                    };

                case GameType.Blackjack:
                    var blackjackResult = await service.GetBlackjackAsync(request.RoundId, request.MemberId);
                    return new BlackjackTicketViewModel
                    {
                        DealerCards = blackjackResult.Item1?.Result.Select(x => mapper.Map<BlackjackCardViewModel>(x)),
                        DealerPoint = blackjackResult.Item1?.SettlementResult ?? 0,
                        Ended = blackjackResult.Item1?.Ended ?? false,
                        Bet = blackjackResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo),
                    };

                case GameType.SpecialSeDie:
                    var specialSeDieResult = await service.GetSpecialSeDieAsync(request.RoundId, request.MemberId);
                    return new SpecialSeDieTicketViewModel

                    {
                        RoundResult = specialSeDieResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = specialSeDieResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalBet = specialSeDieResult.Item3?.Amount ?? 0,
                        TotalRefund = specialSeDieResult.Item3?.Refund ?? 0,
                        TotalBetWin = specialSeDieResult.Item3?.Betwin ?? 0
                    };

                case GameType.VipFishPrawnCrab:
                    var vipFishPrawnCrabResult = await service.GetVipFishPrawnCrabAsync(request.RoundId, request.MemberId);
                    return new VipFishPrawnCrabTicketViewModel
                    {
                        RoundResult = vipFishPrawnCrabResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = vipFishPrawnCrabResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };
                case GameType.SicBo:
                    var sicboResult = await service.GetSicBoAsync(request.RoundId, request.MemberId);
                    return new SicBoTicketViewModel
                    {
                        RoundResult = sicboResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = sicboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalBet = sicboResult.Item3?.TotalAmount ?? 0,
                        TotalBetWin = sicboResult.Item3?.Betwin ?? 0
                    };
                case GameType.SeDieWar:
                    var vipSeDieWarResult = await service.GetVipSeDieWarAsync(request.RoundId, request.MemberId);
                    return new VipSeDieWarTicketViewModel
                    {
                        RoundResult = vipSeDieWarResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bets = vipSeDieWarResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)),
                        TotalBet = vipSeDieWarResult.Item3?.TotalAmount ?? 0,
                        TotalBetWin = vipSeDieWarResult.Item3?.Betwin ?? 0
                    };
                 case GameType.VipBaccarat:
                    var vipBaccaratResult = await service.GetVipBaccaratAsync(request.RoundId, request.MemberId);
                    return new BaccaratTicketViewModel
                    {
                        RoundResult = vipBaccaratResult.Item1?.ToViewModel(mapper, request.TimeZoneInfo),
                        Bet = vipBaccaratResult.Item2?.ToViewModel(mapper, request.TimeZoneInfo)
                    };
                default:
                    throw new ArgumentException(nameof(GetGameTicketRequest.GameType));
            }
        }
    }
}

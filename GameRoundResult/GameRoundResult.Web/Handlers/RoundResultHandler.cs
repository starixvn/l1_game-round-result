using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Extensions;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;
using MediatR;

namespace GameRoundResult.Web.Handlers
{
    public class RoundResultHandler : IRequestHandler<GetRoundResultRequest, (long, IEnumerable<RoundResultViewModel>)>
    {
        private readonly IGameRoundResultService gameRoundResultService;
        private readonly IMapper mapper;

        public RoundResultHandler(IGameRoundResultService gameRoundResultService, IMapper mapper)
        {
            this.gameRoundResultService = gameRoundResultService;
            this.mapper = mapper;
        }

        public async Task<(long, IEnumerable<RoundResultViewModel>)> Handle(GetRoundResultRequest request, CancellationToken cancellationToken)
        {
            var utcDate = TimeZoneInfo.ConvertTimeToUtc(request.Date, request.TimeZoneInfo);

            switch (request.GameType)
            {
                case GameType.BigSmall:
                    var bigSmallResult = await gameRoundResultService.GetBigSmallRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (bigSmallResult.Item1, bigSmallResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.BigSmallTurbo:
                    var bigSmallTurbo = await gameRoundResultService.GetBigSmallTurboRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (bigSmallTurbo.Item1, bigSmallTurbo.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.OddEven:
                    var oddEvenResult = await gameRoundResultService.GetOddEvenRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (oddEvenResult.Item1, oddEvenResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.OddEvenTurbo:
                    var oddEvenTurboResult = await gameRoundResultService.GetOddEvenTurboRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (oddEvenTurboResult.Item1, oddEvenTurboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.SeDie:
                    var shakeThePlateResult = await gameRoundResultService.GetShakeThePlateRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (shakeThePlateResult.Item1, shakeThePlateResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.FishPrawnCrab:
                    var fishPrawnResult = await gameRoundResultService.GetFishPrawnRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (fishPrawnResult.Item1, fishPrawnResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.DragonTiger:
                    var dragonTigerResult = await gameRoundResultService.GetDragonTigerRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (dragonTigerResult.Item1, dragonTigerResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoProMax:
                    var kenoResult = await gameRoundResultService.GetKenoProMaxRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoResult.Item1, kenoResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.MiniSeDie:
                    var miniSeDieResult = await gameRoundResultService.GetMiniSeDieRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (miniSeDieResult.Item1, miniSeDieResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoProViet:
                    var kenoProVietResult = await gameRoundResultService.GetKenoProVietRoundResult(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoProVietResult.Item1, kenoProVietResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.Baccarat:
                    var baccaratRoundResult = await gameRoundResultService.GetBaccaratRoundResult(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (baccaratRoundResult.Item1, baccaratRoundResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoMax:
                    var kenoMaxResult = await gameRoundResultService.GetKenoMaxRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoMaxResult.Item1, kenoMaxResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoMax2:
                    var kenoMax2Result = await gameRoundResultService.GetKenoMax2RoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoMax2Result.Item1, kenoMax2Result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoMini:
                    var kenoMiniResult = await gameRoundResultService.GetKenoMiniRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoMiniResult.Item1, kenoMiniResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoMini2:
                    var kenoMini2Result = await gameRoundResultService.GetKenoMini2RoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoMini2Result.Item1, kenoMini2Result.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoEast:
                    var kenoEastResult = await gameRoundResultService.GetKenoEastRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoEastResult.Item1, kenoEastResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoWest:
                    var kenoWestResult = await gameRoundResultService.GetKenoWestRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoWestResult.Item1, kenoWestResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoSouth:
                    var kenoSouthResult = await gameRoundResultService.GetKenoSouthRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoSouthResult.Item1, kenoSouthResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.KenoNorth:
                    var kenoNorthResult = await gameRoundResultService.GetKenoNorthRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (kenoNorthResult.Item1, kenoNorthResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.Roulette:
                    var rouletteResult = await gameRoundResultService.GetRouletteRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (rouletteResult.Item1, rouletteResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.VipSeDie:
                    var vipSeDieResult = await gameRoundResultService.GetVipSeDieRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (vipSeDieResult.Item1, vipSeDieResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.SpecialSeDie:
                    var specialSeDieResult = await gameRoundResultService.GetSpecialSeDieRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (specialSeDieResult.Item1, specialSeDieResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.VipFishPrawnCrab:
                    var vipFishPrawnCrabResult = await gameRoundResultService.GetVipFishPrawnRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (vipFishPrawnCrabResult.Item1, vipFishPrawnCrabResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));

                case GameType.SicBo:
                    var sicboResult = await gameRoundResultService.GetSicBoRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (sicboResult.Item1, sicboResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));
		case GameType.SeDieWar:
                    var vipSeDieWar = await gameRoundResultService.GetVipSeDieWarRoundResultAsync(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (vipSeDieWar.Item1, vipSeDieWar.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));
                    
                case GameType.VipBaccarat:
                    var vipBaccaratRoundResult = await gameRoundResultService.GetVipBaccaratRoundResult(utcDate, request.RoundId, request.Page, request.PageSize);
                    return (vipBaccaratRoundResult.Item1, vipBaccaratRoundResult.Item2.Select(x => x.ToViewModel(mapper, request.TimeZoneInfo)));
                default:
                    throw new ArgumentException(nameof(GetRoundResultRequest.GameType));
            }
        }
    }
}

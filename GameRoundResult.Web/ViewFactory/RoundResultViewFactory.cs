using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.ViewFactory
{
    public interface IRoundResultViewFactory
    {
        string GetView(GameType game);
    }

    public class RoundResultViewFactory : IRoundResultViewFactory
    {
        private readonly Dictionary<GameType, string> views = new()
        {
            { GameType.BigSmall, "_BigSmallRoundResult" },
            { GameType.SeDie, "_SeDieRoundResult" },
            { GameType.FishPrawnCrab, "_FishPrawnRoundResult" },
            { GameType.BigSmallTurbo, "_BigSmallRoundResult" },
            { GameType.OddEvenTurbo, "_OddEvenRoundResult" },
            { GameType.DragonTiger, "_DragonTigerRoundResult" },
            { GameType.KenoProMax, "_KenoProMaxRoundResult" },
            { GameType.MiniSeDie, "_SeDieRoundResult" },
            { GameType.Baccarat, "_BaccaratRoundResult" },
            { GameType.KenoMax, "_KenoProMaxRoundResult" },
            { GameType.KenoMax2, "_KenoProMaxRoundResult" },
            { GameType.KenoMini, "_KenoProMaxRoundResult" },
            { GameType.KenoMini2, "_KenoProMaxRoundResult" },
            { GameType.KenoEast, "_KenoProMaxRoundResult" },
            { GameType.KenoWest, "_KenoProMaxRoundResult" },
            { GameType.KenoSouth, "_KenoProMaxRoundResult" },
            { GameType.KenoNorth, "_KenoProMaxRoundResult" },
            { GameType.Roulette, "_RouletteRoundResult" },
            { GameType.VipSeDie, "_SeDieRoundResult" },
            { GameType.SpecialSeDie, "_SeDieRoundResult" },
            { GameType.SicBo, "_SicBoRoundResult" },
            { GameType.VipFishPrawnCrab, "_FishPrawnRoundResult" },
            { GameType.VipBaccarat, "_BaccaratRoundResult" },
            { GameType.SeDieWar, "_VipSeDieWarRoundResult" },
            { GameType.Lottery, "_LotteryRoundResult" },
            { GameType.ThreeCards, "_ThreeCardsRoundResult" },
            { GameType.MyDinh, "_KenoSoccerRoundResult" },
            { GameType.HangDay, "_KenoSoccerRoundResult" },
            { GameType.ThongNhat, "_KenoSoccerRoundResult" },
        };

        public string GetView(GameType game) => views[game];
    }
}
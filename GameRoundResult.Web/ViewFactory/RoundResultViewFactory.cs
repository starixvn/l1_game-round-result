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
        private const string bigSmall = "_BigSmallRoundResult";
        private const string oddEven = "_OddEvenRoundResult";
        private const string sedie = "_SeDieRoundResult";
        private const string keno = "_KenoProMaxRoundResult";
        private const string kenoMatch = "_KenoMatchRoundResult";
        private const string fishPrawnCrab = "_FishPrawnRoundResult";
        private const string baccarat = "_BaccaratRoundResult";
        private const string dragonTiger = "_DragonTigerRoundResult";
        private const string roulette = "_RouletteRoundResult";
        private const string sicbo = "_SicBoRoundResult";
        private const string sedieWar = "_VipSeDieWarRoundResult";
        private const string lottery = "_LotteryRoundResult";
        private const string threeCards = "_ThreeCardsRoundResult";
        private const string kenoPower = "_KenoPowerRoundResult";
        private const string bitcoinMaster = "_BitcoinMasterRoundResult";
        private const string casinoHoldemPoker = "_CasinoHoldemPokerRoundResult";

        private readonly Dictionary<GameType, string> views = new()
        {
            { GameType.BigSmall, bigSmall },
            { GameType.SeDie, sedie },
            { GameType.FishPrawnCrab, fishPrawnCrab },
            { GameType.BigSmallTurbo, bigSmall },
            { GameType.OddEvenTurbo, oddEven },
            { GameType.DragonTiger, dragonTiger },
            { GameType.KenoProMax, keno },
            { GameType.MiniSeDie, sedie },
            { GameType.Baccarat, baccarat },
            { GameType.KenoMax, keno },
            { GameType.KenoMax2, keno },
            { GameType.KenoMini, keno },
            { GameType.KenoMini2, keno },
            { GameType.KenoEast, keno },
            { GameType.KenoWest, keno },
            { GameType.KenoSouth, keno },
            { GameType.KenoNorth, keno },
            { GameType.Roulette, roulette },
            { GameType.VipSeDie, sedie },
            { GameType.SpecialSeDie, sedie },
            { GameType.SicBo, sicbo },
            { GameType.VipFishPrawnCrab, fishPrawnCrab },
            { GameType.VipBaccarat, baccarat },
            { GameType.SeDieWar, sedieWar },
            { GameType.Lottery, lottery },
            { GameType.ThreeCards, threeCards },
            { GameType.KenoMatch1, kenoMatch },
            { GameType.KenoMatch2, kenoMatch },
            { GameType.KenoPower1, kenoPower },
            { GameType.KenoPower2, kenoPower },
            { GameType.BitcoinMaster, bitcoinMaster },
            { GameType.CasinoHoldemPoker, casinoHoldemPoker },
            { GameType.BlockchainBaccarat, baccarat },
        };

        public string GetView(GameType game) => views[game];
    }
}
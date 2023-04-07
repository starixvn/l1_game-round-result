using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.ViewFactory
{
    public interface IRoundResultViewFactory
    {
        string GetView(GameId game);
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
        private const string fruitSlot = "_FruitSlotRoundResult";
        private const string fantan = "_FanTanRoundResult";
        private const string win3Cards = "_Win3CardsRoundResult";

        private readonly Dictionary<GameId, string> views = new()
        {
            { GameId.BigSmall, bigSmall },
            { GameId.SeDie, sedie },
            { GameId.FishPrawnCrab, fishPrawnCrab },
            { GameId.BigSmallTurbo, bigSmall },
            { GameId.OddEvenTurbo, oddEven },
            { GameId.DragonTiger, dragonTiger },
            { GameId.KenoProMax, keno },
            { GameId.MiniSeDie, sedie },
            { GameId.Baccarat, baccarat },
            { GameId.KenoMax, keno },
            { GameId.KenoMax2, keno },
            { GameId.KenoMini, keno },
            { GameId.KenoMini2, keno },
            { GameId.KenoEast, keno },
            { GameId.KenoWest, keno },
            { GameId.KenoSouth, keno },
            { GameId.KenoNorth, keno },
            { GameId.Roulette, roulette },
            { GameId.VipSeDie, sedie },
            { GameId.SpecialSeDie, sedie },
            { GameId.SicBo, sicbo },
            { GameId.VipFishPrawnCrab, fishPrawnCrab },
            { GameId.VipBaccarat, baccarat },
            { GameId.SeDieWar, sedieWar },
            { GameId.Lottery, lottery },
            { GameId.ThreeCards, threeCards },
            { GameId.KenoMatch1, kenoMatch },
            { GameId.KenoMatch2, kenoMatch },
            { GameId.KenoPower1, kenoPower },
            { GameId.KenoPower2, kenoPower },
            { GameId.BitcoinMaster, bitcoinMaster },
            { GameId.CasinoHoldemPoker, casinoHoldemPoker },
            { GameId.BlockchainBaccarat, baccarat },
            { GameId.MegaKeno, keno },
            { GameId.MegaKeno2, keno },
            { GameId.UnbalancedBigSmall1, bigSmall },
            { GameId.UnbalancedBigSmall2, bigSmall },
            { GameId.UnbalancedBigSmall3, bigSmall },
            { GameId.UnbalancedBigSmall4, bigSmall },
            { GameId.MiniSeDie2, sedie },
            { GameId.MiniSeDie3, sedie },
            { GameId.MiniSeDie4, sedie },
            { GameId.FruitSlot, fruitSlot },
            { GameId.FanTan, fantan },
            { GameId.WinThreeCards, win3Cards},
        };

        public string GetView(GameId game) => views[game];
    }
}
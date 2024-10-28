using System.Collections.Generic;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.ViewFactory
{
    public interface IRoundResultViewFactory
    {
        string GetView(GameType game, bool isCrashGame);
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
        private const string dragonTigerFight = "_DragonTigerFightRoundResult";
        private const string colorGame = "_ColorGameRoundResult";
        private const string bandarQiuQiu = "_BandarQiuQiuRoundResult";
        private const string footballDice = "_FootballDiceRoundResult";
        private const string footballSlot = "_FootballSlotRoundResult";
        private const string cointoss = "_CoinTossRoundResult";
        private const string footballcointoss = "_FootballCoinTossRoundResult";
        private const string baccaratX = "_BaccaratXRoundResult";
        private const string sedie3 = "_SeDie3RoundResult";
        private const string karakrus = "_KaraKrusRoundResult";
        private const string sevenupdown = "_SevenUpDownRoundResult";

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
            { GameType.MegaKeno, keno },
            { GameType.MegaKeno2, keno },
            { GameType.UnbalancedBigSmall1, bigSmall },
            { GameType.UnbalancedBigSmall2, bigSmall },
            { GameType.UnbalancedBigSmall3, bigSmall },
            { GameType.UnbalancedBigSmall4, bigSmall },
            { GameType.MiniSeDie2, sedie },
            { GameType.MiniSeDie3, sedie },
            { GameType.MiniSeDie4, sedie },
            { GameType.FruitSlot, fruitSlot },
            { GameType.FanTan, fantan },
            { GameType.WinThreeCards, win3Cards},
            { GameType.DragonTigerFight, dragonTigerFight },
            { GameType.ColorGame, colorGame },
            { GameType.BandarQiuQiu, bandarQiuQiu },
            { GameType.FootballDice, footballDice },
            { GameType.FootballSlot, footballSlot },
            { GameType.CoinToss, cointoss },
            { GameType.FootballCoinToss, footballcointoss },
            { GameType.Bac81, baccaratX },
            { GameType.Bac82, baccaratX },
            { GameType.Bac83, baccaratX },
            { GameType.Bac84, baccarat },
            { GameType.Bac85, baccarat },
            { GameType.Bac86, baccarat },
            { GameType.Bac87, baccarat },
            { GameType.Bac88, baccaratX },
            { GameType.Bac89, baccaratX },
            { GameType.Bac90, baccarat },
            { GameType.Bac91, baccarat },
            { GameType.Bac92, baccarat },
            { GameType.SeDie3, sedie3 },
            { GameType.KaraKrus, karakrus },
            { GameType.Bac97, baccarat },
            { GameType.Bac98, baccarat },
            { GameType.Bac100, baccarat },
            { GameType.Bac101, baccarat },
            { GameType.SevenUpDown, sevenupdown },
        };

        public string GetView(GameType game, bool isCrashGame)
        {
            return isCrashGame ? "_CrashGameRoundResult" : views[game];
        }
    }
}
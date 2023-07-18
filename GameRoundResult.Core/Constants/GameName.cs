using System;
using System.Collections.Generic;

namespace GameRoundResult.Core.Constants
{
    public static class GameName
    {
        public static Dictionary<string, string> GameNameMap = new Dictionary<string, string>
        {
            { Convert.ToInt32(GameType.BigSmall).ToString(), "Big Small" },
            { Convert.ToInt32(GameType.SeDie).ToString(), "Se Die" },
            { Convert.ToInt32(GameType.FishPrawnCrab).ToString(), "Fish Prawn Crab" },
            { Convert.ToInt32(GameType.BigSmallTurbo).ToString(), "Turbo Big Small" },
            { Convert.ToInt32(GameType.OddEven).ToString(), "Odd Even" },
            { Convert.ToInt32(GameType.OddEvenTurbo).ToString(), "Turbo Odd Even" },
            { Convert.ToInt32(GameType.DragonTiger).ToString(), "Dragon Tiger" },
            { Convert.ToInt32(GameType.KenoProMax).ToString(), "Keno Pro Max" },
            { Convert.ToInt32(GameType.MiniSeDie).ToString(), "Mini SeDie" },
            { Convert.ToInt32(GameType.Baccarat).ToString(), "Baccarat" },
            { Convert.ToInt32(GameType.KenoProViet).ToString(), "Keno Pro Viet" },
            { Convert.ToInt32(GameType.KenoMax).ToString(), "Keno Max" },
            { Convert.ToInt32(GameType.KenoMax2).ToString(), "Keno Max 2" },
            { Convert.ToInt32(GameType.KenoMini).ToString(), "Keno Mini" },
            { Convert.ToInt32(GameType.KenoMini2).ToString(), "Keno Mini 2" },
            { Convert.ToInt32(GameType.KenoEast).ToString(), "Keno East" },
            { Convert.ToInt32(GameType.KenoWest).ToString(), "Keno West" },
            { Convert.ToInt32(GameType.KenoSouth).ToString(), "Keno South" },
            { Convert.ToInt32(GameType.KenoNorth).ToString(), "Keno North" },
            { Convert.ToInt32(GameType.Roulette).ToString(), "Roulette" },
            { Convert.ToInt32(GameType.VipSeDie).ToString(), "Vip Se Die" },
            { Convert.ToInt32(GameType.Blackjack).ToString(), "Blackjack" },
            { Convert.ToInt32(GameType.SpecialSeDie).ToString(), "Special Se Die" },
            { Convert.ToInt32(GameType.SicBo).ToString(), "Sic Bo" },
            { Convert.ToInt32(GameType.VipFishPrawnCrab).ToString(), "Vip Fish Prawn Crab" },
            { Convert.ToInt32(GameType.VipBaccarat).ToString(), "Vip Baccarat" },
            { Convert.ToInt32(GameType.SeDieWar).ToString(), "Se Die War" },
            { Convert.ToInt32(GameType.Lottery).ToString(), "Lottery" },
            { Convert.ToInt32(GameType.ThreeCards).ToString(), "Three Cards" },
            { Convert.ToInt32(GameType.KenoMatch1).ToString(), "Keno Match 1" },
            { Convert.ToInt32(GameType.KenoMatch2).ToString(), "Keno Match 2" },
            { Convert.ToInt32(GameType.CasinoHoldemPoker).ToString(), "Casino Holdem Poker" },
            { Convert.ToInt32(GameType.KenoPower1).ToString(), "Keno Power 1" },
            { Convert.ToInt32(GameType.KenoPower2).ToString(), "Keno Power 2" },
            { Convert.ToInt32(GameType.TexasHoldemPoker).ToString(), "Texas Holdem Poker" },
            { Convert.ToInt32(GameType.BitcoinMaster).ToString(), "Bitcoin Master" },
            { Convert.ToInt32(GameType.HiLo).ToString(), "HiLo" },
            { Convert.ToInt32(GameType.TreasureIsland).ToString(), "Treasure Island" },
            { Convert.ToInt32(GameType.BlockchainBaccarat).ToString(), "Blockchain Baccarat" },
            { Convert.ToInt32(GameType.UnbalancedBigSmall1).ToString(), "Unbalanced Big Small 1" },
            { Convert.ToInt32(GameType.UnbalancedBigSmall2).ToString(), "Unbalanced Big Small 2" },
            { Convert.ToInt32(GameType.MegaKeno).ToString(), "Mega Keno" },
            { Convert.ToInt32(GameType.MegaKeno2).ToString(), "Mega Keno 2" },
            { Convert.ToInt32(GameType.UnbalancedBigSmall3).ToString(), "Unbalanced Big Small 3" },
            { Convert.ToInt32(GameType.UnbalancedBigSmall4).ToString(), "Unbalanced Big Small 4" },
            { Convert.ToInt32(GameType.MiniSeDie2).ToString(), "Mini SeDie 2" },
            { Convert.ToInt32(GameType.MiniSeDie3).ToString(), "Mini SeDie 3" },
            { Convert.ToInt32(GameType.MiniSeDie4).ToString(), "Mini SeDie 4" },
            { Convert.ToInt32(GameType.FruitSlot).ToString(), "Fruit Slot" },
            { Convert.ToInt32(GameType.FanTan).ToString(), "Fan Tan" },
            { Convert.ToInt32(GameType.WinThreeCards).ToString(), "Win Three Cards" },
            { Convert.ToInt32(GameType.DragonTigerFight).ToString(), "Dragon Tiger Fight" },
        };
    }
}

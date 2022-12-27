using System;
using System.Text.RegularExpressions;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketResultViewModel
    {
        private const string PartialPostfix = "Ticket";
        public GameType GameType { get; set; }

        public GameTicketViewModel GameTicketResult { get; set; }

        public string GetPartialViewName()
        {
            if (IsMiniKeno) return $"_RNGKeno{PartialPostfix}";

            if (IsCascadingSlot) return $"_CascadingSlot{PartialPostfix}";

            if (IsBaccarat) return $"_Baccarat{PartialPostfix}";

            return Enum.IsDefined(typeof(GameType), GameType)
                ? $"_{TransformToViewName(Enum.GetName(typeof(GameType), GameType))}{PartialPostfix}"
                : $"_SlotGame{PartialPostfix}";
        }

        private bool IsMiniKeno
            => GameType switch
            {
                GameType.KenoProViet
                or GameType.KenoMax
                or GameType.KenoMax2
                or GameType.KenoMini
                or GameType.KenoMini2
                or GameType.KenoEast
                or GameType.KenoWest
                or GameType.KenoSouth
                or GameType.KenoNorth
                or GameType.MegaKeno
                or GameType.MegaKeno2 => true,
                _ => false
            };

        private bool IsCascadingSlot
            => GameType switch
            {
                GameType.TreasureIsland => true,
                _ => false
            };

        private bool IsBaccarat
             => GameType switch
             {
                 GameType.Baccarat or GameType.VipBaccarat or GameType.BlockchainBaccarat => true,
                 _ => false
             };

        private static string TransformToViewName(string name)
        => Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);
    }
}
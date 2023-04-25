using System;
using System.Text.RegularExpressions;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketResultViewModel
    {
        private const string PartialPostfix = "Ticket";
        public GameType GameId { get; set; }

        public GameTicketViewModel GameTicketResult { get; set; }

        public string GetPartialViewName()
        {
            if (IsMiniKeno)
            {
                return $"_RNGKeno{PartialPostfix}";
            }

            if (IsCascadingSlot)
            {
                return $"_CascadingSlot{PartialPostfix}";
            }

            if (IsBaccarat)
            {
                return $"_Baccarat{PartialPostfix}";
            }

            return Enum.IsDefined(typeof(GameType), GameId)
                ? $"_{TransformToViewName(Enum.GetName(typeof(GameType), GameId))}{PartialPostfix}"
                : $"_SlotGame{PartialPostfix}";
        }

        private bool IsMiniKeno
            => GameId switch
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
            => GameTicketResult.GameType == Core.Constants.GameConfigsType.CascadingSlot;

        private bool IsBaccarat
             => GameId switch
             {
                 GameType.Baccarat or GameType.VipBaccarat or GameType.BlockchainBaccarat => true,
                 _ => false
             };

        private static string TransformToViewName(string name)
        => Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);
    }
}
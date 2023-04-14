using System;
using System.Text.RegularExpressions;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketResultViewModel
    {
        private const string PartialPostfix = "Ticket";
        public GameId GameId { get; set; }

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

            return Enum.IsDefined(typeof(GameId), GameId)
                ? $"_{TransformToViewName(Enum.GetName(typeof(GameId), GameId))}{PartialPostfix}"
                : $"_SlotGame{PartialPostfix}";
        }

        private bool IsMiniKeno
            => GameId switch
            {
                GameId.KenoProViet 
                or GameId.KenoMax
                or GameId.KenoMax2
                or GameId.KenoMini
                or GameId.KenoMini2
                or GameId.KenoEast
                or GameId.KenoWest
                or GameId.KenoSouth
                or GameId.KenoNorth
                or GameId.MegaKeno
                or GameId.MegaKeno2 => true,
                _ => false
            };

        private bool IsCascadingSlot
            => GameTicketResult.GameType == Core.Constants.GameType.CascadingSlot;

        private bool IsBaccarat
             => GameId switch
             {
                 GameId.Baccarat or GameId.VipBaccarat or GameId.BlockchainBaccarat => true,
                 _ => false
             };

        private static string TransformToViewName(string name)
        => Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);
    }
}
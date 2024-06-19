using System;
using System.Text.RegularExpressions;
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web.Models
{
    public class GameTicketResultViewModel
    {
        private const string PartialPostfix = "Ticket";
        private const string PartialSuffix = "~/Views/BetHistory/";
        public GameType GameType { get; set; }

        public GameTicketViewModel GameTicketResult { get; set; }

        public string Language { get; set; }

        public bool EnableTolgee { get; set; }

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

            if (IsClassicSlot)
            {
                return $"_SlotGame{PartialPostfix}";
            }

            if (IsCrashGame)
            {
                return $"_CrashGame{PartialPostfix}";
            }

            if (IsBaccarat)
            {
                return $"_Baccarat{PartialPostfix}";
            }

            if (IsBaccaratX)
            {
                return $"{PartialSuffix}_BaccaratX{PartialPostfix}.cshtml";
            }

            return Enum.IsDefined(typeof(GameType), GameType)
                ? $"{PartialSuffix}_{TransformToViewName(Enum.GetName(typeof(GameType), GameType))}{PartialPostfix}.cshtml"
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
            => GameTicketResult.GameType == GameConfigsType.CascadingSlot;

        private bool IsClassicSlot
            => GameTicketResult.GameType == GameConfigsType.Slot;

        private bool IsBaccarat
             => GameType switch
             {
                 GameType.Baccarat or GameType.VipBaccarat or GameType.BlockchainBaccarat => true,
                 _ => false
             };

        private bool IsCrashGame
            => GameTicketResult.GameType == GameConfigsType.Crash;

        private static string TransformToViewName(string name)
        => Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);

        private bool IsBaccaratX
              => GameType switch
              {
                  GameType.Bac81 => true,
                  _ => false
              };
    }
}
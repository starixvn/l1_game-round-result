using System;
using System.Text.RegularExpressions;
using GameRoundResult.Core.Constants;
using GameRoundResult.Web.Configuration;

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
                if (GameType == GameType.TapFortune)
                {
                    return $"{PartialSuffix}_TapFortune{PartialPostfix}.cshtml";
                }

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

            if (IsDrawGame)
            {
                return $"_{Enum.GetName(typeof(GameType), GameType)}{PartialPostfix}";
            }

            if (IsKenoPower)
            {
                return $"_KenoPower{PartialPostfix}";

            }

            if (IsKenoSoccer)
            {
                return $"_KenoMatch{PartialPostfix}";
            }

            var viewName = GetViewNameAttribute();

            if (!string.IsNullOrWhiteSpace(viewName))
            {
                return $"{PartialSuffix}_{viewName}.cshtml";
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
                or GameType.MegaKeno2
                or GameType.SKKenoMini
                or GameType.SKKenoMini2
                or GameType.SKKenoEast
                or GameType.SKKenoWest
                or GameType.SKKenoSouth
                or GameType.SKKenoNorth
                or GameType.SKMegaKeno
                or GameType.SKMegaKeno2 => true,
                _ => false
            };

        private bool IsDrawGame
            => GameType switch
            {
                GameType.BacBall1
                or GameType.BacBall2
                or GameType.LuckyNext1
                or GameType.LuckyNext2
                => true,
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
        {
            if (name == "SeDie3")
            {
                return name;
            }

            return Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);
        }

        private bool IsKenoSoccer
            => GameType switch
            {
                GameType.KenoMatch1
                or GameType.KenoMatch2
                or GameType.SKKenoSoccer
                or GameType.SKKenoSoccer2 => true,
                _ => false
            };

        private bool IsKenoPower
            => GameType switch
            {
                GameType.KenoPower1
                or GameType.KenoPower2
                or GameType.SKKenoPower
                or GameType.SKKenoPower2 => true,
                _ => false
            };

        private string GetViewNameAttribute()
        {
            return ((ViewNameAttribute)Attribute.GetCustomAttribute(GameTicketResult.GetType(), typeof(ViewNameAttribute)))?.Name;
        }
    }
}
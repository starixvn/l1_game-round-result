using GameRoundResult.Core.Constants;
using GameRoundResult.Web._Shared;
using GameRoundResult.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            return GetViewNameByGameType() ?? GetDefaultViewName();
        }

        private string GetViewNameByGameType()
        {
            var viewNameStrategies = new Dictionary<Func<bool>, Func<string>>
            {
                { () => IsMiniKeno, () => $"_RNGKeno{PartialPostfix}" },
                { () => IsCascadingSlot, () => $"_CascadingSlot{PartialPostfix}" },
                { () => IsClassicSlot, () => GetClassicSlotViewName() },
                { () => IsCrashGame, () => $"_CrashGame{PartialPostfix}" },
                { () => GameConfigsTypeHelper.IsCrashTurn(GameTicketResult.GameType), () => $"_CrashTurnGame{PartialPostfix}" },
                { () => IsBaccarat, () => $"_Baccarat{PartialPostfix}" },
                { () => IsDrawGame, () => $"_{Enum.GetName(typeof(GameType), GameType)}{PartialPostfix}" },
                { () => IsPlinkoGame, () => $"_PlinkoGame{PartialPostfix}" }
            };

            return viewNameStrategies
                .FirstOrDefault(strategy => strategy.Key())
                .Value?.Invoke();
        }

        private string GetClassicSlotViewName()
        {
            return GameType == GameType.TapFortune
                ? $"{PartialSuffix}_TapFortune{PartialPostfix}.cshtml"
                : $"_SlotGame{PartialPostfix}";
        }

        private string GetDefaultViewName()
        {
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
                or GameType.MegaKeno2 => true,
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
        public bool IsCascadingCluster
            => GameTicketResult.GameType == GameConfigsType.CascadingCluster;

        private bool IsBaccarat
             => GameType switch
             {
                 GameType.Baccarat or GameType.VipBaccarat or GameType.BlockchainBaccarat => true,
                 _ => false
             };

        private bool IsCrashGame
            => GameTicketResult.GameType == GameConfigsType.Crash;

        private bool IsPlinkoGame
            => GameTicketResult.GameType == GameConfigsType.Plinko;

        private static string TransformToViewName(string name)
        {
            if (name == "SeDie3")
            {
                return name;
            }

            if (name == "MarbleFootball2")
            {
                return name;
            }

            return Regex.Replace(name, @"[\d-]", string.Empty).Replace("Turbo", string.Empty);
        }

        private string GetViewNameAttribute()
        {
            return ((ViewNameAttribute)Attribute.GetCustomAttribute(GameTicketResult.GetType(), typeof(ViewNameAttribute)))?.Name;
        }
    }
}
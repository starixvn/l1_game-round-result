using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameRoundResult.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class GameRoundResultViewModel
    {
        public GameType GameType { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public long? RoundId { get; set; }

        public string UserTimeZone { get; set; }

        public IEnumerable<SelectListItem> GameTypes { get; set; }

        public bool EnableTolgee { get; set; }

        public string Language { get; set; }

        public string GetTolgeeNamespaces()
        {
            var baseNs = "GameRoundResultViewModel,RoundResultViewModel,GameType,";
            var types = Assembly.GetAssembly(typeof(TolgeeNamespace)).GetTypes().Where(type => type.IsSubclassOf(typeof(TolgeeNamespace)));
            var ns = string.Join(',', types.Select(type => type.Name));
            return baseNs + ns;
        }
    }
}
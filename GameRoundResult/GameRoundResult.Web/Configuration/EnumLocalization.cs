using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace GameRoundResult.Web.Configuration
{
    public class EnumLocalization<T> where T : Enum
    {
        private readonly IStringLocalizer<T> localizer;

        public EnumLocalization(IStringLocalizer<T> localizer)
        {
            this.localizer = localizer;
        }

        protected virtual IEnumerable<SelectListItem> GetSelectListItems()
        {
            var enums = Enum.GetValues(typeof(T)).Cast<T>();
            return enums.Select(x => new SelectListItem
            {
                Value = Convert.ToInt32(x).ToString(),
                Text = localizer[x.ToString()]
            });
        }
    }

    public class GameTypeLocalization : EnumLocalization<GameType>
    {
        private readonly IEnumerable<GameType> excludeGames = new List<GameType>
        {
            GameType.Blackjack,
            GameType.FourGuardians,
            GameType.OddEven,
            GameType.KenoProViet,
            GameType.HeroesSlot
        };

        private readonly IGlobalConfigService globalConfigService;

        public GameTypeLocalization(IStringLocalizer<GameType> localizer, IGlobalConfigService globalConfigService) : base(localizer)
        {
            this.globalConfigService = globalConfigService;
        }

        public async Task<IEnumerable<SelectListItem>> GetGameListAsync(string siteName)
        {
            var configs = (await globalConfigService.GetAsync()).Configs;
            return GetSelectListItems()
                .Where(x => !excludeGames.Any(e => e == (GameType)Enum.Parse(typeof(GameType), x.Value)) &&
                !configs[x.Value].Any(excludedSite => excludedSite.Equals(siteName, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
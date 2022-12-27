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

    //TODO add config to exclude slot games
    public class GameTypeLocalization : EnumLocalization<GameType>
    {
        private readonly IEnumerable<GameType> excludeGames = new List<GameType>
        {
            GameType.Blackjack,
            GameType.OddEven,
            GameType.KenoProViet,
            GameType.CasinoHoldemPoker,
            GameType.TexasHoldemPoker,
            GameType.HiLo,
            GameType.TreasureIsland,
        };

        private readonly IPartnerConfigService partnerConfigService;

        public GameTypeLocalization(IStringLocalizer<GameType> localizer, IPartnerConfigService PartnerConfigService) : base(localizer)
        {
            this.partnerConfigService = PartnerConfigService;
        }

        public async Task<IEnumerable<SelectListItem>> GetGameListAsync(string siteName, string partnerId)
        {
            var configs = (await partnerConfigService.GetAsync(partnerId))?.Value;

            if (configs != null)
            {
                return GetSelectListItems()
                    .Where(x => !excludeGames.Any(e => e == (GameType)Enum.Parse(typeof(GameType), x.Value)) &&
                    (!configs.ContainsKey(x.Value) ||
                    !configs[x.Value].Any(excludedSite => string.Equals(excludedSite, siteName, StringComparison.InvariantCultureIgnoreCase))));
            }

            return GetGameList();
        }

        public IEnumerable<SelectListItem> GetGameList()
        {
            return GetSelectListItems()
                .Where(x => !excludeGames.Any(e => e == (GameType)Enum.Parse(typeof(GameType), x.Value)));
        }
    }
}
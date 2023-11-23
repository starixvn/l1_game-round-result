using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Configuration
{
    public class EnumLocalization<T> where T : Enum
    {
        private readonly IJsonStringLocalizer<T> localizer;

        public EnumLocalization(IJsonStringLocalizer<T> localizer)
        {
            this.localizer = localizer;
        }

        protected virtual IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<GameConfigEntity> games)
        {
            return games.Select(x => new SelectListItem
            {
                Value = Convert.ToInt32(x.GameId).ToString(),
                Text = localizer[!string.IsNullOrEmpty(x.DisplayName) ? x.DisplayName : ((GameType)Enum.Parse(typeof(GameType), x.GameId.ToString())).ToString()]
            });      
        }
    }

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
            GameType.FourGuardians,
            GameType.Pontoon
        };

        private readonly IPartnerConfigService partnerConfigService;

        private readonly IGeneralGameSettingService generalGameSettingService;

        public GameTypeLocalization(IJsonStringLocalizer<GameType> localizer, IPartnerConfigService PartnerConfigService, IGeneralGameSettingService generalGameSettingService) : base(localizer)
        {
            this.partnerConfigService = PartnerConfigService;
            this.generalGameSettingService = generalGameSettingService;
        }

        public async Task<IEnumerable<SelectListItem>> GetGameListAsync(string siteName, string partnerId)
        {
            var configs = (await partnerConfigService.GetAsync(partnerId))?.Value;
           
            if (configs != null)
            {
                var selectGameList = await GetSelectList();
                return selectGameList
                    .Where(x => !excludeGames.Any(e => e == (GameType)Enum.Parse(typeof(GameType), x.Value)) &&
                    (!configs.ContainsKey(x.Value) ||
                    !configs[x.Value].Any(excludedSite => string.Equals(excludedSite, siteName, StringComparison.InvariantCultureIgnoreCase))));
            }

            return await GetGameList();
        }

        public async Task<IEnumerable<SelectListItem>> GetGameList()
        {
            var selectGameList = await GetSelectList();
            return selectGameList
                .Where(x => !excludeGames.Any(e => e == (GameType)Enum.Parse(typeof(GameType), x.Value)));
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectList()
        {
            var games = await generalGameSettingService.GetSelectGamesAsync();
            return GetSelectListItems(games);       
        }
    }
}
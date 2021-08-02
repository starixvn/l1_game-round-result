using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
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

        public virtual IEnumerable<SelectListItem> GetSelectListItems()
        {
            var enums = Enum.GetValues(typeof(T)).Cast<T>();
            return enums.Select(x => new SelectListItem
            {
                Value = x.ToString(),
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

        public GameTypeLocalization(IStringLocalizer<GameType> localizer) : base(localizer)
        {
        }

        public override IEnumerable<SelectListItem> GetSelectListItems()
        {
            return base.GetSelectListItems().Where(x => !excludeGames.Any(e => e.ToString() == x.Value));
        }
    }
}
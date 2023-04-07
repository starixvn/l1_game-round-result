using System;
using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Constants;
using GameRoundResult.Core.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
    public class DemoViewModel
    {
        public IEnumerable<Partner> Operators { get; set; } = new List<Partner>();

        public IEnumerable<SelectListItem> OperatorItem => Operators.Select(o => new SelectListItem(o.PartnerId, o.PartnerId));

        public IEnumerable<SelectListItem> LanguageItem => new List<SelectListItem> {
                    new SelectListItem
                    {
                        Text = "English",
                        Value = "en-US"
                    },
                    new SelectListItem
                    {
                        Text = "Vietnamese",
                        Value = "vi-VN"
                    },
                    new SelectListItem
                    {
                        Text = "Indonesia",
                        Value = "id-ID"
                    },
                    new SelectListItem
                    {
                        Text = "Thailand",
                        Value = "th-TH"
                    },
                    new SelectListItem
                    {
                        Text = "Chinese Simplified",
                        Value = "zh-CN"
                    },
                    new SelectListItem
                    {
                        Text = "Chinese Traditional",
                        Value = "zh-TW"
                    }
                };

        public IEnumerable<SelectListItem> GameTypeItem => Enum.GetNames(typeof(GameId)).Select(game => new SelectListItem(game, ((byte)(GameId)Enum.Parse(typeof(GameId), game)).ToString()));

        public int GameRoundId { get; set; }

        public int PlayerId { get; set; }

        public string Language { get; set; }

        public byte GameTypeId { get; set; }

        public string OperatorId { get; set; }

        public string OperatorSecret { get; set; }

        public string SiteId { get; set; } = "4100300";

        public bool FreeBet { get; set; }
    }
}
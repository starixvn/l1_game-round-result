using System.Collections.Generic;
using System.Linq;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRoundResult.Web.Models
{
	public class MarbleFootballRoundResultViewModel : RoundResultViewModel
	{
		private const string tolgeeNameSpace = "MarbleFootball";
		public MarbleFootballResultEntity Result { get; set; }

		public MarbleFootballSettlementResultEntity SettlementResult { get; set; }

		public MarbleFootballMatchEntity Match { get; set; }

		public override IEnumerable<string> ToDataTableArray(
			IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
		)
		{
			var result = new List<string>(base.ToDataTableArray(stringLocalizer))
			{
				$"{GetFormattedResult(stringLocalizer)}",
				$"{GetWinningTextResult(stringLocalizer)}",
			};

			return result;
		}

		public string GetFormattedResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
		{
			return GetResult(stringLocalizer);
		}

		public override string GetResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
		{
			var resultBuilder = new TagBuilder("span");
			var dividerBuilder = new TagBuilder("span");

			resultBuilder.AddCssClass($"marble-football-result-container");
			dividerBuilder.AddCssClass("marble-football-divider");

			var homeContent = GetHomeResult(stringLocalizer);
			var awayContent = GetAwayResult(stringLocalizer);

			dividerBuilder.InnerHtml.Append("|");

			resultBuilder.InnerHtml.AppendHtml(homeContent);
			resultBuilder.InnerHtml.AppendHtml(dividerBuilder.GetHtmlString());
			resultBuilder.InnerHtml.AppendHtml(awayContent);

			return resultBuilder.GetHtmlString();
		}

		public string GetHomeResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
		{
			var fulltime = Result.FirstHalf + Result.SecondHalf;
			var homeScore = fulltime.Count(score => score == 'H');

			var homeName = "team_" + Match.Home;

			var homeImg = new TagBuilder("img");
			homeImg.AddCssClass($"img");
			homeImg.Attributes.Add(
				"src",
				$"/scss/images/marble-football/{Match?.Home ?? "home"}.png"
			);
			homeImg.Attributes.Add("width", "50px");
			homeImg.Attributes.Add("height", "50px");

			var nameBuilder = new TagBuilder("span");
			nameBuilder.InnerHtml.AppendHtml(GetGameText(stringLocalizer, homeName));
			var scoreBuilder = new TagBuilder("span");
			scoreBuilder.InnerHtml.AppendHtml(homeScore.ToString());
			var homeBuilder = new TagBuilder("span");

			homeBuilder.AddCssClass("marble-football-result marble-football-home");

			if (SettlementResult.Home)
			{
				homeBuilder.AddCssClass("bet-win-text");
			}

			homeBuilder.InnerHtml.AppendHtml(nameBuilder.GetHtmlString());
			homeBuilder.InnerHtml.AppendHtml(homeImg.GetHtmlString());
			homeBuilder.InnerHtml.AppendHtml(scoreBuilder.GetHtmlString());


			return homeBuilder.GetHtmlString();
		}

		public string GetAwayResult(IJsonStringLocalizer<RoundResultViewModel> stringLocalizer)
		{
			var fulltime = Result.FirstHalf + Result.SecondHalf;
			var awayScore = fulltime.Count(score => score == 'A');

			var awayName = "team_" + Match.Away;
			var awayImg = new TagBuilder("img");
			awayImg.AddCssClass($"img");
			awayImg.Attributes.Add(
				"src",
				$"/scss/images/marble-football/{Match?.Away ?? "away"}.png"
			);
			awayImg.Attributes.Add("width", "50px");
			awayImg.Attributes.Add("height", "50px");

			var nameBuilder = new TagBuilder("span");
			nameBuilder.InnerHtml.AppendHtml(GetGameText(stringLocalizer, awayName));
			var scoreBuilder = new TagBuilder("span");
			scoreBuilder.InnerHtml.AppendHtml(awayScore.ToString());
			var awayBuilder = new TagBuilder("span");

			awayBuilder.AddCssClass("marble-football-result marble-football-away");

			if (SettlementResult.Away)
			{
				awayBuilder.AddCssClass("bet-win-text");
			}

			awayBuilder.InnerHtml.AppendHtml(scoreBuilder.GetHtmlString());
			awayBuilder.InnerHtml.AppendHtml(awayImg.GetHtmlString());
			awayBuilder.InnerHtml.AppendHtml(nameBuilder.GetHtmlString());

			return awayBuilder.GetHtmlString();
		}

		public override string GetWinningTextResult(
			IJsonStringLocalizer<RoundResultViewModel> stringLocalizer
		)
		{
			var winningResults = new List<string>();

			if (SettlementResult.Home)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_home"));
			;

			if (SettlementResult.Away)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_away"));

			if (SettlementResult.Draw)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_draw"));

			if (SettlementResult.Over)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_over"));

			if (SettlementResult.Under)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_under"));

			if (SettlementResult.Odd)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_odd"));

			if (SettlementResult.Even)
				winningResults.Add(GetGameText(stringLocalizer, "glossary_even"));

			return string.Join(", ", winningResults);
		}

		public string GetGameText(
			IJsonStringLocalizer<RoundResultViewModel> stringLocalizer,
			string key
		)
		{
			return stringLocalizer.GetStringWithNamcespace(key, tolgeeNameSpace);
		}
	}
}

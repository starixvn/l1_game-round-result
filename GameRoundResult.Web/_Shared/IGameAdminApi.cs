using System.Threading.Tasks;
using GameRoundResult.Web.Models;
using Refit;

namespace GameRoundResult.Web._Shared
{
    public interface IGameAdminApi
    {
        [Get("/game_configs/{gameId}")]
        Task<GameConfigModel> GetGameConfigById(byte gameId);
    }
}
using System.Threading.Tasks;
using GameRoundResult.Web.Models;
using Refit;

namespace GameRoundResult.Web._Shared
{
    [Headers("Authorization: Bearer")]
    public interface IGameManagementApi
    {
        [Get("/game-configs/byid")]
        Task<GameConfigResponse> GetGameConfigById([Query] byte gameId);
    }

    public class GameConfigResponse
    {
        public GameConfigModel Data { get; set; }
    }
}
using System.Threading.Tasks;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Accessor
{
    public interface IGameTicketAccessor
    {
        Task<GameTicketViewModel> GetAsync(GetGameTicketRequest request, GameConfigModel gameConfigs);
    }
}
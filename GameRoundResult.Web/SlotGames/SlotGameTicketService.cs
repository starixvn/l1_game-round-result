using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;

namespace GameRoundResult.Web.SlotGames
{
    public interface ISlotGameTicketService
    {
        Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName);
    }

    public static class EndRoundValidator
    {
        public static EndRoundInfoResult ValidateRound(SlotGameRound round)
        {
            if (round == null)
            {
                return EndRoundInfoError.SB1001;
            }

            if (!round.Paid)
            {
                return EndRoundInfoError.SB1005;
            }

            return null;
        }
    }

    public class SlotGameTicketService : ISlotGameTicketService
    {
        private readonly ISlotGameBetRepository repository;

        public SlotGameTicketService(ISlotGameBetRepository repository)
        {
            this.repository = repository;
        }

        public Task<SlotGameRound> GetAsync(long roundId, int playerId, string operatorId, string gameName)
        => repository.GetAsync<SlotGameRound>(roundId, playerId, operatorId, gameName);
    }
}
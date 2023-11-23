using GameRoundResult.Core.Database.Entities;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Repository;
using System.Collections.Generic;
using GameRoundResult.Core.Constants;
using System.Linq;

namespace GameRoundResult.Core.Services
{
    public interface IGeneralGameSettingService
    {
        Task<IEnumerable<GameConfigEntity>> GetSelectGamesAsync();

        Task<bool> IsCrashGame(int gameId);
    }
    public class GeneralGameSettingService: IGeneralGameSettingService
    {
        private readonly IGeneralGameSettingRepository generalGameSettingRepository;

        public GeneralGameSettingService(IGeneralGameSettingRepository generalGameSettingRepository)
        {
            this.generalGameSettingRepository = generalGameSettingRepository;
        }

        public async Task<IEnumerable<GameConfigEntity>> GetSelectGamesAsync()
        {
            var gameEntities = await generalGameSettingRepository.GetAll();
            var filteredGames = gameEntities
                .Where(x => x.Type != (byte)GameConfigsType.Slot &&
                 x.Type != (byte)GameConfigsType.CascadingSlot &&
                 x.GameId > 0);

            return filteredGames;
        }
        
        public async Task<bool> IsCrashGame(int gameId)
        {
            var gameEntities = await generalGameSettingRepository.GetAll();
            var gameInfo = gameEntities.FirstOrDefault(x => x.GameId == gameId);

            return gameInfo?.Type == (byte)GameConfigsType.Crash;
        }
    }
}

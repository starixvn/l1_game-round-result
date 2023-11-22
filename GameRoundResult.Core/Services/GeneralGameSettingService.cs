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
        Task<IEnumerable<GameConfigEntity>> GetAsync();

        Task<bool> IsCrashGame(int gameId);
    }
    public class GeneralGameSettingService: IGeneralGameSettingService
    {
        private readonly IGeneralGameSettingRepository generalGameSettingRepository;

        public GeneralGameSettingService(IGeneralGameSettingRepository generalGameSettingRepository)
        {
            this.generalGameSettingRepository = generalGameSettingRepository;
        }

        public async Task<IEnumerable<GameConfigEntity>> GetAsync()
         => await generalGameSettingRepository.GetAll();

        public async Task<bool> IsCrashGame(int gameId)
        {
            var gameEntities = await generalGameSettingRepository.GetAll();
            var gameInfo = gameEntities.FirstOrDefault(x => x.GameId == gameId);

            return gameInfo?.Type == (byte)GameConfigsType.Crash;
        }
    }
}

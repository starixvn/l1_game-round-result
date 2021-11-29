using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IGlobalConfigService
    {
        Task<GlobalConfig> GetAsync();
    }

    public class GlobalConfigService : IGlobalConfigService
    {
        private readonly IGlobalConfigRepository repository;

        public GlobalConfigService(IGlobalConfigRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GlobalConfig> GetAsync()
        {
            return await repository.GetAsync();
        }
    }
}
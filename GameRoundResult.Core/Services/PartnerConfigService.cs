using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IPartnerConfigService
    {
        Task<PartnerConfig> GetAsync(string partnerId);
    }

    public class PartnerConfigService : IPartnerConfigService
    {
        private readonly IPartnerConfigRepository repository;

        public PartnerConfigService(IPartnerConfigRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PartnerConfig> GetAsync(string partnerId)
        {
            return await repository.GetAsync(partnerId);
        }
    }
}
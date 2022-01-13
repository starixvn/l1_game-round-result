using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IPartnerService
    {
        Task<Partner> Get(string partnerId, string partnerSecret);
    }

    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository PartnerRepository;

        public PartnerService(IPartnerRepository PartnerRepository)
        {
            this.PartnerRepository = PartnerRepository;
        }

        public Task<Partner> Get(string partnerId, string partnerSecret)
        => PartnerRepository.Get(partnerId, partnerSecret);
    }
}
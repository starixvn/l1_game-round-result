using System.Collections.Generic;
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface IPartnerService
    {
        Task<Partner> Get(string partnerId, string partnerSecret);

        Task<Partner> GetById(string partnerId);

        Task<IEnumerable<Partner>> GetAll();
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

        public Task<Partner> GetById(string operatorId)
        => PartnerRepository.GetById(operatorId);

        public Task<IEnumerable<Partner>> GetAll()
        => PartnerRepository.GetAll();
    }
}
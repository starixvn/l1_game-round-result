using System.Threading.Tasks;
using GameRoundResult.Core._Share;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ICurrencyGroupService
    {
        Task<bool?> GetFractionalOddsFormat(string currencyname, string operatorId);
    }

    public class CurrencyGroupService : ICurrencyGroupService
    {
        private readonly ICacheManager cache;
        private readonly ICurrencyRepository currencyRepository;
        private readonly ICurrencyGroupRepository currencyGroupRepository;

        public CurrencyGroupService(ICurrencyRepository currencyRepository, ICurrencyGroupRepository currencyGroupRepository, ICacheManager cache)
        {
            this.currencyGroupRepository = currencyGroupRepository;
            this.currencyRepository = currencyRepository;
            this.cache = cache;
        }

        public async Task<bool?> GetFractionalOddsFormat(string currencyname, string operatorId)
        {
            var oldFractionalOddsFormat = cache.GetCache<bool?>($"{operatorId}-{currencyname}");
            if (oldFractionalOddsFormat != default)
            {
                return oldFractionalOddsFormat;
            }
            var currency = await currencyRepository.Get(currencyname, operatorId);
            var currencyGroup = await currencyGroupRepository.GetById(currency.GroupId);
            cache.SetCache($"{operatorId}-{currencyname}", currencyGroup.FractionalOddsFormat);
            return currencyGroup.FractionalOddsFormat;
        }
    }
}
using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Repository;

namespace GameRoundResult.Core.Services
{
    public interface ILogService
    {
        Task LogTicketDetailRequestAsync(RequestLog log);
    }

    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public Task LogTicketDetailRequestAsync(RequestLog log)
        => logRepository.WriteTicketDetailRequestAsync(log);
    }
}
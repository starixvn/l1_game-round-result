using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ILogRepository
    {
        Task WriteTicketDetailRequestAsync(RequestLog log);
    }

    public class LogRepository : ILogRepository
    {
        private const string TicketDetailLogCollectionName = "ticket_detail_requests";
        private readonly IMongoCollection<RequestLog> ticketDetailLogCollection;

        public LogRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("log");
            ticketDetailLogCollection = database.GetCollection<RequestLog>(TicketDetailLogCollectionName);
        }

        public Task WriteTicketDetailRequestAsync(RequestLog log)
        => ticketDetailLogCollection.InsertOneAsync(log);
    }
}
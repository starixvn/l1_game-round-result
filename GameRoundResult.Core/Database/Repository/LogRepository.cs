using System.Threading.Tasks;
using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.Player;
using MongoDB.Driver;

namespace GameRoundResult.Core.Database.Repository
{
    public interface ILogRepository
    {
        Task WriteTicketDetailRequestAsync(RequestLog log);

        Task WriteRetrieveEndRoundAsync(SBLog log);
    }

    public class LogRepository : ILogRepository
    {
        private const string TicketDetailLogCollectionName = "ticket_detail_requests";
        private const string RetrieveEndRoundCollectionName = "retrieve_requests";

        private readonly IMongoCollection<RequestLog> ticketDetailLogCollection;
        private readonly IMongoCollection<SBLog> retrieveCollection;

        public LogRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("log");
            ticketDetailLogCollection = database.GetCollection<RequestLog>(TicketDetailLogCollectionName);
            retrieveCollection = database.GetCollection<SBLog>(RetrieveEndRoundCollectionName);
        }

        public Task WriteTicketDetailRequestAsync(RequestLog log)
            => ticketDetailLogCollection.InsertOneAsync(log);

        public Task WriteRetrieveEndRoundAsync(SBLog log)
           => retrieveCollection.InsertOneAsync(log);
    }
}
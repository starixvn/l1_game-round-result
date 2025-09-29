using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashGames;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.PlinkoGames
{
    public static class PlinkoGameServiceRegistration
    {
        public static void AddPlinkoGames(this IServiceCollection services)
        {
            services.AddScoped<IPlinkoGameTicketService, PlinkoGameTicketService>();
            services.AddScoped<IPlinkoGameBetRepository, PlinkoGameBetRepository>();
            services.AddScoped<PlinkoGameHandler>();
            services.AddScoped<PlinkoGameEndRoundInfoService>();
            services.AddScoped<PlinkoGameRoundHistoryHandler>();
        }
    }
}
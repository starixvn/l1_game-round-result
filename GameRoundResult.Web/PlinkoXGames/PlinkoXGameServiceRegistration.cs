using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashGames;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.PlinkoXGames
{
    public static class PlinkoXGameServiceRegistration
    {
        public static void AddPlinkoXGames(this IServiceCollection services)
        {
            services.AddScoped<IPlinkoXGameTicketService, PlinkoXGameTicketService>();
            services.AddScoped<IPlinkoXGameBetRepository, PlinkoXGameBetRepository>();
            services.AddScoped<PlinkoXGameHandler>();
            services.AddScoped<PlinkoXGameEndRoundInfoService>();
            services.AddScoped<PlinkoXGameRoundHistoryHandler>();
        }
    }
}

using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashGames;
using GameRoundResult.Web.PlinkoGames;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.PlinkoXGames
{
    public static class PlinkoXGameServiceRegistration
    {
        public static void AddPlinkoXGames(this IServiceCollection services)
        {
            // Override Plinko registrations with PlinkoX implementations since they share the same business logic
            services.AddScoped<IPlinkoGameTicketService, PlinkoXGameTicketService>();
            services.AddScoped<IPlinkoGameBetRepository, PlinkoXGameBetRepository>();
            services.AddScoped<IPlinkoXGameTicketService, PlinkoXGameTicketService>();
            services.AddScoped<IPlinkoXGameBetRepository, PlinkoXGameBetRepository>();
        }
    }
}

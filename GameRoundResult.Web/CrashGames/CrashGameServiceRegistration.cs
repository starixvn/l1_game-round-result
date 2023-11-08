using GameRoundResult.Core.Database.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.CrashGames
{
    public static class CrashGameServiceRegistration
    {
        public static void AddCrashGames(this IServiceCollection services)
        {
            services.AddScoped<ICrashGameTicketService, CrashGameTicketService>();
            services.AddScoped<ICrashGameBetRepository, CrashGameBetRepository>();
        }
    }
}
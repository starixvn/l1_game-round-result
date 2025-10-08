using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashTurnGames.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.CrashTurnGames
{
    public static class CrashTurnGameServiceRegistration
    {
        public static void AddCrashTurnGames(this IServiceCollection services)
        {
            services.AddScoped<ICrashTurnGameTicketService, CrashTurnGameTicketService>();
            services.AddScoped<ICrashTurnGameBetRepository, CrashTurnGameBetRepository>();
            services.AddScoped<CrashTurnGameEndRoundInfoService>();
            services.AddScoped<CrashTurnGameHandler>();

        }
    }
}
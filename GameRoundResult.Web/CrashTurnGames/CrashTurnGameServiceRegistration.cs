using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashGames.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.CrashGames
{
    public static class CrashTurnGameServiceRegistration
    {
        public static void AddCrashTurnGames(this IServiceCollection services)
        {
            services.AddScoped<ICrashTurnGameBetRepository, CrashTurnGameBetRepository>();
            services.AddScoped<CrashTurnGameEndRoundInfoService>();

        }
    }
}
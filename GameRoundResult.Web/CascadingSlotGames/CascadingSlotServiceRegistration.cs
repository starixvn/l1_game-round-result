using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.CrashGames;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.CascadingSlotGames
{
    public static class CascadingSlotServiceRegistration
    {
        public static void AddCascadingSlotGames(this IServiceCollection services)
        {
            services.AddScoped<ICascadingSlotTicketService, CascadingSlotTicketService>();
            services.AddScoped<ICascadingSlotBetRepository, CascadingSlotBetRepository>();
            services.AddScoped<CascadingSlotGameEndRoundInfoService>();
            services.AddScoped<CascadingSlotTicketHandler>();
        }
    }
}
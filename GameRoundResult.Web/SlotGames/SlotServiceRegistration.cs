using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Web.SlotGames.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.SlotGames
{
    public static class SlotServiceRegistration
    {
        public static void AddSlotGames(this IServiceCollection services)
        {
            services.AddScoped<ISlotGameTicketService, SlotGameTicketService>();
            services.AddScoped<ISlotGameBetRepository, SlotGameBetRepository>();
            services.AddScoped<BaseEndRoundService>();
            services.AddScoped<SlotGameHandler>();
        }
    }
}
using GameRoundResult.Core.Database.Repository;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.SlotGames.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GameRoundResult.Web.SlotGames
{
    public static class SlotServiceRegistration
    {
        public static void AddSlotGames(this IServiceCollection services)
        {
            services.AddScoped<SlotGameEndGameInfoService>();
            services.AddScoped<ISlotGameTicketService, SlotGameTicketService>();
            services.AddScoped<ISlotGameBetRepository, SlotGameBetRepository>();
            services.AddScoped<SlotGameHandler>();
        }
    }
}
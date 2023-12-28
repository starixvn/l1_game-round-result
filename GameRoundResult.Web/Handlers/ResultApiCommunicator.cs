using System.Net.Http;
using System.Net;
using System;
using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using GameRoundResult.Web.Models.GameRoundResult;
using GameRoundResult.Web.Requests;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace GameRoundResult.Web.Handlers
{
    public interface ICloudResultApi
    {
        [Headers("Content-Type: application/json")]
        [Post("/BetHistory/GetAccessUrl")]
        Task<GameTicketAccessUrlResultModel> GetAccessUrl([Body(BodySerializationMethod.Serialized)] BetHistoryAccessUrlRequestModel model, [Header("Access-Key")] string accessKey);

        [Headers("Content-Type: application/json")]
        [Post("/EndRoundInfo")]
        Task<EndRoundInfoResult> RetrieveEndGameInfo([Body(BodySerializationMethod.Serialized)] RetrieveEndRoundInfoRequest request, [Header("Access-Key")] string accessKey);

        [Get("/GameRoundResult/GetRemoteData")]
        Task<RoundResultPagingViewModel> GetRoundResultByGame(GetRoundResultByGameRequest request);
    }

    public static class ResultApiCommunicator
    {
        public static void InitApi(this IServiceCollection services, CloudServiceConfig cloudServiceConfig)
        {
            var client = InitHttpClient(cloudServiceConfig.CloudResultUrl, cloudServiceConfig.OnPremiseProxy);

            services.AddSingleton(RestService.For<ICloudResultApi>(client, new RefitSettings(new NewtonsoftJsonContentSerializer())));
        }

        private static HttpClient InitHttpClient(string url, string proxy)
        {
            HttpClientHandler handler = null;

            if (!string.IsNullOrEmpty(proxy))
            {
                handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(proxy),
                    UseProxy = true,
                };
            }

            var client = (handler == null) ? new HttpClient() : new HttpClient(handler);
            client.BaseAddress = new Uri(url);

            return client;
        }
    }
}
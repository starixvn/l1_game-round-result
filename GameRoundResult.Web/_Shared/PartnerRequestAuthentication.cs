using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace GameRoundResult.Web._Shared
{
    public interface IPartnerRequestAuthentication
    {
        Task<AuthenticationResult> Authorize(string partnerId, HttpRequest request, string partnerSecret, InternalAuth internalAuth = null);

        Task<AuthenticationResult> AuthorizeByKeyValue(string partnerId, string partnerSecret);

        Task<AuthenticationResult> AuthorizeByAccessKey(string partnerId, HttpRequest request);
    }

    public class PartnerRequestAuthentication : IPartnerRequestAuthentication
    {
        private readonly IPartnerService partnerService;
        private readonly IEnumerable<AuthenticationClient> internalClient;

        public readonly AuthenticationResult badRequestResult = new(false, string.Empty);

        public PartnerRequestAuthentication(IPartnerService partnerService,
            IOptions<List<AuthenticationClient>> internalClientOptions)
        {
            this.partnerService = partnerService;
            internalClient = internalClientOptions.Value;
        }

        public async Task<AuthenticationResult> Authorize(string partnerId, HttpRequest request, string partnerSecret, InternalAuth internalAuth = null)
        {
            if (IsInternalClient(internalAuth ?? new()))
            {
                var partner = await partnerService.GetById(partnerId);
                return partner != null ? new AuthenticationResult(true, partner.SecretKey) : badRequestResult;
            }

            return string.IsNullOrEmpty(partnerSecret) ?
                 await AuthorizeByAccessKey(partnerId, request) :
                 await AuthorizeByKeyValue(partnerId, partnerSecret);
        }

        public async Task<AuthenticationResult> AuthorizeByKeyValue(string partnerId, string partnerSecret)
        {
            var partner = await partnerService.Get(partnerId, partnerSecret);
            return partner != null ? new AuthenticationResult(true, partner.SecretKey) : badRequestResult;
        }

        public async Task<AuthenticationResult> AuthorizeByAccessKey(string partnerId, HttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Headers["Access-Key"]))
            {
                return badRequestResult;
            }

            var partner = await partnerService.GetById(partnerId);

            if (partner == null)
            {
                return badRequestResult;
            }

            var secretKey = partner.SecretKey;
            var accessKey = request.Headers["Access-Key"];

            request.Body.Seek(0, SeekOrigin.Begin);
            var streamData = new byte[request.Body.Length];
            _ = await request.Body.ReadAsync(streamData);

            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(secretKey));
            var hashResult = hmac.ComputeHash(streamData);

            var rawHashResult = Convert.ToBase64String(hashResult);

            return accessKey == rawHashResult ? new AuthenticationResult(true, partner.SecretKey) : badRequestResult;
        }

        private bool IsInternalClient(InternalAuth internalAuth)
        {
            return internalClient.Any(x => x.Name == internalAuth.Id && x.Key == internalAuth.Key);
        }
    }
}
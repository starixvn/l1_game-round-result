using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GameRoundResult.Core.Services;
using Microsoft.AspNetCore.Http;

namespace GameRoundResult.Web._Shared
{
    public interface IPartnerRequestAuthentication
    {
        Task<bool> Authorize(string partnerId, HttpRequest request, string partnerSecret);
    }

    public class PartnerRequestAuthentication : IPartnerRequestAuthentication
    {
        private readonly IPartnerService partnerService;

        public PartnerRequestAuthentication(IPartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        public async Task<bool> Authorize(string partnerId, HttpRequest request, string partnerSecret)
        {
            var isAuthByAccessKey = await AuthorizeByAccessKey(partnerId, request);

            if (!isAuthByAccessKey)
            {
                var @operator = await partnerService.Get(partnerId, partnerSecret);

                return @operator != null;
            }

            return true;
        }

        public async Task<bool> AuthorizeByAccessKey(string partnerId, HttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Headers["Access-Key"]))
            {
                return false;
            }

            var @operator = await partnerService.GetById(partnerId);

            if (@operator != null)
            {
                var secretKey = @operator.SecretKey;
                var accessKey = request.Headers["Access-Key"];

                request.Body.Seek(0, SeekOrigin.Begin);
                var streamData = new byte[request.Body.Length];
                _ = await request.Body.ReadAsync(streamData);

                var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(secretKey));
                var hashResult = hmac.ComputeHash(streamData);

                var rawHashResult = Convert.ToBase64String(hashResult);
                return accessKey == rawHashResult;
            }

            return false;
        }
    }
}
using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace GameRoundResult.Web._Shared
{
    public interface IHmacHelpers
    {
        string CreateAccessKey(string secretKey, dynamic request);
    }

    public class HmacHelpers : IHmacHelpers
    {
        public string CreateAccessKey(string secretKey, dynamic request)
        {
            var data = JsonConvert.SerializeObject(request);
            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(secretKey));
            var hashResult = hmac.ComputeHash(Encoding.ASCII.GetBytes(data));

            var result = Convert.ToBase64String(hashResult);
            return result;
        }
    }
}
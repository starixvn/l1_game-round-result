using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace GameRoundResult.Web.Configuration
{
    public interface IJsonStringLocalizer<out T> : IStringLocalizer<T>
    {
        LocalizedString GetStringWithNamcespace(string name, string tolgeeNamespace);
    }

    public class JsonStringLocalizer<T> : IJsonStringLocalizer<T>
    {
        private readonly IDistributedCache cache;
        private readonly JsonSerializer serializer = new();
        private readonly bool enableTolgee;
        private readonly string tolgeeNamespace;

        public JsonStringLocalizer(IDistributedCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            enableTolgee = bool.Parse(configuration["EnableTolgee"]);

            tolgeeNamespace = (Attribute.GetCustomAttribute(typeof(T), typeof(TolgeeNamespaceAttribute)) as TolgeeNamespaceAttribute)?.Name ?? typeof(T).Name;
        }

        public LocalizedString this[string name]
        {
            get
            {
                string value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString GetStringWithNamcespace(string name, string tolgeeNamespace)
        {         
                string value = GetString(name, tolgeeNamespace);
                return new LocalizedString(name, value ?? name, value == null);
          
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments), false)
                    : actualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            string filePath = $"Resources/{(typeof(T)).Name}/{Thread.CurrentThread.CurrentCulture.Name}.json";
            using (var str = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var sReader = new StreamReader(str))
            using (var reader = new JsonTextReader(sReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType != JsonToken.PropertyName)
                    {
                        continue;
                    }

                    string key = (string)reader.Value;
                    reader.Read();
                    string value = serializer.Deserialize<string>(reader);

                    yield return new LocalizedString(key, enableTolgee ? $"{{{{{key}|{tolgeeNamespace}}}}}" : value, false);
                }
            }
        }

        private string GetString(string key, string tolgeeNamespace)
        {            
            if (enableTolgee)
            {
                return $"{{{{{key}|{tolgeeNamespace}}}}}";
            }

            string relativeFilePath = $"Resources/Tolgee/{tolgeeNamespace}/{Thread.CurrentThread.CurrentCulture.Name}.json";
            string fullFilePath = Path.GetFullPath(relativeFilePath);
            if (File.Exists(fullFilePath))
            {
                string cacheKey = $"locale_{Thread.CurrentThread.CurrentCulture.Name}_{key}";
                string cacheValue = cache.GetString(cacheKey);

                if (!string.IsNullOrEmpty(cacheValue))
                {
                    return cacheValue;
                }

                string result = GetValueFromJSON(key, Path.GetFullPath(relativeFilePath));

                if (!string.IsNullOrEmpty(result))
                {
                    cache.SetString(cacheKey, result);
                }

                return result;
            }

            return default;
        }

        private string GetString(string key)
        {
            return GetString(key, tolgeeNamespace);
        }

        private string GetValueFromJSON(string propertyName, string filePath)
        {
            if (propertyName == null || filePath == null)
            {
                return default;
            }

            using (var str = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var sReader = new StreamReader(str))
            using (var reader = new JsonTextReader(sReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == propertyName)
                    {
                        reader.Read();
                        return serializer.Deserialize<string>(reader);
                    }
                }
                return default;
            }
        }
    }
}
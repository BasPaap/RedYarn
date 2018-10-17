using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Extensions
{
    static class HttpContentExtensions
    {
        public static T FromJsonString<T>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<T>((content.ReadAsStringAsync().Result));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Extensions
{
    static class ObjectExtensions
    {
        public static StringContent ToJsonStringContent(this object contentObject)
        {
            var json = JsonConvert.SerializeObject(contentObject);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}

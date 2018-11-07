using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bas.RedYarn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public SettingsController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public async Task<JsonResult> GetSettingsAsync()
        {
            var settingsFilePath = Path.Combine(this.hostingEnvironment.ContentRootPath, "settings.json");
            JObject jObject;

            using (var textReader = new StreamReader(settingsFilePath))
            {
                using (var jsonReader = new JsonTextReader(textReader))
                {
                    jObject = await JObject.LoadAsync(jsonReader);
                }
            }

            return new JsonResult(jObject);
        }        
    }
}
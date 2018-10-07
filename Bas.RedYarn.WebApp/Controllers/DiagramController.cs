using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bas.RedYarn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramController : ControllerBase
    {
        private IDataService dataService;

        public DiagramController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("[action]")]
        public string GetDiagram(int id)
        {
            var diagram = this.dataService.GetDiagram(id);

            throw new NotImplementedException();
        }
    }
}
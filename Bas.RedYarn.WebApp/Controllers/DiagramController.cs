using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.ViewModels;
using Bas.RedYarn.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bas.RedYarn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramController : ControllerBase
    {
        private readonly IDataService dataService;

        public DiagramController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModels.DiagramViewModel>> GetDiagramViewModelAsync(Guid id)
        {
            return await this.dataService.GetDiagramViewModelAsync(id);            
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DiagramViewModel>> CreateDiagramAsync(DiagramViewModel diagramViewModel)
        {
            //var vm = await this.dataService.CreateDiagramAsync(diagramViewModel);
            //return CreatedAtAction(RouteData.Values["Action"].ToString(), RouteData.Values["Controller"].ToString(), new { id = vm.Id }, vm);                        
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDiagramAsync(DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDiagramAsync(DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
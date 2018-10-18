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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DiagramViewModel>> GetDiagramViewModelAsync(Guid id)
        {            
            var diagramViewModel = await this.dataService.GetDiagramViewModelAsync(id);            
            if (diagramViewModel == null)
            {
                return NotFound();
            }

            return diagramViewModel;            
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DiagramViewModel>> CreateDiagramAsync(DiagramViewModel diagramViewModel)
        {
            var createdDiagramViewModel = await this.dataService.CreateDiagramAsync(diagramViewModel);
            return CreatedAtAction(RouteData.Values["Action"].ToString(), RouteData.Values["Controller"].ToString(), new { id = createdDiagramViewModel.Id }, createdDiagramViewModel);            
        }

        [HttpPut]        
        public async Task<ActionResult> UpdateDiagramAsync(Guid id, DiagramViewModel diagramViewModel)
        {
            await this.dataService.UpdateDiagramViewModelAsync(id, diagramViewModel);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteDiagramAsync(Guid id)
        {
            if (await this.dataService.GetDiagramViewModelAsync(id) == null)
            {
                return NotFound();
            }

            await this.dataService.DeleteDiagramViewModelAsync(id);
            return NoContent();
        }
    }
}
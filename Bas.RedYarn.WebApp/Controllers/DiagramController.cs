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
        public ActionResult<ViewModels.DiagramViewModel> GetDiagramViewModel(Guid id)
        {
            return this.dataService.GetDiagramViewModel(id);            
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DiagramViewModel>> CreateDiagramAsync(DiagramViewModel diagramViewModel)
        {
            //var result = new DiagramViewModel() { Id = Guid.NewGuid(), Name = "Hallo!" };
            //return CreatedAtAction(nameof(GetDiagramViewModel), nameof(DiagramController), new { result.Id }, result);

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
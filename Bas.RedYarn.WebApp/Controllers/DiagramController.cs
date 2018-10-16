using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.ViewModel;
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
        public ActionResult<ViewModel.DiagramViewModel> GetDiagramViewModel(Guid id)
        {
            return this.dataService.GetDiagramViewModel(id);            
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDiagramAsync(DiagramViewModel diagramViewModel)
        {
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
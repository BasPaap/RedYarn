using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Controllers
{
    public partial class DiagramController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<DiagramListItemViewModel>>> GetDiagramsAsync()
        {
            return await this.dataService.GetDiagramsAsync();
        }
    }
}

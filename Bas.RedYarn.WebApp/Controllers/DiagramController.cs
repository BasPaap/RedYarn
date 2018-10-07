﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bas.RedYarn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramController : ControllerBase
    {

        [HttpGet("[action]")]
        public IEnumerable<Diagram> GetDiagram()
        {
            var edmond = new Character() { Name = "Edmond Dantes" };
            var mercedes = new Character() { Name = "Mercedes" };
            var storyline = new Storyline() { Name = "De noodlottige bruiloft" };
            var author = new Author() { Name = "Alexandre Dumas" };

            edmond.RelateTo(mercedes, "Verloofd");

            var diagram = new Diagram();
            diagram.Characters.Add(edmond);
            diagram.Characters.Add(mercedes);
            diagram.Authors.Add(author);
            diagram.Storylines.Add(storyline);

            return new[] { diagram };
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Model;
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
        public ActionResult<Model.Diagram> GetDiagram(int id)
        {
            var diagram = this.dataService.GetDiagram(id);

            var characterDictionary = new Dictionary<RedYarn.Character, Model.Character>(diagram.Characters.Select(c => new KeyValuePair<RedYarn.Character, Model.Character>(c, new Model.Character(c))));
            var storylineDictionary = new Dictionary<RedYarn.Storyline, Model.Storyline>(diagram.Storylines.Select(s => new KeyValuePair<RedYarn.Storyline, Model.Storyline>(s, new Model.Storyline(s))));

            var diagramModel = new Model.Diagram(diagram);
            diagramModel.AddStorylines(storylineDictionary);
            diagramModel.AddCharacters(characterDictionary);
            diagramModel.GenerateStorylineConnections(storylineDictionary, characterDictionary);
            diagramModel.GenerateRelationships(characterDictionary);
            
            return diagramModel;
        }        
    }
}
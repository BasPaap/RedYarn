using System;
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

        [HttpGet("[action]")]
        public ActionResult<Model.Diagram> GetDiagram(int id)
        {
            var diagram = this.dataService.GetDiagram(id);

            var characterDictionary = new Dictionary<RedYarn.Character, Model.Character>(diagram.Characters.Select(c => new KeyValuePair<RedYarn.Character, Model.Character>(c, new Model.Character(c))));
            var storylineDictionary = new Dictionary<RedYarn.Storyline, Model.Storyline>(diagram.Storylines.Select(s => new KeyValuePair<RedYarn.Storyline, Model.Storyline>(s, new Model.Storyline(s))));

            var diagramModel = new Model.Diagram(diagram);
            diagramModel.AddStorylines(storylineDictionary);
            diagramModel.AddCharacters(characterDictionary);
            diagramModel.GenerateStorylineConnections(storylineDictionary, characterDictionary);

            
            return diagramModel;
        }

        private static void AddCharactersAndRelationshipsToDiagramModel(Dictionary<Character, Model.Character> characterDictionary, Model.Diagram diagramModel)
        {
            foreach (var character in characterDictionary.Keys)
            {
                //diagramModel.Characters.Add(characterDictionary[character]);

                foreach (var otherCharacter in characterDictionary.Keys)
                {
                    if (character != otherCharacter)
                    {
                        var relationships = character.GetRelationshipsTo(otherCharacter);

                        foreach (var relationship in relationships.Where(r => r.Type == RelationshipType.Forward || r.Type== RelationshipType.NonDirectional))
                        {
                            diagramModel.Relationships.Add(new Model.Relationship()
                            {
                                FromCharacterId = characterDictionary[character].Id,
                                ToCharacterId = characterDictionary[otherCharacter].Id,
                                Name = relationship.Name
                            });
                        }
                    }
                }
            }
        }
    }
}
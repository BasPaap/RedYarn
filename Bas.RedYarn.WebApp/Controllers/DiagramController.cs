using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            AddCharactersAndRelationshipsToDiagram(characterDictionary, diagramModel);
            AddStorylinesAndConnectionsToDiagram(characterDictionary, storylineDictionary, diagramModel);

            return diagramModel;
        }

        private static void AddStorylinesAndConnectionsToDiagram(Dictionary<Character, Model.Character> characterDictionary, Dictionary<Storyline, Model.Storyline> storylineDictionary, Model.Diagram diagramModel)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                diagramModel.Storylines.Add(storylineDictionary[storyline]);
                foreach (var character in storyline.Characters)
                {
                    diagramModel.StorylineConnections.Add(new Model.StorylineConnection()
                    {
                        CharacterId = characterDictionary[character].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        private static void AddCharactersAndRelationshipsToDiagram(Dictionary<Character, Model.Character> characterDictionary, Model.Diagram diagramModel)
        {
            foreach (var character in characterDictionary.Keys)
            {
                diagramModel.Characters.Add(characterDictionary[character]);

                foreach (var otherCharacter in characterDictionary.Keys)
                {
                    if (character != otherCharacter)
                    {
                        var relationships = character.GetRelationshipsTo(otherCharacter);

                        foreach (var relationship in relationships)
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
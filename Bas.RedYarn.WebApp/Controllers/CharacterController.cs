using Bas.RedYarn.WebApp.Services;
using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CharacterController : ControllerBase
    {
        // CRUD actions and IDataService instance are declared in GeneratedController\CharacterController.cs
        [HttpPost("{fromCharacterId}/relateto/{toCharacterId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CharacterViewModel>> RelateTo(Guid fromCharacterId, Guid toCharacterId, (string name, bool isDirectional) relationship)
        {
            try
            {
                if (fromCharacterId == Guid.Empty || 
                    toCharacterId == Guid.Empty ||                    
                    string.IsNullOrWhiteSpace(relationship.name))
                {
                    return BadRequest();
                }

                var fromCharacter = (await this.dataService.GetCharacterViewModelAsync(fromCharacterId))?.ToModel();
                if (fromCharacter == null)
                {
                    return NotFound();
                }

                var toCharacter = (await this.dataService.GetCharacterViewModelAsync(toCharacterId))?.ToModel();
                if (toCharacter == null)
                {
                    return NotFound();
                }

                try
                {
                    await this.dataService.RelateCharactersAsync(fromCharacterId, toCharacterId, relationship.name, relationship.isDirectional);                    
                }
                catch
                {
                    return BadRequest();
                }
                                
                var newRelationshipViewModel = new RelationshipViewModel()
                {
                    FromCharacterId = fromCharacterId,
                    ToCharacterId = toCharacterId,
                    Name = relationship.name,
                    IsDirectional = relationship.isDirectional
                };
                                
                return CreatedAtAction(nameof(RelateTo), new { id = fromCharacterId }, newRelationshipViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
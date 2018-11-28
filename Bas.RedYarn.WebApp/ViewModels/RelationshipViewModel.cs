using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class RelationshipViewModel
    {
        public Guid FirstCharacterId { get; set; }
        public Guid SecondCharacterId { get; set; }
        public string Name { get; set; }
        public bool IsDirectional { get; set; }

        public RelationshipViewModel()
        {
        }

        public RelationshipViewModel(Relationship model, Func<object, (Guid, Guid)> getIdsForModelFunc = null)
        {
            if (getIdsForModelFunc != null)
            {
                (Guid firstCharacterId, Guid secondCharacterId) = getIdsForModelFunc(model);

                FirstCharacterId = firstCharacterId;
                SecondCharacterId = secondCharacterId;
            }

            Name = model.Name;
            IsDirectional = model.IsDirectional;
        }

        public RelationshipViewModel(RelationshipViewModel viewModel)
        {
            FirstCharacterId = viewModel.FirstCharacterId;
            SecondCharacterId = viewModel.SecondCharacterId;
            Name = viewModel.Name;
            IsDirectional = viewModel.IsDirectional;
        }

        public void UpdateModel(RedYarn.Relationship model, Func<Guid, Guid, (Character, Character)> getCharactersFunc = null)
        {
            model.Name = Name;
            model.IsDirectional = IsDirectional;

            if (getCharactersFunc != null)
            {
                (Character firstCharacter, Character secondCharacter) = getCharactersFunc(FirstCharacterId, SecondCharacterId);
                model.FirstCharacter = firstCharacter;
                model.SecondCharacter = secondCharacter;
            }            
        }

        public Relationship ToModel(Func<Guid, Character> getCharacterFunc = null)
        {
            var relationship = new Relationship()
            {
                Name = this.Name,
                IsDirectional = this.IsDirectional
            };

            if (getCharacterFunc != null)
            {
                relationship.FirstCharacter = getCharacterFunc(this.FirstCharacterId);
                relationship.SecondCharacter = getCharacterFunc(this.SecondCharacterId);
            }

            return relationship;
        }
    }
}

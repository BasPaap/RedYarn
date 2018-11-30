using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class RelationshipViewModel : ConnectionViewModel
    {
        public string Name { get; set; }
        public bool IsDirectional { get; set; }

        public RelationshipViewModel()
        {
        }

        public RelationshipViewModel(Relationship model, Func<object, (Guid, Guid)> getIdsForModelFunc = null)
        {
            if (getIdsForModelFunc != null)
            {
                (Guid fromNodeId, Guid toNodeId) = getIdsForModelFunc(model);

                FromNodeId = fromNodeId;
                ToNodeId = toNodeId;
            }

            Name = model.Name;
            IsDirectional = model.IsDirectional;
        }

        public RelationshipViewModel(RelationshipViewModel viewModel)
            :base(viewModel)
        {
            Name = viewModel.Name;
            IsDirectional = viewModel.IsDirectional;
        }

        public void UpdateModel(RedYarn.Relationship model, Func<Guid, Guid, (Character, Character)> getCharactersFunc = null)
        {
            model.Name = Name;
            model.IsDirectional = IsDirectional;

            if (getCharactersFunc != null)
            {
                (Character firstCharacter, Character secondCharacter) = getCharactersFunc(FromNodeId, ToNodeId);
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
                relationship.FirstCharacter = getCharacterFunc(this.FromNodeId);
                relationship.SecondCharacter = getCharacterFunc(this.ToNodeId);
            }

            return relationship;
        }
    }
}

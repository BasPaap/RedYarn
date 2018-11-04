using Bas.RedYarn.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    sealed class TestDataService : IDataService
    {
        public Task<DiagramViewModel> CreateDiagramViewModelAsync(DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiagramViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public Task<(DiagramViewModel result, bool isFound)> UpdateDiagramViewModelAsync(Guid id, DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<DiagramViewModel> GetDiagramViewModelAsync(Guid id)
        {
            var dumas = new Author() { Name = "Alexandre Dumas" };

            var edmond = new Character() { Name = "Edmond Dantés" };
            edmond.Aliases.Add(new Alias() { Name = "Count of Monte Christo" });
            edmond.Aliases.Add(new Alias() { Name = "Sinbad the Sailor" });
            edmond.Aliases.Add(new Alias() { Name = "Abbé Busoni" });
            edmond.Aliases.Add(new Alias() { Name = "Lord Wilmore" });
            edmond.Authors.Add(dumas);

            var louis = new Character() { Name = "Louis Dantés" };
            louis.Authors.Add(dumas);

            var mercedes = new Character() { Name = "Mercédès" };
            mercedes.Aliases.Add(new Alias() { Name = "Countess Mercédès Mondego" });
            mercedes.Aliases.Add(new Alias() { Name = "Mlle de Morcerf" });
            mercedes.Authors.Add(dumas);

            var fernand = new Character { Name = "Fernand Mondego" };
            fernand.Aliases.Add(new Alias() { Name = "Count de Morcerf" });
            fernand.Authors.Add(dumas);

            var albert = new Character { Name = "Albert de Morcerf" };
            albert.Authors.Add(dumas);

            var haydee = new Character { Name = "Haydée" };
            haydee.Authors.Add(dumas);

            edmond.RelateTo(louis, "son of", true);
            edmond.RelateTo(mercedes, "engaged" );
            edmond.RelateTo(haydee, "owns", true);
            edmond.RelateTo(haydee, "loves" );

            mercedes.RelateTo(fernand, "married" );

            mercedes.RelateTo(albert, "mother of", true);
            fernand.RelateTo(albert, "father of", true);
            albert.RelateTo(edmond, "challenges to a duel", true);

            haydee.RelateTo(fernand, "exposes", true);

            var betrayal = new Storyline()
            {
                Name = "The Betrayal of Ali Pasha",
                Description = "Lorem Ipsum etc.",
            };

            betrayal.Authors.Add(dumas);
            betrayal.Characters.Add(fernand);
            betrayal.Characters.Add(haydee);

            var haydeesIdentity = new PlotElement()
            {
                Name = "Haydée is Ali Pasha's daughter",
                Description = "Ali Pasha's daughter was sold into slavery and, after the death of her mother, the only surviving person to know of Ali's betrayer."
            };
            haydeesIdentity.OwningCharacters.Add(haydee);

            var alisBetrayer = new PlotElement()
            {
                Name = "Fernand betrayed and murdered Ali Pasha.",
                Description = "Fernand was the officer who betrayed and murdered Ali Pasha. If this became public, it would cause a scandal."
            };
            alisBetrayer.OwningCharacters.Add(fernand);
            alisBetrayer.NeedingCharacters.Add(haydee);
            
            betrayal.PlotElements.Add(haydeesIdentity);
            betrayal.PlotElements.Add(alisBetrayer);

            var diagram = new Diagram()
            {
                Name = "The Count of Monte Cristo"
            };

            diagram.Characters.Add(edmond);
            diagram.Characters.Add(louis);
            diagram.Characters.Add(mercedes);
            diagram.Characters.Add(fernand);
            diagram.Characters.Add(albert);
            diagram.Characters.Add(haydee);
            diagram.Authors.Add(dumas);
            diagram.Storylines.Add(betrayal);
            diagram.PlotElements.Add(alisBetrayer);
            diagram.PlotElements.Add(haydeesIdentity);

            return Task.FromResult(new DiagramViewModel(diagram));
        }

        public Task<CharacterViewModel> GetCharacterViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterViewModel> CreateCharacterViewModelAsync(Guid diagramId, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(CharacterViewModel result, bool isFound)> UpdateCharacterViewModelAsync(Guid id, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StorylineViewModel> GetStorylineViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StorylineViewModel> CreateStorylineViewModelAsync(Guid diagramId, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(StorylineViewModel result, bool isFound)> UpdateStorylineViewModelAsync(Guid id, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStorylineViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> GetAuthorViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> CreateAuthorViewModelAsync(Guid diagramId, AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(AuthorViewModel result, bool isFound)> UpdateAuthorViewModelAsync(Guid id, AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuthorViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlotElementViewModel> GetPlotElementViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlotElementViewModel> CreatePlotElementViewModelAsync(Guid diagramId, PlotElementViewModel plotElementViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(PlotElementViewModel result, bool isFound)> UpdatePlotElementViewModelAsync(Guid id, PlotElementViewModel plotElementViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlotElementViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TagViewModel> GetTagViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TagViewModel> CreateTagViewModelAsync(Guid diagramId, TagViewModel tagViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(TagViewModel result, bool isFound)> UpdateTagViewModelAsync(Guid id, TagViewModel tagViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTagViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AliasViewModel> GetAliasViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AliasViewModel> CreateAliasViewModelAsync(Guid diagramId, AliasViewModel aliasViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<(AliasViewModel result, bool isFound)> UpdateAliasViewModelAsync(Guid id, AliasViewModel aliasViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAliasViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

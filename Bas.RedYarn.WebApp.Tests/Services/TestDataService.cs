using Bas.RedYarn.WebApp.ViewModels;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        public Collection<DiagramViewModel> DiagramViewModels { get; set; } = new Collection<DiagramViewModel>();
        public Collection<StorylineViewModel> StorylineViewModels { get; set; } = new Collection<StorylineViewModel>();
        public Collection<AuthorViewModel> AuthorViewModels { get; set; } = new Collection<AuthorViewModel>();
        public Collection<CharacterViewModel> CharacterViewModels { get; set; } = new Collection<CharacterViewModel>();

        public TestDataService()
        {
        }
                
        public async Task<DiagramViewModel> GetDiagramViewModelAsync(Guid id)
        {
            return DiagramViewModels.SingleOrDefault(d => d.Id == id);
        }

        public async Task<DiagramViewModel> CreateDiagramAsync(DiagramViewModel diagramViewModel)
        {
            diagramViewModel.Id = Guid.NewGuid();
            DiagramViewModels.Add(diagramViewModel);

            return diagramViewModel;
        }

        public async Task<DiagramViewModel> UpdateDiagramViewModelAsync(Guid id, DiagramViewModel diagramViewModel)
        {
            var existingViewModel = DiagramViewModels.SingleOrDefault(d => d.Id == id);
            existingViewModel = diagramViewModel;
            existingViewModel.Id = id;

            return existingViewModel;
        }

        public async Task DeleteDiagramViewModelAsync(Guid id)
        {
            var existingViewModel = DiagramViewModels.SingleOrDefault(d => d.Id == id);
            DiagramViewModels.Remove(existingViewModel);

            return;
        }

        public Task<CharacterViewModel> GetCharacterViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterViewModel> CreateCharacterAsync(CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterViewModel> UpdateCharacterViewModelAsync(Guid id, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCharacterViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StorylineViewModel> GetStorylineViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StorylineViewModel> CreateStorylineAsync(StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<StorylineViewModel> UpdateStorylineViewModelAsync(Guid id, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStorylineViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> GetAuthorViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> CreateAuthorAsync(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorViewModel> UpdateAuthorViewModelAsync(Guid id, AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

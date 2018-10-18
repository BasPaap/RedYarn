using Bas.RedYarn.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    public interface IDataService
    {
        Task<DiagramViewModel> GetDiagramViewModelAsync(Guid id);
        Task<DiagramViewModel> CreateDiagramAsync(DiagramViewModel diagramViewModel);
        Task<DiagramViewModel> UpdateDiagramViewModelAsync(Guid id, DiagramViewModel diagramViewModel);
        Task DeleteDiagramViewModelAsync(Guid id);

        Task<CharacterViewModel> GetCharacterViewModelAsync(Guid id);
        Task<CharacterViewModel> CreateCharacterAsync(CharacterViewModel characterViewModel);
        Task<CharacterViewModel> UpdateCharacterViewModelAsync(Guid id, CharacterViewModel characterViewModel);
        Task DeleteCharacterViewModelAsync(Guid id);

        Task<StorylineViewModel> GetStorylineViewModelAsync(Guid id);
        Task<StorylineViewModel> CreateStorylineAsync(StorylineViewModel storylineViewModel);
        Task<StorylineViewModel> UpdateStorylineViewModelAsync(Guid id, StorylineViewModel storylineViewModel);
        Task DeleteStorylineViewModelAsync(Guid id);

        Task<AuthorViewModel> GetAuthorViewModelAsync(Guid id);
        Task<AuthorViewModel> CreateAuthorAsync(AuthorViewModel authorViewModel);
        Task<AuthorViewModel> UpdateAuthorViewModelAsync(Guid id, AuthorViewModel authorViewModel);
        Task DeleteAuthorViewModelAsync(Guid id);
    }
}

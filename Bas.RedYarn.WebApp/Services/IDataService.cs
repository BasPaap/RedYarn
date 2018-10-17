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
        
        void AddCharacter(Guid diagramId, CharacterViewModel characterViewModel);
        void AddStoryline(Guid diagramId, StorylineViewModel storylineViewModel);
    }
}

using Bas.RedYarn.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    public interface IDataService
    {
        DiagramViewModel GetDiagramViewModel(Guid id);
        Task<DiagramViewModel> CreateDiagramAsync(string name);
        void AddCharacter(Guid diagramId, CharacterViewModel characterViewModel);
        void AddStoryline(Guid diagramId, StorylineViewModel storylineViewModel);
    }
}

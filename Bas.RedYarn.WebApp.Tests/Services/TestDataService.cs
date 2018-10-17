using Bas.RedYarn.WebApp.ViewModels;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        public Collection<DiagramViewModel> DiagramViewModels { get; set; } = new Collection<DiagramViewModel>();

        public TestDataService()
        {
        }
        
        public DiagramViewModel GetDiagramViewModel(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<DiagramViewModel> CreateDiagramAsync(string name)
        {
            var diagramViewModel = new DiagramViewModel()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            DiagramViewModels.Add(diagramViewModel);

            return diagramViewModel;
        }

        public void AddCharacter(Guid diagramId, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public void AddStoryline(Guid diagramId, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

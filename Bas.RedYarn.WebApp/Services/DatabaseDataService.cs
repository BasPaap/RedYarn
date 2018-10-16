using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Database;
using Bas.RedYarn.WebApp.ViewModels;

namespace Bas.RedYarn.WebApp.Services
{
    public sealed class DatabaseDataService : IDataService
    {
        public DatabaseDataService(RedYarnDbContext redYarnDbContext)
        {
            this.dbContext = redYarnDbContext;
        }
        private RedYarnDbContext dbContext;
        public void AddCharacter(Guid diagramId, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public void AddStoryline(Guid diagramId, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<DiagramViewModel> CreateDiagramAsync(string name)
        {
            var diagram = new Diagram()
            {
                Name = name
            };

            dbContext.Diagrams.Add(diagram);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            return new DiagramViewModel(diagram);
        }

        public DiagramViewModel GetDiagramViewModel(Guid id)
        {
            return new DiagramViewModel();
        }
    }
}

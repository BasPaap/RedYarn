﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a tool. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

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

		public async Task<DiagramViewModel> GetDiagramViewModelAsync(Guid id)
        {
            return new DiagramViewModel();
        }

        public async Task<DiagramViewModel> CreateDiagramViewModelAsync(DiagramViewModel diagramViewModel)
        {
			throw new NotImplementedException();
            // var diagram = new Diagram()
            // {
            //     Name = diagramViewModel.Name
            // };
			// 
            // dbContext.Diagrams.Add(diagram);
            // await dbContext.SaveChangesAsync().ConfigureAwait(false);
			// 
            // return new DiagramViewModel(diagram);
        }

        public async Task<DiagramViewModel> UpdateDiagramViewModelAsync(Guid id, DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDiagramViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
		public async Task<CharacterViewModel> GetCharacterViewModelAsync(Guid id)
        {
            return new CharacterViewModel();
        }

        public async Task<CharacterViewModel> CreateCharacterViewModelAsync(CharacterViewModel characterViewModel)
        {
			throw new NotImplementedException();
            // var diagram = new Diagram()
            // {
            //     Name = diagramViewModel.Name
            // };
			// 
            // dbContext.Diagrams.Add(diagram);
            // await dbContext.SaveChangesAsync().ConfigureAwait(false);
			// 
            // return new DiagramViewModel(diagram);
        }

        public async Task<CharacterViewModel> UpdateCharacterViewModelAsync(Guid id, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCharacterViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
		public async Task<StorylineViewModel> GetStorylineViewModelAsync(Guid id)
        {
            return new StorylineViewModel();
        }

        public async Task<StorylineViewModel> CreateStorylineViewModelAsync(StorylineViewModel storylineViewModel)
        {
			throw new NotImplementedException();
            // var diagram = new Diagram()
            // {
            //     Name = diagramViewModel.Name
            // };
			// 
            // dbContext.Diagrams.Add(diagram);
            // await dbContext.SaveChangesAsync().ConfigureAwait(false);
			// 
            // return new DiagramViewModel(diagram);
        }

        public async Task<StorylineViewModel> UpdateStorylineViewModelAsync(Guid id, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStorylineViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
		public async Task<AuthorViewModel> GetAuthorViewModelAsync(Guid id)
        {
            return new AuthorViewModel();
        }

        public async Task<AuthorViewModel> CreateAuthorViewModelAsync(AuthorViewModel authorViewModel)
        {
			throw new NotImplementedException();
            // var diagram = new Diagram()
            // {
            //     Name = diagramViewModel.Name
            // };
			// 
            // dbContext.Diagrams.Add(diagram);
            // await dbContext.SaveChangesAsync().ConfigureAwait(false);
			// 
            // return new DiagramViewModel(diagram);
        }

        public async Task<AuthorViewModel> UpdateAuthorViewModelAsync(Guid id, AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAuthorViewModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
	}
}
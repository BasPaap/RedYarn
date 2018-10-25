﻿//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a tool. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Database;
using Bas.RedYarn.WebApp.ViewModels;

namespace Bas.RedYarn.WebApp.Services
{
    public sealed class DatabaseDataService : IDataService
    {
		private RedYarnDbContext dbContext;
		
        public DatabaseDataService(RedYarnDbContext redYarnDbContext)
        {
            this.dbContext = redYarnDbContext;
        }

		public async Task<DiagramViewModel> GetDiagramViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Diagrams.FindAsync(id);
			var viewModel = new DiagramViewModel(model);

			return viewModel;
        }

        public async Task<DiagramViewModel> CreateDiagramViewModelAsync(DiagramViewModel diagramViewModel)
        {
			throw new NotImplementedException();
        }

        public async Task<(DiagramViewModel result, bool isFound)> UpdateDiagramViewModelAsync(Guid id, DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDiagramViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Diagrams.FindAsync(id);
			if (model == null)
			{
				return false;
			}

			this.dbContext.Diagrams.Remove(model);
			await this.dbContext.SaveChangesAsync();
			return true;			
        }

		public async Task<CharacterViewModel> GetCharacterViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Characters.FindAsync(id);
			var node = await this.dbContext.CharacterNodes.FindAsync(id);
			var viewModel = new CharacterViewModel(model, node.XPosition, node.YPosition);

			return viewModel;
        }

        public async Task<CharacterViewModel> CreateCharacterViewModelAsync(CharacterViewModel characterViewModel)
        {
			throw new NotImplementedException();
        }

        public async Task<(CharacterViewModel result, bool isFound)> UpdateCharacterViewModelAsync(Guid id, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCharacterViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Characters.FindAsync(id);
			var node = await this.dbContext.CharacterNodes.FindAsync(id);
			if (model == null || node == null)
			{
				return false;
			}

			this.dbContext.Characters.Remove(model);
			this.dbContext.CharacterNodes.Remove(node);
			await this.dbContext.SaveChangesAsync();
			return true;			
        }

		public async Task<StorylineViewModel> GetStorylineViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Storylines.FindAsync(id);
			var node = await this.dbContext.StorylineNodes.FindAsync(id);
			var viewModel = new StorylineViewModel(model, node.XPosition, node.YPosition);

			return viewModel;
        }

        public async Task<StorylineViewModel> CreateStorylineViewModelAsync(StorylineViewModel storylineViewModel)
        {
			throw new NotImplementedException();
        }

        public async Task<(StorylineViewModel result, bool isFound)> UpdateStorylineViewModelAsync(Guid id, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteStorylineViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Storylines.FindAsync(id);
			var node = await this.dbContext.StorylineNodes.FindAsync(id);
			if (model == null || node == null)
			{
				return false;
			}

			this.dbContext.Storylines.Remove(model);
			this.dbContext.StorylineNodes.Remove(node);
			await this.dbContext.SaveChangesAsync();
			return true;			
        }

		public async Task<AuthorViewModel> GetAuthorViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Authors.FindAsync(id);
			var viewModel = new AuthorViewModel(model);

			return viewModel;
        }

        public async Task<AuthorViewModel> CreateAuthorViewModelAsync(AuthorViewModel authorViewModel)
        {
			throw new NotImplementedException();
        }

        public async Task<(AuthorViewModel result, bool isFound)> UpdateAuthorViewModelAsync(Guid id, AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAuthorViewModelAsync(Guid id)
        {
            var model = await this.dbContext.Authors.FindAsync(id);
			if (model == null)
			{
				return false;
			}

			this.dbContext.Authors.Remove(model);
			await this.dbContext.SaveChangesAsync();
			return true;			
        }

	}
}
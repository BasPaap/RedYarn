using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class AliasViewModel
    {
        public AliasViewModel()
        {
        }

        public AliasViewModel(Alias alias)
        {
            Name = alias.Name;
        }

        public AliasViewModel(AliasViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public RedYarn.Alias ToModel()
        {
            return new Alias()
            {
                Name = Name
            };
        }

        public void UpdateModel(RedYarn.Alias model)
        {
            model.Name = Name;
        }
    }

}